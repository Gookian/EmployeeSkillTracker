using EmployeeService.Models;

namespace EmployeeService.Dto
{
    public class PersonDTO
    {
        public required string Name { get; set; }
        public required string DisplayName { get; set; }
        public required ICollection<Skill> Skills { get; set; }
    }
}