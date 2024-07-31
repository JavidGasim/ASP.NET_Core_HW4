using ASP.NET_Core_HW4.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_HW4.Data
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
    }
}
