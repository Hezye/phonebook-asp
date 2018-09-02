using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Phonebook.Application.ViewModels.PhoneEntry;
using Phonebook.Core;
using Phonebook.Infrastructure.DataStructures;
using Phonebook.Infrastructure.ViewModels;

namespace Phonebook.Application.Controllers
{
    [Route("api/[controller]")]
    public class PhoneController : Controller
    {
        private readonly IPhonebookManager _phonebookManager;
        private readonly ILogger _logger;

        public PhoneController(
            IPhonebookManager phonebookManager, 
            ILogger<PhoneController> logger)
        {
            _phonebookManager = phonebookManager;
            _logger = logger;
        }

        [HttpGet]
        public Task<IPagedList<PhoneEntry>> GetAllAsync(PagedInput input)
        {
            _logger.LogInformation("Get all phone entries");
            return _phonebookManager.GetPagedListAsync(input);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(PhoneEntry))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PhoneEntry>> CreateAsync([FromBody] NewPhoneEntryInput input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newEntry = new PhoneEntry
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                PhoneNumber = input.PhoneNumber
            };

            await _phonebookManager.AddEntryAsync(newEntry);

            return CreatedAtAction(nameof(GetByIdAsync),
                                   new { id = newEntry.PhoneNumber }, newEntry);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> RemoveAsync(string id)
        {
            var entry = await _phonebookManager.GetEntryAsync(id);

            if (entry == null)
            {
                return NotFound();
            }

            _logger.LogInformation("Delete phone entry with Id: " + id);

            await _phonebookManager.RemoveEntryAsync(entry);

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PhoneEntry>> GetByIdAsync(string id)
        {
            var entry = await _phonebookManager.GetEntryAsync(id);

            if (entry == null)
            {
                return NotFound();
            }

            return entry;
        }
    }
}
