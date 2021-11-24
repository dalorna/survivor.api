using Microsoft.EntityFrameworkCore;

namespace survivor.api.Entity
{
    public class SurvivorContext : DbContext
    {
        private string _connection;
        public SurvivorContext(string connection)
        {
            _connection = connection;
        }

        public DbSet<UserSurvivor> UserSurvivor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlServer(_connection);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<TurbineData>().HasNoKey().ToView(null);
        }
    }
}
