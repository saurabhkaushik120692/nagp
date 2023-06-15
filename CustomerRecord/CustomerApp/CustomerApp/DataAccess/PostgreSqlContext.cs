using CustomerApp.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.DataAccess
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {

        }

        public DbSet<Customer> customer { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
