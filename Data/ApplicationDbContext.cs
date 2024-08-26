using LoginAPIDotNet7.Models;
using LoginAPIDotNet7_2.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAPIDotNet7_2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<OrderItem>()
               .HasOne(o => o.Header)        // Each OrderItem has one Header
               .WithMany(h => h.OrderItems)  // A Header can have many OrderItems
               .HasForeignKey(o => o.HeaderId);  // Foreign key for OrderItem



        }
    }
}
