using Microsoft.EntityFrameworkCore;

namespace E_Ticaret_Project.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<HomeSlider> HomeSliders { get; set; }

        public DbSet<Register> Registers { get; set; } 
    }
}
