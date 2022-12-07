using PhoneBookAPI.Repository;

namespace PhoneBookAPI.Service
{
    public class DeleteContactService : IDeleteContactService
    {
        private readonly IBaseRepository<Contact> _contactRepository;

        public DeleteContactService(IBaseRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task DeleteContact(Guid id)
        {
           await _contactRepository.Delete(id);
        }
    }
}
