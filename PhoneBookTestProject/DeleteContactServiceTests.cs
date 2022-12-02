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
    public class DeleteContactServiceTests
    {
        private readonly IDeleteContactService _sut;
        private readonly Mock<IRepository<Contact>> _mockRepository = new();
        private readonly Fixture _fixture = new();

        public DeleteContactServiceTests()
        {
            _sut = new DeleteContactService(_mockRepository.Object);
        }

        [Fact]
        public void DeleteContact_HappyPath()
        {
            Guid id = Guid.Empty;
            _mockRepository.Setup(x => x.Delete(It.IsAny<Contact>())).Callback((Guid contactId) =>
            {
                id = Guid.NewGuid();
            });

            _sut.DeleteContact(new ContactCreationDto());

            Assert.NotEqual(Guid.Empty, id);
        }
    }
}
