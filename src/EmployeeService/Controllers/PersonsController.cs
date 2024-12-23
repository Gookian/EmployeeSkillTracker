using EmployeeService.Dto;
using EmployeeService.Models;
using EmployeeService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonsController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPersonsAsync()
        {
            var persons = await _service.GetAllPersonsAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonByIdAsync(long id)
        {
            var person = await _service.GetPersonByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonAsync([FromBody] PersonDTO personDto)
        {
            await _service.CreatePersonAsync(personDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonAsync(long id, [FromBody] PersonDTO personDto)
        {
            var updated = await _service.UpdatePersonAsync(id, personDto);
            if (!updated)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonAsync(long id)
        {
            var deleted = await _service.DeletePersonAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}