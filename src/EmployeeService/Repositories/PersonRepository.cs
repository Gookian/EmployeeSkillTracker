using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Person> _persons;

        public PersonRepository(DbContext context)
        {
            _context = context;
            _persons = context.Set<Person>();
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _persons
                .AsNoTracking()
                .Include(p => p.Skills)
                .ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(long id)
        {
            return await _persons
                .AsNoTracking()
                .Include(p => p.Skills)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Person person)
        {
            await _persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            var existing = await _persons
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
            var person = await _persons
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person != null)
            {
                _persons.Remove(person);
            }
            else
            {
                throw new Exception();
            }

            await _context.SaveChangesAsync();
        }
    }
}