using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Data
{
    public class PostgresContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Person> Persons { get; set; }

        public PostgresContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connection = _configuration
                .GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connection);
        }
    }
}