using MediPlus.Data;
using MediPlus.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MediPlus.Controllers
{
    public class ContactController : Controller
    {
        IContactMessageRepository _contactMessageRepository;

        public ContactController(IContactMessageRepository contactMessageRepository)
        {
            _contactMessageRepository = contactMessageRepository;
        }

        public IActionResult ContactUs()
        {
            return View("ContactUs");
        }

        [HttpPost]
        public async Task<IActionResult> AddContactMessage(ContactMessage contactMessage)
        {
            if (ModelState.IsValid)
            {
                _contactMessageRepository.AddContactMessageAsync(contactMessage);
                return Ok();
            }
            return BadRequest(ModelState);

        }
    }

}
