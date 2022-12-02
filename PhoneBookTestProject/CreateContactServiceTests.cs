using AutoFixture;
using Moq;
using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;
using PhoneBook.Repository;
using PhoneBook.Service;
using System.Reflection;

namespace PhoneBookTestProject
{
    public class CreateContactServiceTests
    {
        private readonly ICreateContactService _sut;
        private readonly Mock<IRepository<Contact>> _mockRepository = new();
        private readonly Fixture _fixture = new();

        public CreateContactServiceTests()
        {
            _sut = new CreateContactService(_mockRepository.Object);
        }

        [Fact]
        public void CreateContact_DtoObjectNotNull_HappyPath()
        {
            var id = Guid.NewGuid();
            var contactDto = _fixture.Build<ContactCreationDto>()
                                     .With(x => x.Id, id).Create();

            _mockRepository.Setup(x => x.Add(It.IsAny<Contact>())).Callback((Contact contact) =>
            {
                contactDto.LastName = contact.LastName;
                contactDto.FirstName = contact.FirstName;
                contactDto.PhoneNumber = contact.PhoneNumber;
                contactDto.Id = contact.Id;
            });

            _sut.CreateContact(contactDto);

            Assert.NotEqual(id, contactDto.Id);
        }

        [Fact]
        public void CreateContact_DtoObjectNull_Exception()
        {
            ContactCreationDto contactDto = null;

            _mockRepository.Setup(x => x.Add(It.IsAny<Contact>()));

            Assert.ThrowsAsync<TargetInvocationException>(() => _sut.CreateContact(contactDto));
        }
    }
}