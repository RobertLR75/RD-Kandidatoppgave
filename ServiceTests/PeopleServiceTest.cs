using Moq;
using System;
using Repository.Abstractions;
using Service;
using Service.Endpoints;
using Service.Requests;
using Service.Responses;
using ServiceStack;
using Xunit;
using Xunit.Abstractions;

namespace ServiceTest
{
    public class PeopleServiceTest : TestBase
    {

        public PeopleServiceTest(ITestOutputHelper output) : base(output)
        {
            PeopleRepositoryMock = new Mock<IPeopleRepository>();
            PeopleService = new PeopleService(PeopleRepositoryMock.Object, Logger, Cache);
        }

        private Mock<IPeopleRepository> PeopleRepositoryMock { get; }
        private PeopleService PeopleService { get; }
        [Fact]
        public void Return_OK_Result_With_Person ()
        {
            var expected = new People {Id = 1};

            PeopleRepositoryMock.Setup(x => x.Get(1)).Returns(expected);
            var actual = PeopleService.Get(new PersonRequest {Id = 1});
            Assert.NotNull(actual);
            Assert.Equal(expected.Id, actual.Id);
        }

        [Fact]
        public void Throw_HttpError_When_Person_Not_Found()
        {
            IPeople expected = null;

            PeopleRepositoryMock.Setup(x => x.Get(1)).Returns(expected);
            Assert.Throws<HttpError>(() => PeopleService.Get(new PersonRequest { Id = 1 }));
        }
    }
}
