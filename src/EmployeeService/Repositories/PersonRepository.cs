using EmployeeService.Data;
using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons
                .AsNoTracking()
                .Include(p => p.Skills)
                .ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(long id)
        {
            return await _context.Persons
                .AsNoTracking()
                .Include(p => p.Skills)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            var existing = await _context.Persons
                .FirstOrDefaultAsync(p => p.Id == person.Id);

            if (existing != null)
            {
                existing.Name = person.Name;
                existing.DisplayName = person.DisplayName;
                existing.Skills = person.Skills;
            }
            else
            {
                throw new Exception();
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var person = await _context.Persons
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person != null)
            {
                _context.Persons.Remove(person);
            }
            else
            {
                throw new Exception();
            }

            await _context.SaveChangesAsync();
        }
    }
}