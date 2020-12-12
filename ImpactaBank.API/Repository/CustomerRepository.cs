using ImpactaBank.API.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ImpactaBank.API.Interface;

namespace ImpactaBank.API.Repository
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public int Insert(Customer customer)
        {
            string query = @"INSERT INTO [dbo].[Customer]
                                   ([Name]
                                   ,[Age])
                             output INSERTED.Id VALUES
                                   (@Name
                                   ,@Age)";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.ExecuteScalar<int>(query, new { customer.Name, customer.Age });
        }

        public Customer Get(int Id)
        {
            string query = @"SELECT [Id]
                              ,[Name]
                              ,[Age]
                          FROM [dbo].[Customer]
                          WHERE Id = @Id";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.QueryFirstOrDefault<Customer>(query, new { Id });
        }

        public List<Customer> List()
        {
            string query = @"SELECT [Id]
                              ,[Name]
                              ,[Age]
                          FROM [dbo].[Customer]";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.Query<Customer>(query).ToList();
        }
    }
}
