using ImpactaBank.API.Domain;
using ImpactaBank.API.Interface;
using ImpactaBank.API.Model.Request;
using ImpactaBank.API.Service;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using ImpactaBank.API.Model.Response;

namespace ImpactaBank.Test.Service
{
    public class AccountServiceTest : BaseServiceTest
    {
        AccountService _service;
        AccountRequest _request;
        IAccountRepository _repository;
        Account _account;
        int _id;
        AccountResponse _response;
        AccountSituationRequest _requestSituation;

        public AccountServiceTest()
        {
            _repository = Substitute.For<IAccountRepository>();
            _service = new AccountService(_repository);
            _account = _fixture.Create<Account>();
            _request = _fixture.Create<AccountRequest>();
            _id = _fixture.Create<int>();
            _response = _fixture.Create<AccountResponse>();
            _requestSituation = _fixture.Create<AccountSituationRequest>();
        }

        [Fact]
        public void Insert_Account_ShouldBe201Created()
        {
            var result = _service.Insert(_request);
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
        }

        [Fact]
        public void Insert_CustomerIsEmpty_ShouldBe400BadRequest()
        {
            _request.CustomerId = 0;
            var result = _service.Insert(_request);
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public void Insert_SituationIsEmpty_ShouldBe400BadRequest()
        {
            _request.Situation = String.Empty;
            var result = _service.Insert(_request);
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public void Update_Account_ShouldBe200OK()
        {
            _repository.Get(_id).Returns(_account);

            _request.Hash = String.Empty;
            var result = _service.Update(_id,_request);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public void Update_CustomerIsEmpty_ShouldBe400BadRequest()
        {
            _request.Hash = String.Empty;
            _request.CustomerId = 0;
            var result = _service.Update(_id,_request);
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public void Update_SituationIsEmpty_ShouldBe400BadRequest()
        {
            _request.Hash = String.Empty;
            _request.Situation = String.Empty;
            var result = _service.Update(_id, _request);
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public void Update_HashNotIsEmpty_ShouldBe400BadRequest()
        {
            var result = _service.Update(_id, _request);
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }



        [Fact]
        public void UpdateSituation_Account_ShouldBe200OK()
        {
            _repository.Get(_id).Returns(_account);

            var result = _service.UpdateSituation(_id, _requestSituation);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public void UpdateSituation_SituationIsEmpty_ShouldBe400BadRequest()
        {
            _requestSituation.Situation = String.Empty;
            var result = _service.UpdateSituation(_id, _requestSituation);
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

    }
}
