using Phonebook.Infrastructure.DataStructures;
using Phonebook.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Core
{
    public interface IPhoneEntryRepository
    {
        Task AddAsync(PhoneEntry phoneEntry);
        Task RemoveAsync(PhoneEntry phoneEntry);
        Task<PhoneEntry> FindAsync(string phoneNumber);
        IEnumerable<PhoneEntry> ListAll();
        Task<IPagedList<PhoneEntry>> GetPagedListAsync(PagedInput input);
    }
}
