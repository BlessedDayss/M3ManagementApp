namespace WebApplication1.Models
{

    using Microsoft.EntityFrameworkCore;

    public class M3ManagmentContext : DbContext
    {
        public M3ManagmentContext(DbContextOptions<M3ManagmentContext> options)
            : base(options){}
        
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; } 
    }
}