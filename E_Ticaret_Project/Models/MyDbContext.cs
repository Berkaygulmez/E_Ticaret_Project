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



    }
}
