using Domain.Base;
using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IUserSvc<T>: IBaseService<T>
    {
        ReturnResponse<T> Login(T user);

    }
}
