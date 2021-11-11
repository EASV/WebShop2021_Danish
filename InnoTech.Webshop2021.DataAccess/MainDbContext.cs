using InnoTech.Webshop2021.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnoTech.Webshop2021.DataAccess
{
    public class MainDbContext: DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options): base(options) {}
        
        public DbSet<ProductEntity> Products { get; set; }
    }
}