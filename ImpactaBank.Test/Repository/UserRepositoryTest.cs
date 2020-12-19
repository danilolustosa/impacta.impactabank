using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using ImpactaBank.API.Domain;
using ImpactaBank.API.Repository;
using AutoFixture;
using Xunit;
using Microsoft.AspNetCore.Http;
using FluentAssertions;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;

namespace ImpactaBank.Test.Repository
{
    public class UserRepositoryTest : BaseRepositoryTest
    {
        SqlConnection _sqlConnection;
        User _user;
        UserRepository _repository;

        public UserRepositoryTest()
        {
            //_sqlConnection = new SqlConnection(this._baseRepository._connectionString);
            //_user = _fixture.Create<User>();
            //_repository = new UserRepository();
        }

        [Fact]
        public void Insert_ShouldHasUser()
        {
            //_sqlConnection.Open();
            //_sqlConnection.ExecuteScalar<int>("").Returns<int>(1);
            //
            //var result = _repository.Insert(_user);
            //result.Should().BePositive();
        }
    }
}
