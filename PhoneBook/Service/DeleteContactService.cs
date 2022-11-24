using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;
using PhoneBook.Repository;

namespace PhoneBook.Service
{
    public class DeleteContactService : IDeleteContactService
    {
        private readonly IRepository _repository;
        public DeleteContactService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteContact(Guid Id)
        {
            await _repository.DeleteContact(Id);
        }
    }
}
