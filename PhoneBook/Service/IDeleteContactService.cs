using PhoneBook.Models.Dtos;

namespace PhoneBook.Service
{
    public interface IDeleteContactService
    {
        Task DeleteContact(ContactCreationDto contactCreationDto);
    }
}