using EmployeeService.Dto;
using EmployeeService.Models;

namespace EmployeeService.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllPersonsAsync();
        Task<Person?> GetPersonByIdAsync(long id);
        Task CreatePersonAsync(PersonDTO personDto);
        Task<bool> UpdatePersonAsync(long id, PersonDTO personDto);
        Task<bool> DeletePersonAsync(long id);
    }
}