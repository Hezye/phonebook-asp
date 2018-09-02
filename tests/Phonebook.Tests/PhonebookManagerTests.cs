using Phonebook.Core;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Phonebook.Tests
{
    public class PhonebookManagerTests
    {
        private readonly IPhonebookManager _phonebook;
        private readonly IPhoneEntryRepository _phoneEntries;

        public PhonebookManagerTests()
        {
            _phoneEntries = new InMemoryPhoneEntryRepository();
            _phonebook = new PhonebookManager(_phoneEntries);
        }

        [Fact]
        public void AddPhoneEntry()
        {
            var newEntry = new PhoneEntry { FirstName = "Chuck", LastName = "McGill", PhoneNumber = "15325324" };

            _phonebook.AddEntryAsync(newEntry);

            Assert.NotEmpty(_phoneEntries.ListAll());
        }

        [Fact]
        public void ThrowArgumentExceptionOnDuplicateInsert()
        {
            var newEntry = new PhoneEntry { FirstName = "Chuck", LastName = "McGill", PhoneNumber = "15325324" };

            Assert.Throws<ArgumentException>(() => {
                _phonebook.AddEntryAsync(newEntry);
                _phonebook.AddEntryAsync(newEntry);
            });
        }

        [Fact]
        public void RemovePhoneEntry()
        {
            var newEntry = new PhoneEntry { FirstName = "Chuck", LastName = "McGill", PhoneNumber = "15325324" };

            _phonebook.AddEntryAsync(newEntry);
            _phonebook.RemoveEntryAsync(newEntry);

            Assert.Empty(_phoneEntries.ListAll());
        }

        [Fact]
        public void ThrowArgumentExceptionOnRemovingMissingEntry()
        {
            var newEntry = new PhoneEntry { FirstName = "Chuck", LastName = "McGill", PhoneNumber = "15325324" };

            Assert.Throws<ArgumentException>(() => {
                _phonebook.RemoveEntryAsync(newEntry);
            });
        }

        [Fact]
        public async Task GetAllEntriesAsync()
        {
            await _phonebook.AddEntryAsync(new PhoneEntry { FirstName = "Chuck", LastName = "McGill", PhoneNumber = "15325324" });
            await _phonebook.AddEntryAsync(new PhoneEntry { FirstName = "John", LastName = "Snow", PhoneNumber = "3132646" });
            await _phonebook.AddEntryAsync(new PhoneEntry { FirstName = "Clark", LastName = "Kent", PhoneNumber = "624626" });

            Assert.True((await _phonebook.GetPagedListAsync(new Infrastructure.ViewModels.PagedInput(100, 1))).TotalRows == 3);
        }

        [Fact]
        public void FindEntryByPhoneNumber()
        {
            _phonebook.AddEntryAsync(new PhoneEntry { FirstName = "Chuck", LastName = "McGill", PhoneNumber = "15325324" });

            Assert.NotNull(_phonebook.GetEntryAsync("15325324"));
        }
    }
}
