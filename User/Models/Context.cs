using Microsoft.EntityFrameworkCore;

namespace User.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserDetails> Users { get; set; }
       
    }
}
