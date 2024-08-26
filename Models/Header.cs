using System.ComponentModel.DataAnnotations;

namespace LoginAPIDotNet7_2.Models
{
    public class Header
    {
        [Key]
        public int HeaderId { get; set; } 

        [Required]
        public int OrderId { get; set; } 

        public string InvoiceNumber { get; set; } = string.Empty;

        public DateTime InvoiceDate { get; set; }

        public DateTime DueDate { get; set; }

        public string From { get; set; } = string.Empty;

        public string BillTo { get; set; }= string.Empty;

        public decimal Subtotal { get; set; }

        public decimal Tax { get; set; }

        public decimal Discount { get; set; }

        public decimal Total { get; set; }

        public decimal AmountPaid { get; set; }

        public decimal BalanceDue { get; set; }

        public string? Notes { get; set; }

        public string? Terms { get; set; }

        // Navigation Property for related Line Items
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
