using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class uniContext : DbContext
    {
        public DbSet<Student> Sstudents { get; set; }

        public uniContext(DbContextOptions options) : base(options)
        {

        }
    }
}