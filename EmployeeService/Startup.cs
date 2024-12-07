using EmployeeService.Data;
using EmployeeService.Repositories;
using EmployeeService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace EmployeeService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
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

            services.AddControllers();

            services.AddSingleton<DbContext, PostgresContext>();
            services.AddSingleton<IPersonRepository, PersonRepository>();

            services.AddHostedService<MigrationService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(
                    "swagger/v1/swagger.json",
                    "Employee sevice API");
                options.RoutePrefix = "";
            });

            app.UseHttpsRedirection();
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