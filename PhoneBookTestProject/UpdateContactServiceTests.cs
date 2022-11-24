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
    public class UpdateContactServiceTests
    {
        private readonly IUpdateContactService _sut;
        private readonly Mock<IRepository> _mockRepository = new();
        private readonly Fixture _fixture = new();

        public UpdateContactServiceTests()
        {
            _sut = new UpdateContactService(_mockRepository.Object);
        }

        [Fact]
        public void UpdateContact_DtoObjectNotNull_HappyPath()
        {
            var id = Guid.NewGuid();
            var contactDto = _fixture.Build<ContactCreationDto>()
                                     .With(x => x.Id, id).Create();

            _mockRepository.Setup(x => x.UpdateContact(It.IsAny<Contact>())).Callback((Contact contact) =>
            {
                contactDto.LastName = contact.LastName;
                contactDto.FirstName = contact.FirstName;
                contactDto.PhoneNumber = contact.PhoneNumber;
                contactDto.Id = contact.Id;
            });

            _sut.UpdateContact(contactDto);

            Assert.NotEqual(id, contactDto.Id);
        }

        [Fact]
        public void UpdateContact_DtoObjectNull_Exception()
        {
            ContactCreationDto contactDto = null;

            _mockRepository.Setup(x => x.UpdateContact(It.IsAny<Contact>()));

            Assert.ThrowsAsync<TargetInvocationException>(() => _sut.UpdateContact(contactDto));
        }
    }
}
