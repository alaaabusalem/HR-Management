using Domain.UDT.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Auth
{
    public class CreatUser
    {

        public Guid? Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]

        public string? Password { get; set; }

        [Required]

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public DateTime? ContractStart { get; set; }
        public DateTime? ContractEnd { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [Phone]
        public string? Phone { get; set; }
        public List<RoleUDT> RoleList { get; set; } = new();

        
    }
}
