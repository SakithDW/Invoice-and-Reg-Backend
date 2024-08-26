using LoginAPIDotNet7_2.Data;
using LoginAPIDotNet7_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginAPIDotNet7_2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext1;
        public ContactController(ApplicationDbContext dbContext1) {
            this.dbContext1 = dbContext1;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = dbContext1.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(Guid id)
        {
            var contact = dbContext1.Contacts.Find(id);

            if (contact == null)
            {
                return NotFound($"Contact with ID {id} not found.");
            }

            return Ok(contact);
        }

        [HttpPost]
        public IActionResult AddContact(ContactsDto req)
        {
            var domainModelContact = new Contact
            {
                ContactId = Guid.NewGuid(),
                Name = req.Name,
                Email = req.Email,
                Phone = req.PhoneNo,
                Address = req.Address

            };
            dbContext1.Contacts.Add(domainModelContact);
            dbContext1.SaveChanges();

            return Ok(domainModelContact);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(Guid id)
        {
            var contact = dbContext1.Contacts.Find(id);

            if (contact is not null)
            {
                dbContext1.Contacts.Remove(contact);
                dbContext1.SaveChanges();
            }
            return Ok();

        }


        [HttpPost("Edit")]
        public async Task<IActionResult> EditContact([FromBody] Contact updatedContact)
        {
            if (updatedContact == null)
            {
                return BadRequest("Updated contact is null");
            }
            var contact = await dbContext1.Contacts.FindAsync(updatedContact.ContactId);
            if (contact == null)
            {
                return NotFound();
            }
            contact.Name = updatedContact.Name;
            contact.Email = updatedContact.Email;
            contact.Phone = updatedContact.Phone;
            contact.Address = updatedContact.Address;
            try
            {
                dbContext1.Contacts.Update(contact);
                await dbContext1.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the contact");
            }
            return Ok(contact);
        }





    }



}
