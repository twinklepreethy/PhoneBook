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
    public class GetAllContactsServiceTests
    {
        private readonly IGetAllContactsService _sut;
        private readonly Mock<IRepository> _mockRepository = new();
        private readonly Fixture _fixture = new();

        public GetAllContactsServiceTests()
        {
            _sut = new GetAllContactsService(_mockRepository.Object);
        }

        [Fact]
        public void GetAllContacts_HappyPath()
        {
            var contact1 = _fixture.Build<Contact>().Create();
            var contact2 = _fixture.Build<Contact>().Create();
            var contact3 = _fixture.Build<Contact>().Create();
            var contactCreationDtoList = new List<Contact> { contact1, contact2, contact3 };

            _mockRepository.Setup(x => x.GetAllContacts()).ReturnsAsync(contactCreationDtoList);

            var result = _sut.GetAllContacts();

            Assert.Equal(3, result.Result.Count());
            Assert.Equal(contact1.Id, result.Result.First().Id);
            Assert.Equal(contact3.Id, result.Result.Last().Id);
        }
    }
}
