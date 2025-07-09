using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{

    public   enum  ResultType : int
    {
        Success = 0,

        error= 1,

        Warning = 2,

        Unauthorized = 3,

        ValidationError = 5,
        LoginFailed = 6,


    }
}
