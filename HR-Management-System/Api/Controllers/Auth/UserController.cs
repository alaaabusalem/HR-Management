using Domain.Base;
using Domain.Interfaces.Service;
using Domain.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserSvc<User> _Svc;
        public UserController(IUserSvc<User> svc)
        {
            _Svc = svc; 
        }

        [HttpPost]
        [Route("Add")]
        public ReturnResponse<User> Add(User user)
        {
           


            var RES= new ReturnResponse<User>();
            RES.Data = new();
            if (!ModelState.IsValid)
            {
                RES.ResponseHeader.Status = Domain.Enums.ResultType.error;
                RES.ResponseHeader.MessagesList.Add(new Message()
                {
                    MessageCode = "000",
                    MessageDesc = "The Name is Required"
                });

            }
            try
            {
               RES= _Svc.Add(user); 
            }

            catch (Exception ex) { 
            
            }
            return RES; 
        }

        [HttpGet]
        [Route("GetDataList")]
        public ReturnResponse<List<User>> GetDataList(User user)
        {



            var RES = new ReturnResponse<List<User>>();
            RES.Data = new();
          
            try
            {
                RES = _Svc.GetDataList(user);
            }

            catch (Exception ex)
            {

            }
            return RES;
        }
    }
}
