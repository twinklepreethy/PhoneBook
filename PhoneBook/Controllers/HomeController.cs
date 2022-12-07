using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;
using PhoneBook.Repository;
using PhoneBook.Service;
using System.Diagnostics;

namespace PhoneBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICreateContactService _createContactService;
        private readonly IGetAllContactsService _getAllContactsService;
        private readonly IUpdateContactService _updateContactService;
        private readonly IDeleteContactService _deleteContactService;
        private readonly IGetContactService _getContactService;
        private readonly IFilterContactsService _filterContactsService;
        private List<ContactCreationDto> ContactsList;

        public HomeController(ILogger<HomeController> logger, ICreateContactService createContactService, IGetAllContactsService getAllContactsService, IUpdateContactService updateContactService, IDeleteContactService deleteContactService, IGetContactService getContactService, IFilterContactsService filterContactsService)
        {
            _createContactService = createContactService;
            _getAllContactsService = getAllContactsService;
            _updateContactService = updateContactService;
            _deleteContactService = deleteContactService;
            _getContactService = getContactService;
            _filterContactsService = filterContactsService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                //var contactsList = await _getAllContactsService.GetAllContacts();
                //var contactModel = new ContactListModel
                //{
                //    Contacts = new List<ContactCreationDto>
                //    {
                //        new ContactCreationDto
                //        {
                //            FirstName = "tt",
                //            LastName = "gg",
                //            PhoneNumber = "ff"
                //        }
                //    }//contactsList.ToList()
                //};

                return View();
            }
            catch (Exception ex)
            {
                var errorMessage = "Problem in retrieving contacts. Please try again later";
                _logger.LogError(ex, errorMessage);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> FilteredList(ContactListModel contactModel)
        {
            contactModel.Contacts = new List<ContactCreationDto>();
            contactModel.Contacts = _filterContactsService.FilterContacts(contactModel.SearchString);

            return View("Index", contactModel);
        }

        public async Task<IActionResult> AddContact()
        {
            return PartialView("_AddContact");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(Guid currentContactID)
        {
            var contactCreationDto = new ContactCreationDto
            {
                Id = currentContactID
            };

            return PartialView("_AddContact", contactCreationDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromForm]ContactCreationDto contactDto)
        {
            try
            {
                if (contactDto.IsUpdate)
                {
                    await _updateContactService.UpdateContact(contactDto);
                }
                else
                {
                    await _createContactService.CreateContact(contactDto);
                }

                var contactsList = await _getAllContactsService.GetAllContacts();

                var contactModel = new ContactListModel
                {
                    Contacts = contactsList.ToList()
                };

                return View("Index", contactModel);
            }
            catch (Exception ex)
            {
                var errorMessage = "Problem in creating contact. Please try again later";
                _logger.LogError(ex, errorMessage);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteContact([FromForm]ContactListModel contact)
        {
            try
            {
                await _deleteContactService.DeleteContact(new ContactCreationDto()); //get this in js

                var contactsList = await _getAllContactsService.GetAllContacts();

                var contactModel = new ContactListModel
                {
                    Contacts = contactsList.ToList(),
                    CurrentContactId = Guid.Empty
                };

                return View("Index", contactModel);
            }
            catch (Exception ex)
            {
                var errorMessage = "Problem in deleting contact. Please try again later";
                _logger.LogError(ex, errorMessage);
                throw;
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}