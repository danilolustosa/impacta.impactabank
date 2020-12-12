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
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public int Insert(Account account)
        {
            string query = @"INSERT INTO [dbo].[Account]
                                   ([Hash]
                                   ,[CustomerId]
                                   ,[Situation])
                             output INSERTED.Id VALUES
                                   (@Hash
                                   ,@CustomerId
                                   ,@Situation)";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.ExecuteScalar<int>(query, account);
        }

        public Account Get(int Id)
        {
            string query = @"SELECT [Id]
                                  ,[Hash]
                                  ,[CustomerId]
                                  ,[Situation]
                              FROM[dbo].[Account]
                              WHERE Id = @Id";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.QueryFirstOrDefault<Account>(query, new { Id });
        }

        public void Update(Account account)
        {
            string query = @"UPDATE [dbo].[Account]
                               SET [CustomerId] = @CustomerId
                                  ,[Situation] = @Situation
                             WHERE Id = @Id";

            var con = new SqlConnection(_connectionString);
            con.Open();
            con.ExecuteScalar(query, account);

        }

        public void UpdateSituation(Account account)
        {
            string query = @"UPDATE [dbo].[Account]
                               SET [Situation] = @Situation
                             WHERE Id = @Id";

            var con = new SqlConnection(_connectionString);
            con.Open();
            con.ExecuteScalar(query, account);

        }
    }
}
