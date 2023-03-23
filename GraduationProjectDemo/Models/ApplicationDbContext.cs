using Microsoft.EntityFrameworkCore;

namespace GraduationProjectDemo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Person> persons { get; set; }

    }
}
