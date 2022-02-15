using Discounter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Discounter.Infrastructure.Context
{
    public class DiscounterContext : DbContext, IDiscounterContext
    {
        public DiscounterContext(DbContextOptions<DiscounterContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.EmployeeId);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscounterContext).Assembly);
        }
    }
}
