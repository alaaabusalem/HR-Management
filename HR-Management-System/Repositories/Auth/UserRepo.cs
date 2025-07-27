using Dapper;
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
        public ReturnResponse<User> Add(User item)
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
                    parameters.Add("Id", item.Id, DbType.Guid, ParameterDirection.Output);
                    parameters.Add("ProcessStatus", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    parameters.Add("StatusDesc", dbType: DbType.String, size: int.MaxValue, direction: ParameterDirection.Output);
                    parameters.Add("StatusCode", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);
                    var response = connection.Execute("Auth.User_Insert_SP", parameters, commandType: CommandType.StoredProcedure);

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
             using(var connection = _dapperContext.CreateConnection())
                {

                    DynamicParameters parameters= new DynamicParameters();
                    parameters.Add("Id", item.Id);
                    parameters.Add("Email", item.Email);
                    parameters.Add("Name", item.Name);
                    parameters.Add("ProcessStatus",DbType.Boolean,direction:ParameterDirection.Output);
                    parameters.Add("StatusDesc",dbType: DbType.String, size: 50, direction: ParameterDirection.Input);
                    parameters.Add("StatusCode", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);
                    var result = connection.Query<User>("", parameters, commandType: CommandType.StoredProcedure);
                    if (parameters.Get<bool>("@ProcessStatus")== false)
                    {
                        RES.ResponseHeader.Status = Domain.Enums.ResultType.error;
                        RES.ResponseHeader.MessagesList.Add(new Message()
                        {
                            MessageDesc=parameters.Get<string>("@StatusDesc"),
                            MessageCode= parameters.Get<string>("@StatusCode"), 
                        });
                    }
                }
            }

            catch (Exception ex) { 

            }
                throw new NotImplementedException();
        }

        public ReturnResponse<List<User>> GetDataList(User item)
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
                   
                    var result = connection.Query<User>("Auth.User_Get_SP", parameters, commandType: CommandType.StoredProcedure).ToList();
                    
                    
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

        public ReturnResponse<User> Login(User user)
        {
            throw new NotImplementedException();
        }

        public ReturnResponse<User> Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
