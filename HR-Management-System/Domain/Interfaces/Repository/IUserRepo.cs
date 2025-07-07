using Domain.Base;
using Domain.Interfaces.Base;
using Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IUserRepo<T>:IBaseRepo<T>
    {
        ReturnResponse<T> Login(T user);   
    }
}
