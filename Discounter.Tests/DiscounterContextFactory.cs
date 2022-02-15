using Discounter.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Discounter.UnitTests
{
    public sealed class DiscounterContextFactory : DiscounterContext
    {
        public DiscounterContextFactory(DbContextOptions<DiscounterContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
