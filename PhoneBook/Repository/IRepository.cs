using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;
using static Dapper.SqlMapper;

namespace PhoneBook.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContact(Guid id);
        Task CreateContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task DeleteContact(Guid id);
    }
}
