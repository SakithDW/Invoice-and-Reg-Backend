using System.ComponentModel.DataAnnotations;

namespace LoginAPIDotNet7_2.Models
{
    public class Contact
    {
        [Key]
        public Guid ContactId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
    }
}
