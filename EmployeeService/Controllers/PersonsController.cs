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

        public PersonsController(IPersonRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAllPersons()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                IEnumerable<Person> persons = _repository.GetAll();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPersonById(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Person> CreatePerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _repository.Add(person);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(long id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
                return StatusCode(500, ex.Message);
            }
        }
    }
}