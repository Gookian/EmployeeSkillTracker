using EmployeeService.Data;
using EmployeeService.Middlewares;
using EmployeeService.Repositories;
using EmployeeService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Extensions.Logging;

namespace EmployeeService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            LogManager.Setup().LoadConfigurationFromFile("Nlog.config");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API сервиса управления навыками сотрудников",
                    Description = "Этот сервис позволяет управлять навыками " +
                                  "сотрудников, отслеживать их уровень и " +
                                  "актуализировать информацию о компетенциях " +
                                  "сотрудников.",
                    Version = "v1",
                });
            });

            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddNLog();
            });

            services.AddDbContext<DbContext, PostgresContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();

            services.AddControllers();

            services.AddHostedService<MigrationService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("swagger/v1/swagger.json", "Employee Service API");
                options.RoutePrefix = "";
            });

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/v1/{controller=Persons}/{action=Index}/{id?}");
            });
        }
    }
}