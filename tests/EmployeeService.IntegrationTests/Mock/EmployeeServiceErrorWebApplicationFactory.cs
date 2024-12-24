using EmployeeService.Models;
using EmployeeService.Repositories;
using EmployeeService.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Moq;

namespace EmployeeService.IntegrationTests.Mock
{
    internal class EmployeeServiceErrorWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                RemoveMigrationServices(services);
                ConfigureTestServices(services);
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

        private void ConfigureTestServices(IServiceCollection services)
        {
            services.RemoveAll<IPersonRepository>();

            var mockRepository = new Mock<IPersonRepository>();
            mockRepository.Setup(_ => _.GetAllAsync()).ThrowsAsync(new InvalidOperationException());
            mockRepository.Setup(_ => _.GetByIdAsync(It.IsAny<long>())).ThrowsAsync(new InvalidOperationException());
            mockRepository.Setup(_ => _.AddAsync(It.IsAny<Person>())).ThrowsAsync(new DbUpdateException());
            mockRepository.Setup(_ => _.UpdateAsync(It.IsAny<Person>())).ThrowsAsync(new DbUpdateException());
            mockRepository.Setup(_ => _.DeleteAsync(It.IsAny<long>())).ThrowsAsync(new DbUpdateException());

            services.AddScoped(_ => mockRepository.Object);
        }
    }
}