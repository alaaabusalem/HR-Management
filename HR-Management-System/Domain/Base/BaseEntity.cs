using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public class BaseEntity
    {
        public Guid? Id { get; set; }
        public Guid InsertedModifiedBy { get; set; }
        public DateTime InsertedModifiedDate { get; set; }

    }
}
