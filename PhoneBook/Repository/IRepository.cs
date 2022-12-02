using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;
using static Dapper.SqlMapper;

namespace PhoneBook.Repository
{
    public interface IRepository<T> where T : TEntity
    {
        //Task<IEnumerable<Contact>> GetAllContacts();
        //Task<Contact> GetContact(Guid id);
        //Task CreateContact(Contact contact);
        //Task UpdateContact(Contact contact);
        //Task DeleteContact(Guid id);

        Task<T> Add(T entity);
        Task<IEnumerable<T>> GetAll(string query, object parameters = null);
        Task<T> Get(string query, object parameters = null);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
