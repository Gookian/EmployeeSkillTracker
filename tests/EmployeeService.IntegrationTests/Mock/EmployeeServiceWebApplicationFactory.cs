using EmployeeService.Data;
using EmployeeService.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeService.IntegrationTests.Mock
{
    internal class EmployeeServiceWebApplicationFactory : WebApplicationFactory<Startup>
    {
        private readonly string _testDatabaseName = "employee_test";

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                RemoveMigrationServices(services);
                ReplaceDbContextWithInMemoryDatabase(services);
            });

            builder.UseEnvironment("Development");
        }

        private void RemoveMigrationServices(IServiceCollection services)
        {
            var migrationServiceDescriptor = services.FirstOrDefault(d =>
                d.ServiceType == typeof(IHostedService) &&
                d.ImplementationType == typeof(MigrationService));

            if (migrationServiceDescriptor != null)
            {
                services.Remove(migrationServiceDescriptor);
            }
        }

        private void ReplaceDbContextWithInMemoryDatabase(IServiceCollection services)
        {
            // Не получается подменить ApplicationDbContext.
            
            /*var dbContextOptionsDescriptor = services.FirstOrDefault(d =>
                d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

            if (dbContextOptionsDescriptor != null)
            {
                services.Remove(dbContextOptionsDescriptor);
            }

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase(_testDatabaseName);
            });*/
        }
    }
}