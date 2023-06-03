using System.Data;
using Microsoft.Data.SqlClient;

namespace MediatorWebApp.Core
{
    public  class DapperContext
    {
        //private readonly IConfiguration _configuration;
        //private readonly string _connectionString;
        public DapperContext()
        {
            //_configuration = configuration;
            //_connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Mediator;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}
