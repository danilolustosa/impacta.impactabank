using ImpactaBank.API.Controllers;
using ImpactaBank.API.Interface;
using ImpactaBank.API.Model.Request;
using AutoFixture;
using Xunit;
using Microsoft.AspNetCore.Http;
using FluentAssertions;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;

namespace ImpactaBank.Test.Controller
{
    public class UserControllerTest : BaseControllerTest
    {
        IUserService _service;
        UserRequest _request;
        UserController _controller;
        string _email;
        string _password;

        public UserControllerTest()
        {
            _service = Substitute.For<IUserService>();
            _request = _fixture.Create<UserRequest>();
            _controller = new UserController(_service);
            _email = _fixture.Create<string>();
            _password = _fixture.Create<string>();
        }

        [Fact]
        public void Login_User_ShouldBe200OK()
        {
            _service.Login(_email, _password).Returns(_baseResponse);
            _baseResponse.StatusCode = StatusCodes.Status200OK;

            var result = (ObjectResult)_controller.Login(_email, _password);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            
        }
    }
}
