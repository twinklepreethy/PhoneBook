using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;
using PhoneBook.Repository;

namespace PhoneBook.Service
{
    public class GetContactService : IGetContactService
    {
        private readonly IRepository _repository;
        public GetContactService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ContactCreationDto> GetContact(Guid Id)
        {
            var contact = await _repository.GetContact(Id);

            var contactCreationDto = new ContactCreationDto
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                PhoneNumber = contact.PhoneNumber
            };

            return contactCreationDto;
        }
    }
}
