using PhoneBookAPI.Repository;

namespace PhoneBookAPI.Service
{
    public class AddContactService : IAddContactService
    {
        private readonly IBaseRepository<Contact> _contactRepository;
        public AddContactService(IBaseRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task AddContact(Contact contact)
        {
            await _contactRepository.Add(contact);
        }
    }
}
