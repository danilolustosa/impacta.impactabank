using ImpactaBank.API.Domain;
using ImpactaBank.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace ImpactaBank.API.Repository
{
    public class UserRepository : BaseRepository,IUserRepository
    {
        public User Get(User user)
        {
            string query = @"SELECT [Id]
                                  ,[Email]
                                  ,[Password]
                                  ,[Role]
                              FROM [dbo].[User]
                              WHERE Email = @Email AND Password = @Password";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.QueryFirstOrDefault<User>(query, user);
        }

        public int Insert(User user)
        {
            string query = @"INSERT INTO [dbo].[User]
                                   ([Email]
                                   ,[Password]
                                   ,[Role])
                             output INSERTED.Id VALUES
                                   (@Email
                                   ,@Password
                                   ,@Role)";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.ExecuteScalar<int>(query, user);
        }
    }
}
