using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Base
{
    public interface IBaseRepo<T>
    {
        Task<ReturnResponse<T>> Add(T item);
        Task<ReturnResponse<T>> Update(T item);
        Task<ReturnResponse<T>> Delete(T item);
        Task<ReturnResponse<T>> GetData(T item);
        Task<ReturnResponse<List<T>>> GetDataList(T item);

    }
}
