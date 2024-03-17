using Microsoft.EntityFrameworkCore;
using ShopperStopInReact_Shared.Model.Admin;
using ShopperStopInReact_Shared.Model.Customer;

namespace ShopperStopInReact_Shared.DbContextData
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options) { }

        public DbSet<ProductDetails>? Product { get; set; }
        public DbSet<Category>? Category { get; set; }
        public DbSet<CartItems>? CartItems { get; set; }
        public DbSet<WishListItem>? WishListItem { get; set; }
        public DbSet<User>? User { get; set; }
        public DbSet<OtpVerificationLog>? OtpVerificationLog { get; set; }
        public DbSet<AdminDetails>? AdminDetails { get; set; }
    }
}
