using Phonebook.Core;
using Phonebook.Infrastructure.Data.Extensions;
using Phonebook.Infrastructure.DataStructures;
using Phonebook.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.EntityFramework.Repositories
{
    /// <summary>
    /// Entityframework based repository
    /// </summary>
    public class PhoneEntryRepository : IPhoneEntryRepository
    {
        private readonly PhonebookDbContext _dbContext;

        public PhoneEntryRepository(PhonebookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(PhoneEntry phoneEntry)
        {
            _dbContext.AddAsync(phoneEntry);
            return _dbContext.SaveChangesAsync();
        }

        public Task<PhoneEntry> FindAsync(string phoneNumber)
        {
            return _dbContext.PhoneEntries.FindAsync(phoneNumber);
        }

        public Task<IPagedList<PhoneEntry>> GetPagedListAsync(PagedInput input)
        {
            return _dbContext.PhoneEntries.ToPagedListAsync(input.PageIndex ?? 1, input.PageSize);
        }

        public IEnumerable<PhoneEntry> ListAll()
        {
            return _dbContext.PhoneEntries;
        }

        public Task RemoveAsync(PhoneEntry phoneEntry)
        {
            _dbContext.PhoneEntries.Remove(phoneEntry);
            return _dbContext.SaveChangesAsync();
        }
    }
}
