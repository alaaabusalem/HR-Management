using Domain.Base;
using Domain.Interfaces.Base;
using Domain.Models.Auth;
using Domain.UDT.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IUserRepo<T>:IBaseRepo<T>
    {
        Task<ReturnResponse<T>> Login(T user);
        Task<ReturnResponse<List<Role>>> GetUserRoles(T user);

    }
}
