using Microsoft.EntityFrameworkCore;
using WebStore.Entities;

namespace WebStore.Data
{
    public class WebStoreDB : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }

        public WebStoreDB(DbContextOptions<WebStoreDB> options) : base(options) { }


    }
}
