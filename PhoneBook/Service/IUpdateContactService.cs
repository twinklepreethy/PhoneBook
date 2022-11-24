using PhoneBook.Models.Dtos;

namespace PhoneBook.Service
{
    public interface IUpdateContactService
    {
        Task UpdateContact(ContactCreationDto contactDto);
    }
}