using EmployeeService.Dto;
using EmployeeService.Models;
using EmployeeService.Repositories;

namespace EmployeeService.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Person?> GetPersonByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreatePersonAsync(PersonDTO personDto)
        {
            var personEntity = PersonMapper.ToEntity(personDto);
            await _repository.AddAsync(personEntity);
        }

        public async Task<bool> UpdatePersonAsync(long id, PersonDTO personDto)
        {
            var person = await _repository.GetByIdAsync(id);
            if (person == null)
            {
                return false;
            }

            var personEntity = PersonMapper.ToEntity(personDto, id);
            await _repository.UpdateAsync(personEntity);
            return true;
        }

        public async Task<bool> DeletePersonAsync(long id)
        {
            var person = await _repository.GetByIdAsync(id);
            if (person == null)
            {
                return false;
            }

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}