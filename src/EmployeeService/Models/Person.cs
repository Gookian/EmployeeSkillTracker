using System.ComponentModel.DataAnnotations;

namespace EmployeeService.Models
{
    public class Person
    {
        [Key]
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string DisplayName { get; set; }

        public required ICollection<Skill> Skills { get; set; }
    }
}