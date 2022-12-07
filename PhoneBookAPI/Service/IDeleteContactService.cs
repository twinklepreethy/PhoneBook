namespace PhoneBookAPI.Service
{
    public interface IDeleteContactService
    {
        Task DeleteContact(Guid id);
    }
}