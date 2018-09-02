using System;
using System.ComponentModel.DataAnnotations;

namespace Phonebook.Core
{
    public class PhoneEntry
    {
        [Key, Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
