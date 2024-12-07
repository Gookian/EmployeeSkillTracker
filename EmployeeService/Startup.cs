using EmployeeService.Data;
using EmployeeService.Repositories;
using Microsoft.EntityFrameworkCore;

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
            services.AddControllers();

            services.AddSingleton<DbContext, PostgresContext>();
            services.AddSingleton<IPersonRepository, PersonRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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