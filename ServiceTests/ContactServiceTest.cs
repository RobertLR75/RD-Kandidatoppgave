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
    public class ContactServiceTest : TestBase
    {

        public ContactServiceTest(ITestOutputHelper output) : base(output)
        {
            PeopleRepositoryMock = new Mock<IPeopleRepository>();
            ContactService = new ContactService(PeopleRepositoryMock.Object, Logger, Cache);
        }

        private Mock<IPeopleRepository> PeopleRepositoryMock { get; }
        private ContactService ContactService { get; }

        [Fact]
        public void Return_OK_Result_With_Contacts ()
        {
            var expected = new People {Id = 1};
            expected.Contacts.Add(new People{Id = 2});
            expected.Contacts.Add(new People { Id = 3 });
            PeopleRepositoryMock.Setup(x => x.Get(1)).Returns(expected);
            var actual = ContactService.Get(new ContactRequest {Id = 1});
            Assert.NotNull(actual);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Contacts.Count, actual.Contacts.Count);
        }
    }
}
