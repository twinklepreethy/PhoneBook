using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Caching.Memory;
using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;
using PhoneBook.Repository;
using System.Runtime.Caching;
using MemoryCache = System.Runtime.Caching.MemoryCache;

namespace PhoneBook.Service
{
    public class GetAllContactsService : IGetAllContactsService
    {
        private readonly IRepository _repository;
        public GetAllContactsService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ContactCreationDto>> GetAllContacts()
        {
            var contactCreationDtoList = new List<ContactCreationDto>();
            var contactsList = await _repository.GetAllContacts();
            foreach (var contact in contactsList)
            {
                contactCreationDtoList.Add(new ContactCreationDto
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    PhoneNumber = contact.PhoneNumber
                });
            }
            contactCreationDtoList.OrderBy(x => x.LastName);
            var expiration = 1;

            var policy = new CacheItemPolicy
            {
                Priority = System.Runtime.Caching.CacheItemPriority.NotRemovable,
                AbsoluteExpiration = DateTimeOffset.Now.AddHours(expiration)
            };

            MemoryCache.Default.Set("ContactsList", contactCreationDtoList, policy);
            return contactCreationDtoList;
        }
    }
}
