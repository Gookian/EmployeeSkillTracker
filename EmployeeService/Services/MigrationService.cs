using EmployeeService.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Services
{
    public class MigrationService : IHostedService
    {
        private readonly IServiceProvider _provider;

        public MigrationService(IServiceProvider serviceProvider)
        {
            _provider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _provider.CreateScope())
            {
                PostgresContext dbContext = scope.ServiceProvider.GetRequiredService<PostgresContext>();
                await dbContext.Database.MigrateAsync(cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}