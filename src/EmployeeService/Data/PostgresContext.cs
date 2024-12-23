using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Data
{
    public class PostgresContext : DbContext
    {
        public required DbSet<Person> Persons { get; set; }

        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
        {
        }
    }
}