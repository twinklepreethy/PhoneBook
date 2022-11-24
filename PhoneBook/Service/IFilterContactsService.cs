using PhoneBook.Models.Dtos;

namespace PhoneBook.Service
{
    public interface IFilterContactsService
    {
        List<ContactCreationDto> FilterContacts(string searchString);
    }
}