using EmployeeService.Validations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeService.Models
{
    public class Person
    {
        [Key]
        [JsonIgnore]
        public long Id { get; set; }

        [MaxLength(100)]
        [SymbolOnly]
        [NameValidation]
        public required string Name { get; set; }

        [MaxLength(100)]
        [AlphanumericOnly]
        public required string DisplayName { get; set; }

        public required ICollection<Skill> Skill { get; set; }
    }
}