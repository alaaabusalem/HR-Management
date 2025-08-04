using Domain.Base;
using Domain.UDT.Auth;
using Domain.ViewModels.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Auth
{
    public class User: BaseEntity
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime? ContractStart {  get; set; }
        public DateTime? ContractEnd { get; set; }
        public bool IsActive { get; set; }
        public string? Phone {  get; set; }
        public List<RoleUDT> RoleList { get; set; } = new();


        public static explicit operator User(CreatUser creatUser)
        {

            return new User
            {
                Id = creatUser.Id,
                Name = creatUser.Name,
                Password = creatUser.Password,
                Email = creatUser.Email,
                ContractStart = creatUser.ContractStart,
                ContractEnd = creatUser.ContractEnd,
                IsActive = creatUser.IsActive,
                Phone = creatUser.Phone,
                RoleList = creatUser.RoleList
            };


        }
    }
}
