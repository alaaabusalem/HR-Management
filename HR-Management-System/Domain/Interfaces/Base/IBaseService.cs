using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Base
{
    public interface IBaseService<T>
    {
        ReturnResponse<T> Add(T item);
        ReturnResponse<T> Update(T item);
        ReturnResponse<T> Delete(T item);
        ReturnResponse<T> GetData(T item);
        ReturnResponse<List<T>> GetDataList(T item);
    }
}
