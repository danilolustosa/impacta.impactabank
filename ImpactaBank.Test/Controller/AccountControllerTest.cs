using ImpactaBank.API.Controllers;
using ImpactaBank.API.Interface;
using ImpactaBank.API.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using Xunit;
using Microsoft.AspNetCore.Http;
using FluentAssertions;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;


namespace ImpactaBank.Test.Controller
{
    public class AccountControllerTest : BaseControllerTest
    {
        IAccountService _service;
        AccountController _controller;
        AccountRequest _request;
        int _id;
        AccountSituationRequest _requestSituation;

        public AccountControllerTest()
        {
            _service = Substitute.For<IAccountService>();
            _controller = new AccountController(_service);
            _request = _fixture.Create<AccountRequest>();
            _id = _fixture.Create<int>();
            _requestSituation = _fixture.Create<AccountSituationRequest>();
        }

        [Fact]
        public void Insert_ShouldBe201Created()
        {
            _service.Insert(_request).Returns(_baseResponse);
            _baseResponse.StatusCode = StatusCodes.Status201Created;

            var result = (ObjectResult)_controller.Insert(_request);
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
        }

        [Fact]
        public void Update_ShouldBe200OK()
        {
            _service.Update(_id, _request).Returns(_baseResponse);
            _baseResponse.StatusCode = StatusCodes.Status200OK;

            var result = (ObjectResult)_controller.Update(_id, _request);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public void UpdateSituation_ShouldBe200OK()
        {
            _service.UpdateSituation(_id, _requestSituation).Returns(_baseResponse);
            _baseResponse.StatusCode = StatusCodes.Status200OK;

            var result = (ObjectResult)_controller.UpdateSituation(_id, _requestSituation);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

    }
}
