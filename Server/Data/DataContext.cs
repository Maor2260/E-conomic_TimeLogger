using DataModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace Server.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public DbSet<TimeLog> TimeLogs { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TestDB_TimeLogger.db");
        }
    }
}
