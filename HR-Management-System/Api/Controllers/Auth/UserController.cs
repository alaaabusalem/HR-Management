using Domain.Base;
using Domain.Interfaces.Service;
using Domain.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserSvc<User> _Svc;
        public UserController(IUserSvc<User> svc)
        {
            _Svc = svc; 
        }

        [HttpPost]
        [Route("Add")]
        public ReturnResponse<User> Add(User user)
        {
            var RES= new ReturnResponse<User>();
            RES.Data = new();
            try
            {
               RES= _Svc.Add(user); 
            }

            catch (Exception ex) { 
            
            }
            return RES; 
        }
    }
}
