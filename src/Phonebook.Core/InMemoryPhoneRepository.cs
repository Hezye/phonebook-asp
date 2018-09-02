using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Infrastructure.Data.Extensions;
using Phonebook.Infrastructure.DataStructures;
using Phonebook.Infrastructure.ViewModels;

namespace Phonebook.Core
{
    /// <summary>
    /// Memory based repository
    /// </summary>
    /// <remarks>Used for testing</remarks>
    public class InMemoryPhoneEntryRepository : IPhoneEntryRepository
    {
        private readonly List<PhoneEntry> _phones;

        public InMemoryPhoneEntryRepository()
        {
            _phones = new List<PhoneEntry>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneEntry"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Input parameters are null</exception>
        public Task AddAsync(PhoneEntry phoneEntry)
        {
            if (phoneEntry == null)
            {
                throw new ArgumentNullException(nameof(phoneEntry));
            }

            _phones.Add(phoneEntry);

            return Task.FromResult(0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Input parameters are null</exception>
        public Task<PhoneEntry> FindAsync(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            return Task.FromResult(_phones.FirstOrDefault(p => p.PhoneNumber == phoneNumber));   
        }

        public IEnumerable<PhoneEntry> ListAll()
        {
            return _phones;
        }

        public Task<IPagedList<PhoneEntry>> GetPagedListAsync(PagedInput input)
        {
            return _phones.AsQueryable().ToPagedListAsync(input.PageIndex ?? 1, input.PageSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneEntry"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Input parameters are null</exception>
        public Task RemoveAsync(PhoneEntry phoneEntry)
        {
            if (phoneEntry == null)
            {
                throw new ArgumentNullException(nameof(phoneEntry));
            }

            var phoneToRemove = _phones.FirstOrDefault(x => x.PhoneNumber == phoneEntry.PhoneNumber);

            if (phoneToRemove != null)
            {
                _phones.Remove(phoneToRemove);
            }

            return Task.FromResult(0);
        }
    }
}
