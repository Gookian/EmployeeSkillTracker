using EmployeeService.Models;

namespace EmployeeService.Dto
{
    public static class PersonMapper
    {
        public static Person ToEntity(PersonDTO dto, long id = 0)
        {
            return new Person
            {
                Id = id,
                Name = dto.Name,
                DisplayName = dto.DisplayName,
                Skills = dto.Skills
            };
        }
    }
}