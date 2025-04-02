using Microsoft.EntityFrameworkCore;
using SideHustleShop.Models;

namespace SideHustleShop.Data
{
    public class SideHustleShopContext : DbContext
    {

        public SideHustleShopContext(DbContextOptions<SideHustleShopContext> options) :
            base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
