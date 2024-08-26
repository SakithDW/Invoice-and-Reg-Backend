using System.ComponentModel.DataAnnotations;

namespace LoginAPIDotNet7_2.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Price { get; set; }
    }
}
