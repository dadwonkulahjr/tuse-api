using Microsoft.EntityFrameworkCore;
using TuseAwesomeApiWeb.Models;

namespace TuseAwesomeApiWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }
    }
}
