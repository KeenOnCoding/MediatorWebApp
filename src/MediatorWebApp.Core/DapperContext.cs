using System.Data;
using Microsoft.Data.SqlClient;

namespace MediatorWebApp.Core
{
    public  class DapperContext
    {
        //private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(string connectionString)
        {
            //_configuration = configuration;
            _connectionString = connectionString;
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
