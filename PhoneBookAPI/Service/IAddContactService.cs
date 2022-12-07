namespace PhoneBookAPI.Service
{
    public interface IAddContactService
    {
        Task AddContact(Contact contact);
    }
}