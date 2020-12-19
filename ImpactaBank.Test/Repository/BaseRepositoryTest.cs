using AutoFixture;
using ImpactaBank.API.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpactaBank.Test.Repository
{
    public class BaseRepositoryTest
    {
        protected readonly Fixture _fixture;
        protected readonly BaseRepository _baseRepository;

        public BaseRepositoryTest()
        {
            _fixture = new Fixture();
            _baseRepository = _fixture.Create<BaseRepository>();
        }
    }
}
