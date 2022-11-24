using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;
using PhoneBook.Repository;

namespace PhoneBook.Service
{
    public class UpdateContactService : IUpdateContactService
    {
        private readonly IRepository _repository;
        public UpdateContactService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task UpdateContact(ContactCreationDto contactDto)
        {
            var contact = new Contact
            {
                Id = contactDto.Id,
                FirstName = contactDto.FirstName.ToUpper(),
                LastName = contactDto.LastName.ToUpper(),
                PhoneNumber = contactDto.PhoneNumber
            };

            await _repository.UpdateContact(contact);
        }
    }
}
