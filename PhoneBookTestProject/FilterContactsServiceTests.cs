using AutoFixture;
using Moq;
using PhoneBook.Models.Dtos;
using PhoneBook.Models.Entities;
using PhoneBook.Repository;
using PhoneBook.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using MemoryCache = System.Runtime.Caching.MemoryCache;

namespace PhoneBookTestProject
{
    public class FilterContactsServiceTests
    {
        private readonly IFilterContactsService _sut;
        private readonly Fixture _fixture = new();

        public FilterContactsServiceTests()
        {
            _sut = new FilterContactsService();
        }

        public CacheItemPolicy Policy()
        {
            var expiration = 1;

            return new CacheItemPolicy
            {
                Priority = System.Runtime.Caching.CacheItemPriority.NotRemovable,
                AbsoluteExpiration = DateTimeOffset.Now.AddHours(expiration)
            };
        }

        [Fact]
        public void FilterContacts_SearchStringEmpty_UnfilteredList()
        {
            var contact1 = _fixture.Build<ContactCreationDto>()
                                   .With(x => x.LastName, "John").Create();
            var contact2 = _fixture.Build<ContactCreationDto>()
                                   .With(x => x.LastName, "Adam").Create();
            var contact3 = _fixture.Build<ContactCreationDto>()
                                   .With(x => x.LastName, "Mary").Create();
            var contactCreationDtoList = new List<ContactCreationDto> { contact1, contact2, contact3 };
            
            MemoryCache.Default.Set("ContactsList", contactCreationDtoList, Policy());

            var result = _sut.FilterContacts("");

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void FilterContacts_SearchStringNotEmpty_FilteredList()
        {
            var contact1 = _fixture.Build<ContactCreationDto>()
                                   .With(x => x.LastName, "John").Create();
            var contact2 = _fixture.Build<ContactCreationDto>()
                                   .With(x => x.LastName, "Adam").Create();
            var contact3 = _fixture.Build<ContactCreationDto>()
                                   .With(x => x.LastName, "Mary").Create();
            var contactCreationDtoList = new List<ContactCreationDto> { contact1, contact2, contact3 };

            MemoryCache.Default.Set("ContactsList", contactCreationDtoList, Policy());

            var result = _sut.FilterContacts("y");

            Assert.Equal(1, result.Count);
            Assert.Equal(contact3, result.FirstOrDefault());
        }
    }
}
