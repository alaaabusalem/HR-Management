using Dapper;
using Domain._Helpers;
using Domain.Base;
using Domain.Interfaces.Repository;
using Domain.Models.Auth;
using Repositories._Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Auth
{
    public class UserRepo : IUserRepo<User>
    {
        private readonly DapperContext _dapperContext;
        public UserRepo(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<ReturnResponse<User>> Add(User item)
        {
            var RES= new ReturnResponse<User>();
            RES.Data = new();
            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("Name", item.Name, DbType.String);
                    parameters.Add("Phone", item.Phone, DbType.String);
                    parameters.Add("Email", item.Email, DbType.String);
                    parameters.Add("Password", item.Password, DbType.String);
                    parameters.Add("ContractStart", item.ContractStart, DbType.DateTime);
                    parameters.Add("ContractEnd", item.ContractEnd, DbType.DateTime);
                    parameters.Add("IsActive", item.IsActive, DbType.Boolean);
                    parameters.Add("RoleList", item.RoleList.ListToDataTable().AsTableValuedParameter());

                    parameters.Add("Id", item.Id, DbType.Guid, ParameterDirection.Output);
                    parameters.Add("ProcessStatus", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    parameters.Add("StatusDesc", dbType: DbType.String, size: int.MaxValue, direction: ParameterDirection.Output);
                    parameters.Add("StatusCode", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);
                    var response =await connection.ExecuteAsync("Auth.User_Insert_SP", parameters, commandType: CommandType.StoredProcedure);

                    if(parameters.Get<bool>("@ProcessStatus") == false)
                    {
                        RES.ResponseHeader.Status= Domain.Enums.ResultType.error;
                        RES.ResponseHeader.MessagesList.Add(new Message() { 
                          MessageCode= parameters.Get<string>("@StatusCode"),
                          MessageDesc= parameters.Get<string>("@StatusDesc")                        
                        });
                    }

                    else
                    {
                        RES.Data.Id= parameters.Get<Guid>("Id");
                    }
                }

            }
            catch (Exception ex) { 
            
            
            
            
            
            }

            return RES;
        }

        public Task<ReturnResponse<User>> Delete(User item)
        {
            throw new NotImplementedException();
        }

        public async Task<ReturnResponse<User>> GetData(User item)
        {
            ReturnResponse<User> RES = new();
            RES.Data = new();

            try
            {
                 using(var connection = _dapperContext.CreateConnection())
                 {

                    DynamicParameters parameters= new DynamicParameters();
                    parameters.Add("Id", item.Id);
                    parameters.Add("Email", item.Email);
                    parameters.Add("Name", item.Name);
                    
                    var result = await connection.QueryAsync<User>("Auth.User_Get_SP", parameters, commandType: CommandType.StoredProcedure);
            

                        RES.Data = result.FirstOrDefault();
                    
                 }
            }

              catch (Exception ex) 
              { 

                }
            return RES;
        }

        public async Task<ReturnResponse<List<User>>> GetDataList(User item)
        {
            var RES = new ReturnResponse<List<User>>();
           // RES.Data = new();
            try
            {
               
                using (var connection = _dapperContext.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("Id", item.Id);
                    //parameters.Add("Id", item.Id);
                    //parameters.Add("Id", item.Id);
                   
                    var result = (await connection.QueryAsync<User>("Auth.User_Get_SP", parameters, commandType: CommandType.StoredProcedure)).ToList();
                    
                    
                    RES.Data = result;
                }

            }
            catch (Exception ex) { 
            
            RES.ResponseHeader.Status=Domain.Enums.ResultType.error;
             RES.ResponseHeader.MessagesList = new List<Message>();

                RES.ResponseHeader.MessagesList.Add(new Message()
                {
                    MessageCode = "000",
                    MessageDesc = "Somthing whent wrong on the DB"
                });


            }
            return RES;
        }

        public async Task<ReturnResponse<List<Role>>> GetUserRoles(User user)
        {
            var RES= new ReturnResponse<List<Role>>();
            if (user.Id != null)
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("Id", user.Id);
                    var result= (await connection.QueryAsync<Role>("Auth.User_GetUserRole_SP", parameters, commandType: CommandType.StoredProcedure)).ToList();
                    RES.Data = result;

                }
                return RES;
            }
            else
            {
                RES.ResponseHeader.Status = Domain.Enums.ResultType.error;
                RES.ResponseHeader.MessagesList.Add(new Message()
                {
                    MessageCode = "000",
                    MessageDesc = "the Id is null and that not correct"
                });
                return RES;
            }
        }

        public async Task<ReturnResponse<User>> Login(User user)
        {
            var RES = new ReturnResponse<User>();
            RES.Data = new();
            try
            {
              using( var connection= _dapperContext.CreateConnection())
                {
                    var parametars= new DynamicParameters();
                    parametars.Add("Email", user.Email);
                     var result= (await  connection.QueryAsync<User>("Auth.User_Check_Login_SP", parametars, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                    if (result != null) {
                        RES.Data = result;
                    }
                }
            }

            catch (Exception ex) {
            
            }
            return RES;
        }

        public Task<ReturnResponse<User>> Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
