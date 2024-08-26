using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoginAPIDotNet7_2.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public int Quantity { get; set; } 

        [Required]
        public decimal Rate { get; set; }

        public decimal Discount { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public int HeaderId { get; set; }

        public Header Header { get; set; }
    }
}
