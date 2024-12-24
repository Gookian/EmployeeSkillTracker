using EmployeeService.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Services
{
    public class MigrationService : IHostedService
    {
        private readonly IServiceProvider _provider;
        private readonly ILogger<MigrationService> _logger;

        public MigrationService(
            IServiceProvider provider,
            ILogger<MigrationService> logger)
        {
            _provider = provider;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                using (var scope = _provider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    await context.Database.MigrateAsync(cancellationToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось применить миграцию: {Message}", ex.Message);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}