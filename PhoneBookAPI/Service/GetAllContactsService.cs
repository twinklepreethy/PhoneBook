using PhoneBookAPI.Repository;

namespace PhoneBookAPI.Service
{
    public class GetAllContactsService : IGetAllContactsService
    {
        private readonly IBaseRepository<Contact> _contactRepository;

        public GetAllContactsService(IBaseRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _contactRepository.GetAll();
        }
    }
}
