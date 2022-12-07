using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookAPI.Service;

namespace PhoneBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IGetAllContactsService _getAllContactsService;
        private readonly IGetContactService _getContactService;
        private readonly IAddContactService _addContactService;
        private readonly IUpdateContactService _updateContactService;
        private readonly IDeleteContactService _deleteContactService;

        public ContactsController(IGetAllContactsService getAllContactsService, IGetContactService getContactService, IAddContactService addContactService, IUpdateContactService updateContactService, IDeleteContactService deleteContactService)
        {
            _getAllContactsService = getAllContactsService;
            _getContactService = getContactService;
            _addContactService = addContactService;
            _updateContactService = updateContactService;
            _deleteContactService = deleteContactService;
        }

        [HttpGet]
        public async Task<List<Contact>> GetAllContacts()
        {
            return await _getAllContactsService.GetAllContacts();
        }

        //[HttpGet("{id}")]
        //public async Task<Contact> GetContact(Guid Id)
        //{
        //    return;
        //}

        [HttpPost]
        public async Task AddContacts(Contact contact)
        {
            await _addContactService.AddContact(contact);
        }

        [HttpPut]
        public async Task UpdateContac(Contact contact)
        {

        }

        [HttpDelete("{id}")]
        public async Task DeleteContact(Guid id)
        {
            await _deleteContactService.DeleteContact(id);
        }
    }
}
