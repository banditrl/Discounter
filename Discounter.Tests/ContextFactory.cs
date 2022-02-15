using Discounter.Infrastructure.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Discounter.UnitTests
{
    public sealed class ContextFactory
    {
        private ContextFactory()
        {
        }

        static ContextFactory()
        {
        }

        public static IDiscounterContext CreateContextForSQLite()
        {
            var connection = new SqliteConnection("DataSource=:memory:;Foreign Keys=False");
            connection.Open();

            var builder = new DbContextOptionsBuilder<DiscounterContext>()
                .UseSqlite(connection)
                .ConfigureWarnings(x => x.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.AmbientTransactionWarning));

            var context = new DiscounterContext(builder.Options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }
    }
}
