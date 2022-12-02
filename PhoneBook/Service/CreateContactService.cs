using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;
using PhoneBook.Repository;

namespace PhoneBook.Service
{
    public class CreateContactService : ICreateContactService
    {
        private readonly IRepository<Contact> _repository;
        public CreateContactService(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task CreateContact(ContactCreationDto contactDto)
        {
            await _repository.Add(contactDto.ConvertToDBObject);
        }
    }
}
