using DonationBank.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DonationBank.Data
{
    public class AppDBContext :IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {



        }
       public DbSet<Product>Clothes { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderDetails> OrderDetail { get; set; }
        public DbSet<OrderHeader>OrderHeaders{ get; set; }

    }
}
