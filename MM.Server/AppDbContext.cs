using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MM.Model;

namespace MM.Server
{
    public class AppDbContext : IdentityDbContext<Account>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<HotList> HotList { get; set; }
        public DbSet<Play> Plays { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
