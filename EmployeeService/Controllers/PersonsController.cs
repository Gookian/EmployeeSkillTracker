using EmployeeService.Models;
using EmployeeService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepository _repository;
        private readonly ILogger<PersonsController> _logger;

        public PersonsController(
            IPersonRepository repository,
            ILogger<PersonsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAllPersons()
        {
            try
            {
                IEnumerable<Person> persons = _repository.GetAll();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при получении всех сотрудников.");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPersonById(long id)
        {
            try
            {
                Person? person = _repository.GetById(id);

                if (person == null)
                {
                    return NotFound();
                }

                return Ok(person);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при получении сотрудника по {id}.");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Person> CreatePerson([FromBody] Person person)
        {
            try
            {
                _repository.Add(person);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при создании сотрудника.");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(long id, [FromBody] Person person)
        {
            try
            {
                Person? existing = _repository.GetById(id);

                if (existing == null)
                {
                    return NotFound();
                }

                person.Id = id;

                _repository.Update(person);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при обновлении данных сотрудника с {id}.");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(long id)
        {
            try
            {
                Person? person = _repository.GetById(id);

                if (person == null)
                {
                    return NotFound();
                }

                _repository.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ошибка при удалении сотрудника по {id}.");
                return StatusCode(500, ex.Message);
            }
        }
    }
}