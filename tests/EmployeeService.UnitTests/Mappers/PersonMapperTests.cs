using EmployeeService.Dto;
using EmployeeService.Models;
using EmployeeService.UnitTests.Comparers;

namespace EmployeeService.UnitTests.Mappers
{
    [TestFixture]
    public class PersonMapperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ToEntity_MappingWithAddedId_ShouldReturnPersonWithAddedId()
        {
            // Arrange.
            var id = 1;
            var dto = new PersonDTO
            {
                Name = "Marta",
                DisplayName = "Marta Doe",
                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Name = "Kotlin",
                        Level = 5
                    }
                }
            };
            var expected = new Person()
            {
                Id = id,
                Name = dto.Name,
                DisplayName = dto.DisplayName,
                Skills = dto.Skills
            };

            // Act.
            var actual = PersonMapper.ToEntity(dto, id);

            // Assert.
            Assert.That(actual, Is.EqualTo(expected).Using(new PersonEqualityComparer()));
        }

        [Test]
        public void ToEntity_MappingWithoutId_ShouldReturnPersonWithZeroId()
        {
            // Arrange.
            var dto = new PersonDTO
            {
                Name = "Marta",
                DisplayName = "Marta Doe",
                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Name = "Kotlin",
                        Level = 5
                    }
                }
            };
            var expected = new Person()
            {
                Id = 0,
                Name = dto.Name,
                DisplayName = dto.DisplayName,
                Skills = dto.Skills
            };

            // Act.
            var actual = PersonMapper.ToEntity(dto);

            // Assert.
            Assert.That(actual, Is.EqualTo(expected).Using(new PersonEqualityComparer()));
        }
    }
}