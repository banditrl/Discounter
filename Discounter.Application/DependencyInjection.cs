using Discounter.Application.Interfaces;
using Discounter.Application.Services;
using Discounter.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Discounter.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddInfrastructureDependencies();

            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}