using System.ComponentModel;

namespace PhoneBook.Models.Dtos
{
    public class ContactCreationDto
    {
        public Guid Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public bool IsUpdate { get; set; }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
