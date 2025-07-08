using Domain.Base;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Models.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Auth
{
    public class UserSvc : IUserSvc<User>
    {
        private readonly IUserRepo<User> _repo;
        private readonly PasswordHasher<User> _passwordHasher;  
        public UserSvc(IUserRepo<User> userRepo, PasswordHasher<User> passwordHasher)
        {
            _repo= userRepo;    
            _passwordHasher= passwordHasher;    
        }
        public ReturnResponse<User> Add(User item)
        {
            ReturnResponse<User> RES= new();
            RES.Data = new();
            try
            {
                if (true)
                {
                    var hashedPassword = HashPassword(item);
                     if(hashedPassword != "")
                    {
                        RES= _repo.Add(item);

                        return RES;
                    }
                }


                else
                {


                }
            }

            catch (Exception ex) { 
            
            
            }
            return RES;
            }

        public ReturnResponse<User> Delete(User item)
        {
            throw new NotImplementedException();
        }

        public ReturnResponse<User> GetData(User item)
        {
            throw new NotImplementedException();
        }

        public ReturnResponse<List<User>> GetDataList(User item)
        {
            throw new NotImplementedException();
        }

        public ReturnResponse<User> Login(User user)
        {
            throw new NotImplementedException();
        }

        public ReturnResponse<User> Update(User item)
        {
            throw new NotImplementedException();
        }

        // Hash Password using asp.net Identity
        private string HashPassword(User user) {

            try
            {
              var  hashedPass = _passwordHasher.HashPassword(user, user.Password);
                return hashedPass;
            }
            catch (Exception ex) { 
            
            }
            return "";
        }
        // Verify Password using asp.net Identity
    }
}
