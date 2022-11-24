using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;

namespace PhoneBook.Service
{
    public interface IGetAllContactsService
    {
        Task<IEnumerable<ContactCreationDto>> GetAllContacts();
    }
}