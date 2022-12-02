using System.Data.SqlClient;
using System.Data;

namespace PhoneBook.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection"); //move this to program.cs
        }

        public async Task<IDbConnection> CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
