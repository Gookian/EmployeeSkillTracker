using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Models
{
    [Owned]
    public class Skill
    {
        public required string Name { get; set; }

        [Range(1, 10)]
        public required byte Level { get; set; }
    }
}