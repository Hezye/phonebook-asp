using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Application.ViewModels.PhoneEntry
{
    public class NewPhoneEntryInput
    {
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
