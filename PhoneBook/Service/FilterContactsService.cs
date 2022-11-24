using PhoneBook.Models.Dtos;
using System.Collections.Generic;
using System.Runtime.Caching;
using MemoryCache = System.Runtime.Caching.MemoryCache;

namespace PhoneBook.Service
{
    public class FilterContactsService : IFilterContactsService
    {
        public List<ContactCreationDto> FilterContacts(string searchString)
        {
            var contacts = (List<ContactCreationDto>)MemoryCache.Default["ContactsList"];

            if (!string.IsNullOrEmpty(searchString))
            {
                var length = searchString.Length;
                var filteredList = new List<ContactCreationDto>();
                foreach (var item in contacts)
                {
                    var substring = item.LastName.Substring(0, length);
                    if(substring.Equals(searchString, StringComparison.OrdinalIgnoreCase))
                    {
                        filteredList.Add(item);
                    }
                }
                return filteredList;
            }

            return contacts;
            //search code for full match
            //string.IsNullOrEmpty(searchString) ? contacts : contacts.Where(x => x.LastName.ToUpper() == searchString.ToUpper()).ToList();
        }
    }
}
