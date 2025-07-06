using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public class Paginaition
    {
        public int PageSize { set; get; } = 0;
        public int PageNumber { set; get; } = 1;
        public int AvailablePages { set; get; } = 0;
        public int AvailableRows { set; get; } = 0;
        public int CurrentRows { set; get; } = 0;
    }
}
