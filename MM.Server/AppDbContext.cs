using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MM
{
    public class AppDbContext : IdentityDbContext<Account>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Play> Plays { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
