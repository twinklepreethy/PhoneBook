using AutoFixture;
using Moq;
using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;
using PhoneBook.Repository;
using PhoneBook.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestProject
{
    public class GetContactServiceTests
    {
        private readonly IGetContactService _sut;
        private readonly Mock<IRepository> _mockRepository = new();
        private readonly Fixture _fixture = new();

        public GetContactServiceTests()
        {
            _sut = new GetContactService(_mockRepository.Object);
        }

        [Fact]
        public void GetContact_ContactFromDB_NotNull_HappyPath()
        {
            var contact = _fixture.Build<Contact>().Create();
            _mockRepository.Setup(x => x.GetContact(It.IsAny<Guid>())).ReturnsAsync(contact);

            var result = _sut.GetContact(It.IsAny<Guid>());

            Assert.NotNull(result.Result);
            Assert.Equal(contact.Id, result.Result.Id);
        }

        [Fact]
        public void GetContact_ContactFromDB_Null_Exception()
        {
            Contact contact = null;

            _mockRepository.Setup(x => x.GetContact(It.IsAny<Guid>())).ReturnsAsync(contact);

            Assert.ThrowsAsync<TargetInvocationException>(() => _sut.GetContact(It.IsAny<Guid>()));
        }
    }
}
