using EmployeeService.Models;

namespace EmployeeService.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();

        Person? GetById(long id);

        void Add(Person person);

        void Update(Person person);

        void Delete(long id);
    }
}