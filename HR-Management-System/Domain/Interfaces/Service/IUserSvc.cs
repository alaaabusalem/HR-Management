using Domain.Base;
using Domain.Interfaces.Base;
using Domain.Models.Auth;
using Domain.ViewModels.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IUserSvc<T>: IBaseService<T>
    {
        Task<ReturnResponse<AuthUser>> Login(T user);
        Task<ReturnResponse<List<Role>>> GetUserRoles(T user);

    }
}
