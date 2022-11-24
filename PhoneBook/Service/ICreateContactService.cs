using PhoneBook.Models.Dtos;

namespace PhoneBook.Service
{
    public interface ICreateContactService
    {
        Task CreateContact(ContactCreationDto contactDto);
    }
}