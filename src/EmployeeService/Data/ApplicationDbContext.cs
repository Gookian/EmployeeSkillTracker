using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public required DbSet<Person> Persons { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}