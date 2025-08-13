using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Auth
{
    public class Role: BaseEntity
    {
        public string Name { get; set; }

    }
}
