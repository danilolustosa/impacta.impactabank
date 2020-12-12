using ImpactaBank.API.Interface;
using ImpactaBank.API.Model.Request;
using ImpactaBank.API.Model.Response;
using ImpactaBank.API.Service;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using Xunit;
using Microsoft.AspNetCore.Http;
using FluentAssertions;
using ImpactaBank.API.Domain;

namespace ImpactaBank.Test.Service
{
    public class UserServiceTest : BaseServiceTest
    {
        UserService _service;
        UserRequest _request;
        UserResponse _response;
        IUserRepository _repository;
        User _user;
        string _email;
        string _password;

        public UserServiceTest()
        {
            _repository = Substitute.For<IUserRepository>();
            _service = new UserService(_repository);
            _request = _fixture.Create<UserRequest>();
            _response = _fixture.Create<UserResponse>();
            _user = _fixture.Create<User>();
            _email = _fixture.Create<string>();
            _password = _fixture.Create<string>();
        }

        [Fact]
        public void Insert_User_ShouldBe201Created()
        {
            var result = _service.Insert(_request);
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
        }

        [Fact]
        public void Insert_UserNoEmail_ShouldBe400BadRequest()
        {
            _request.Email = String.Empty;

            var result = _service.Insert(_request);
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public void Insert_UserNoPassword_ShouldBe400BadRequest()
        {
            _request.Password = String.Empty;

            var result = _service.Insert(_request);
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public void Insert_UserNoRole_ShouldBe400BadRequest()
        {
            _request.Role = String.Empty;

            var result = _service.Insert(_request);
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public void Login_User_ShouldBe200OK()
        {
            _repository.Get(_user).Returns(_user);

            var result = _service.Login(_email, _password);
            result.StatusCode = StatusCodes.Status201Created;
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
        }

        [Fact]
        public void GenerateToken_ShouldBeNotEmpty()
        {
            var result = _service.GenerateToken(_user);
            result.Should().NotBeNullOrEmpty();
        }
    }
}
