using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;
using PhoneBook.Repository;

namespace PhoneBook.Service
{
    public class CreateContactService : ICreateContactService
    {
        private readonly IRepository _repository;
        public CreateContactService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateContact(ContactCreationDto contactDto)
        {
            var contact = new Contact
            {
                FirstName = contactDto.FirstName.ToUpper(),
                LastName = contactDto.LastName.ToUpper(),
                PhoneNumber = contactDto.PhoneNumber
            };

            await _repository.CreateContact(contact);
        }
    }
}
