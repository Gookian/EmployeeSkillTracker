using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private DbContext _context;
        private DbSet<Person> _persons;

        public PersonRepository(DbContext context)
        {
            _context = context;
            _persons = context.Set<Person>();
        }

        public IEnumerable<Person> GetAll()
        {
            return _persons
                .Include(p => p.Skill)
                .ToList();
        }

        public Person? GetById(long id)
        {
            return _persons
                .Include(p => p.Skill)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Add(Person person)
        {
            _persons.Add(person);
            _context.SaveChanges();
        }

        public void Update(Person person)
        {
            Person? existing = _persons
                .FirstOrDefault(p => p.Id == person.Id);

            if (existing != null)
            {
                existing.Name = person.Name;
                existing.DisplayName = person.DisplayName;
                existing.Skill = person.Skill;
            }
            else
            {
                throw new Exception();
            }

            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            Person? person = _persons
                .FirstOrDefault(p => p.Id == id);

            if (person != null)
            {
                _persons.Remove(person);
            }
            else
            {
                throw new Exception();
            }

            _context.SaveChanges();
        }
    }
}