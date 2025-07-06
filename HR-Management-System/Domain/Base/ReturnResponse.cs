using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public class ReturnResponse<T>
    {
        public T? Data { get; set; } 

        public Paginaition Paginaition { get; set; } = new();

        public ResponseHeader ResponseHeader { get; set; } = new();
    }
}
