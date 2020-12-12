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
                              FROM [dbo].[User]
                              WHERE Email = @Email AND Password = @Password";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.QueryFirstOrDefault<User>(query, user);
        }
    }
}
