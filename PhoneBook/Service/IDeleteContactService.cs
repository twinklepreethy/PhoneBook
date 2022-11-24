namespace PhoneBook.Service
{
    public interface IDeleteContactService
    {
        Task DeleteContact(Guid Id);
    }
}