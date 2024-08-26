using System.ComponentModel.DataAnnotations;

namespace LoginAPIDotNet7_2.Models
{
    public class ContactsDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PhoneNo { get; set; }
        public required string Address { get; set; }
    }
} 
