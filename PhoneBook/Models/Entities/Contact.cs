using Dapper.Contrib.Extensions;

namespace PhoneBook.Models.Entities
{
    [Table("Contacts")]
    public class Contact : TEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}