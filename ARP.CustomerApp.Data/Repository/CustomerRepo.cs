using ARP.CustomerApp.Data.Interfaces;
using ARP.CustomerApp.Data.Options;
using ARP.CustomerApp.Entity;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARP.CustomerApp.Data.Repository
{
    public class CustomerRepo : BaseRepo, ICustomerRepo
    {
        public CustomerRepo(ILogger<CustomerRepo> logger, IConnectionContext connectionContext) : base(logger, connectionContext) { }

        public async Task<int> CreateAsync(Customer customer)
        {
            return await ExecuteSQLAsync<int>(async (connection) =>
            {
                return await connection.ExecuteScalarAsync<int>("Customer#Create",
                    new
                    {
                        title = customer.Title,
                        firstName = customer.FirstName,
                        surname = customer.Surname,
                        address1 = customer.Address1,
                        address2 = customer.Address2,
                        address3 = customer.Address3,
                        town = customer.Town,
                        county = customer.County,
                        postcode = customer.Postcode
                    },
                    commandType: CommandType.StoredProcedure);
            }, "Create customer failed");
        }

        public async Task UpdateAsync(Customer customer)
        {
            await ExecuteSQLAsync(async (connection) =>
            {
                return await connection.ExecuteScalarAsync("Customer#Update",
                    new
                    {
                        customerID = customer.CustomerID,
                        title = customer.Title,
                        firstName = customer.FirstName,
                        surname = customer.Surname,
                        address1 = customer.Address1,
                        address2 = customer.Address2,
                        address3 = customer.Address3,
                        town = customer.Town,
                        county = customer.County,
                        postcode = customer.Postcode
                    },
                    commandType: CommandType.StoredProcedure);
            }, "Update customer failed");
        }

        public async Task<Customer> GetAsync(int customerID)
        {
            return await ExecuteSQLAsync<Customer>(async (connection) =>
            {
                return await connection.QueryFirstOrDefaultAsync<Customer>("Customer#Get",
                    new { customerID = customerID },
                    commandType: CommandType.StoredProcedure);
            }, "Get customer failed");
        }

        public async Task DeleteAsync(int customerID)
        {
            await ExecuteSQLAsync(async (connection) =>
            {
                await connection.ExecuteAsync("Customer#Delete",
                    new { customerID = customerID },
                    commandType: CommandType.StoredProcedure);
            }, "Delete customer failed");
        }

        public async Task<IEnumerable<Customer>> ListAsync(CustomerSearchOptions searchOptions)
        {
            var sb = new StringBuilder("SELECT * FROM Customer");

            var paramList = new DynamicParameters();

            if (!String.IsNullOrEmpty(searchOptions.Keyword))
            {
                paramList.Add("keyword", $"%{searchOptions.Keyword}%");
                sb.Append(" WHERE FirstName LIKE @keyword");
                sb.Append(" OR Surname LIKE @keyword");
                sb.Append(" OR Address1 LIKE @keyword");
                sb.Append(" OR Address2 LIKE @keyword");
                sb.Append(" OR Address3 LIKE @keyword");
                sb.Append(" OR Town LIKE @keyword");
                sb.Append(" OR County LIKE @keyword");
                sb.Append(" OR Postcode LIKE @keyword");
            }

            return await ExecuteSQLAsync<IEnumerable<Customer>>(async (connection) =>
            {
                return await connection.QueryAsync<Customer>(sb.ToString(), paramList);
            }, "List customers failed");
        }
    }
}
