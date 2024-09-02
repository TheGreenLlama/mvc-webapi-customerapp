using ARP.CustomerApp.Data.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ARP.CustomerApp.Data
{
    public class SQLConnectionContext(string connectionString) : IConnectionContext
    {
        private readonly string _connectionString = connectionString;

        public IDbConnection Connect() => new SqlConnection(_connectionString);
    }
}
