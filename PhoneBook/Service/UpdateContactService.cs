using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;
using PhoneBook.Repository;

namespace PhoneBook.Service
{
    public class UpdateContactService : IUpdateContactService
    {
        private readonly IRepository<Contact> _repository;
        public UpdateContactService(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task UpdateContact(ContactCreationDto contactDto)
        {
            await _repository.Update(contactDto.ConvertToDBObject);
        }
    }
}
