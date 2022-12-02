using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;
using PhoneBook.Repository;

namespace PhoneBook.Service
{
    public class DeleteContactService : IDeleteContactService
    {
        private readonly IRepository<Contact> _repository;
        public DeleteContactService(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task DeleteContact(ContactCreationDto contactCreationDto)
        {
            await _repository.Delete(contactCreationDto.ConvertToDBObject);
        }
    }
}
