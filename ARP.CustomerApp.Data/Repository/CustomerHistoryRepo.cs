using ARP.CustomerApp.Data.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Threading.Tasks;

namespace ARP.CustomerApp.Data.Repository
{
    public class CustomerHistoryRepo : BaseRepo, ICustomerHistoryRepo
    {
        public CustomerHistoryRepo(ILogger<CustomerHistoryRepo> logger, IConnectionContext connectionContext) : base(logger, connectionContext) { }

        public async Task<int> CreateAsync(int customerID, DateTime editDate)
        {
            return await ExecuteSQLAsync<int>(async (connection) =>
            {
                return await connection.ExecuteScalarAsync<int>("CustomerHistory#Create",
                    new { customerID = customerID, editDate = editDate },
                    commandType: CommandType.StoredProcedure);

            }, "Customer history create failed");
        }

        public async Task DeleteForCustomerAsync(int customerID)
        {
            await ExecuteSQLAsync(async (connection) =>
            {
                return await connection.ExecuteAsync("CustomerHistory#DeleteForCustomer",
                    new { customerID = customerID },
                    commandType: CommandType.StoredProcedure);
            }, "Customer history deletion failed");
        }

    }
}
