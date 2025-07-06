using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories._Helpers
{
    public class DapperContext
    {

        public IConfiguration _Configuration;
        public string? connctionString;
        public DapperContext(IConfiguration config)
        {
           _Configuration = config; 
        }

        public IDbConnection? CreateConnection()
        {
            try
            {
                connctionString = _Configuration.GetConnectionString("Default");

                return new SqlConnection(connctionString);
                    }
            catch {
                return null;
            }

        }
    }
}
