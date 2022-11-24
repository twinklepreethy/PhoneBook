using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;

namespace PhoneBook.Models
{
    public class ContactListModel
    {
        public Guid CurrentContactId { get; set; }
        public string SearchString { get; set; }
        public List<ContactCreationDto> Contacts { get; set; }
    }
}
