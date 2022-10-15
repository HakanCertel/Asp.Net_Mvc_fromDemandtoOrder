using Microsoft.EntityFrameworkCore;
using Senfoni.Entity;

namespace Senfoni.Data.Concrete.EfCore
{
    public class SenfoniContext:DbContext
    {
        private static string _nameOrConnectionString = typeof(DbContext).Name;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(c => new { c.CategoryId, c.ProductId });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-A8NNBCN;Database=Senfoni_Erp2;Trusted_Connection=True;");
               
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Stok> Stok { get; set; }
        public DbSet<Cari> Cari { get; set; }
    }
}
