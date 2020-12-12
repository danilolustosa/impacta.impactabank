using AutoFixture;
using ImpactaBank.API.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpactaBank.Test.Service
{
    public class BaseServiceTest
    {
        protected readonly Fixture _fixture;
        protected readonly BaseResponse _baseResponse;

        public BaseServiceTest()
        {
            _fixture = new Fixture();
            _baseResponse = _fixture.Create<BaseResponse>();
        }
    }
}
