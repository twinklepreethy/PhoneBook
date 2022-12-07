namespace PhoneBookAPI.Service
{
    public interface IGetAllContactsService
    {
        Task<List<Contact>> GetAllContacts();
    }
}