using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Auth
{
    public class UserVM
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }

        //  public bool IsEmailConfirmed { get; set; }
        //  public bool IsPasswordConfirmed { get; set; }
        public DateOnly ContractStart { get; set; }
        public DateOnly ContractEnd { get; set; }
        public bool IsActive { get; set; }
        public string? Phone { get; set; }
        public string? JwtToken { get; set; }
        public List<string> RoleList { get; set; } = new();


    }
}
