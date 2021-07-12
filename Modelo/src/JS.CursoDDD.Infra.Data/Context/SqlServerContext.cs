using JS.CursoDDD.Domain.Entites;
using JS.CursoDDD.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace JS.CursoDDD.Infra.Data.Context
{
    public class SqlServerContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
        }
    }
}
