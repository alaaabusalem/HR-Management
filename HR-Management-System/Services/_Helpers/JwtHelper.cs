using Domain.Interfaces.Service;
using Domain.Models.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services._Helpers
{
    public static class JwtHelper
    {

        public static async void AddTokenVersionCheck(this JwtBearerOptions options)
        {
            options.Events = new JwtBearerEvents
            {
                OnTokenValidated = async context =>
                {
                    var userRepo = context.HttpContext.RequestServices
                        .GetRequiredService<IUserSvc<User>>();

                    var userId = context.Principal?.FindFirst("UserId")?.Value;
                    var tokenVersionClaim = context.Principal?.FindFirst("TokenVersion")?.Value;

                    if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(tokenVersionClaim))
                    {
                        context.Fail("Invalid token");
                        return;
                    }

                    if (!Guid.TryParse(userId, out var userGuid))
                    {
                        context.Fail("Invalid user ID format");
                        return;
                    }
                    
                    var user = await userRepo.GetData(new User() { Id = userGuid });
                    if (user == null)
                    {
                        context.Fail("User not found");
                        return;
                    }

                    if (user.Data.TokenVersion.ToString() != tokenVersionClaim)
                    {
                        context.Fail("Token invalid due to version mismatch (roles changed)");
                    }
                }
            };
        }
    }
}
