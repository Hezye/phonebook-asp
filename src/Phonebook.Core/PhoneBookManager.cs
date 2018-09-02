using Phonebook.Infrastructure.DataStructures;
using Phonebook.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Core
{
    public interface IPhonebookManager
    {
        Task<IPagedList<PhoneEntry>> GetPagedListAsync(PagedInput input);
        Task AddEntryAsync(PhoneEntry entry);
        Task RemoveEntryAsync(PhoneEntry entry);
        Task<PhoneEntry> GetEntryAsync(string phoneNumber);
    }

    public class PhonebookManager : IPhonebookManager
    {
        private readonly IPhoneEntryRepository _phoneEntryRepository;

        public PhonebookManager(IPhoneEntryRepository phoneEntryRepository)
        {
            _phoneEntryRepository = phoneEntryRepository;
        }

        public Task<IPagedList<PhoneEntry>> GetPagedListAsync(PagedInput input)
        {
            return _phoneEntryRepository.GetPagedListAsync(input);
        }

        public Task AddEntryAsync(PhoneEntry entry)
        {
            if (_phoneEntryRepository.FindAsync(entry.PhoneNumber).GetAwaiter().GetResult() != null)
            {
                throw new ArgumentException();
            }

            return _phoneEntryRepository.AddAsync(entry);
        }

        public Task RemoveEntryAsync(PhoneEntry entry)
        {
            if (_phoneEntryRepository.FindAsync(entry.PhoneNumber).GetAwaiter().GetResult() == null)
            {
                throw new ArgumentException();
            }

            return _phoneEntryRepository.RemoveAsync(entry);
        }

        public Task<PhoneEntry> GetEntryAsync(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentNullException();
            }

            return _phoneEntryRepository.FindAsync(phoneNumber);
        }
    }
}
