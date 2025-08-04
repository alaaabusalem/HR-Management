using Api._Helpers;
using Domain.Base;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Models.Auth;
using Domain.ViewModels.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Auth
{
    public class UserSvc : IUserSvc<User>
    {
        private readonly IUserRepo<User> _repo;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwt _jwt;

        public UserSvc(IUserRepo<User> userRepo, IPasswordHasher<User> passwordHasher, IJwt jwt)
        {
            _repo = userRepo;
            _passwordHasher = passwordHasher;
            _jwt = jwt; 
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
                        item.Password = hashedPassword;
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
            ReturnResponse<User> RES = new();
            RES.Data = new();

            try
            {
                RES= _repo.GetData(item);
            }
            catch(Exception ex) { 
            
            }
            return RES;
            }

        public ReturnResponse<List<User>> GetDataList(User item)
        {
            return _repo.GetDataList(item);
        }

        public ReturnResponse<AuthUser> Login(User user)
        {
            ReturnResponse<AuthUser> RES = new();
            RES.Data= new();

            try
            {
              var dataUser= _repo.Login(user).Data;
                if (dataUser !=null && dataUser.Password !=null && VerifyPassword(dataUser, user.Password))
                {
                    var AuthUser = _repo.GetData(user).Data;

                    var jwt = _jwt.GenerateJwtToken(AuthUser, new TimeSpan(1,0,0));
                    RES.Data.jwt= jwt;  
                    return RES;
                }
            }

            catch (Exception ex) { 
            
            }

            RES.ResponseHeader.Status = Domain.Enums.ResultType.LoginFailed;
            RES.ResponseHeader.MessagesList.Add(new Message(){
                MessageCode = "",
                MessageDesc=" Login Falied, Please try again with correct Email and Password"
            });
            return RES;
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

        private bool VerifyPassword(User user, string providedPass)
        {
            try
            {

                if (user != null && providedPass != null
                    )
                {
                    var result = _passwordHasher.VerifyHashedPassword(user, user.Password, providedPass);
                    if (result == PasswordVerificationResult.Success)
                        return true;
                }
            }
            catch (Exception ex) { 
            
            }
            return false;
        }
    }
}
