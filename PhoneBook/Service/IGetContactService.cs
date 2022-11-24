using PhoneBook.Models.Dtos;

namespace PhoneBook.Service
{
    public interface IGetContactService
    {
        Task<ContactCreationDto> GetContact(Guid Id);
    }
}