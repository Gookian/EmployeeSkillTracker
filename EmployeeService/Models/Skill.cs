using System.ComponentModel.DataAnnotations;

namespace EmployeeService.Models
{
    public class Skill
    {
        [MaxLength(100)]
        public required string Name { get; set; }

        [Range(0, 10)]
        public required byte Level { get; set; }
    }
}