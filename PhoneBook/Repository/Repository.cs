using Dapper;
using PhoneBook.Context;
using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;
using System.Data;
using static Dapper.SqlMapper;

namespace PhoneBook.Repository
{
    public class Repository : IRepository
    {
        private readonly DapperContext _context;

        public Repository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            var query = "SELECT * FROM Contacts";

            using (var connection = _context.CreateConnection())
            {
                var contacts = await connection.QueryAsync<Contact>(query);
                return contacts.ToList();
            }
        }

        public async Task<Contact> GetContact(Guid id)
        {
            var query = "SELECT * FROM Contacts WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var contact = await connection.QuerySingleOrDefaultAsync<Contact>(query, new { id });

                return contact;
            }
        }

        public async Task CreateContact(Contact contact)
        {
            var query = "INSERT INTO Contacts (FirstName, LastName, PhoneNumber) VALUES (@FirstName, @LastName, @PhoneNumber)";

            var parameters = new DynamicParameters();
            parameters.Add("FirstName", contact.FirstName, DbType.String);
            parameters.Add("LastName", contact.LastName, DbType.String);
            parameters.Add("PhoneNumber", contact.PhoneNumber, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteContact(Guid id)
        {
            var query = "DELETE FROM Contacts WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync<Contact>(query, new { id });
            }
        }

        public async Task UpdateContact(Contact contact)
        {
            var query = "UPDATE Contacts SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("FirstName", contact.FirstName, DbType.String);
            parameters.Add("LastName", contact.LastName, DbType.String);
            parameters.Add("PhoneNumber", contact.PhoneNumber, DbType.String);
            parameters.Add("Id", contact.Id, DbType.Guid);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
