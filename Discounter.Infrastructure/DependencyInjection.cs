using Discounter.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Discounter.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureDependencies(this IServiceCollection services)
        {
            var connection = new SqliteConnection("DataSource=:memory:;Foreign Keys=False");
            connection.Open();

            services.AddDbContext<IDiscounterContext, DiscounterContext>((serviceProvider, optionsBuilder) =>
                optionsBuilder
                    .UseSqlite(connection)
                    .ConfigureWarnings(x => x.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.AmbientTransactionWarning))
            );
        }
    }
}
