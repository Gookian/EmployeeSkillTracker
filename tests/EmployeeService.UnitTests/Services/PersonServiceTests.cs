using EmployeeService.Models;
using EmployeeService.Repositories;
using EmployeeService.Services;
using EmployeeService.UnitTests.Mock;
using Moq;
using EmployeeService.UnitTests.Comparers;
using EmployeeService.Dto;

namespace EmployeeService.UnitTests.Services
{
    [TestFixture]
    public class PersonServiceTests
    {
        private IPersonService _service;
        private Mock<IPersonRepository> _repositoryMock;

        private List<Person> people = new List<Person>()
        {
            new Person
            {
                Id = 1,
                Name = "John",
                DisplayName = "John Doe",
                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Name = "C#",
                        Level = 8
                    }
                }
            },
            new Person
            {
                Id = 2,
                Name = "Jane",
                DisplayName = "Jane Doe",
                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Name = "Python",
                        Level = 9
                    }
                }
            }
        };

        [SetUp]
        public void Setup()
        {
            _repositoryMock = PersonRepositoryMockFactory.Order(people);
            _service = new PersonService(_repositoryMock.Object);
        }

        [Test]
        public async Task GetAllPersonsAsync_RetrieveAllPersons_ShouldReturnAllPersons()
        {
            // Arrange.
            var expected = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    Name = "John",
                    DisplayName = "John Doe",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            Name = "C#",
                            Level = 8
                        }
                    }
                },
                new Person
                {
                    Id = 2,
                    Name = "Jane",
                    DisplayName = "Jane Doe",
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            Name = "Python",
                            Level = 9
                        }
                    }
                }
            };

            // Act.
            var actual = await _service.GetAllPersonsAsync();

            // Assert.
            Assert.That(actual, Is.EquivalentTo(expected).Using(new PersonEqualityComparer()));
        }

        [Test]
        public async Task GetPersonByIdAsync_RetrievePersonById_ShouldReturnPerson()
        {
            // Arrange.
            var expected = new Person
            {
                Id = 1,
                Name = "John",
                DisplayName = "John Doe",
                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Name = "C#",
                        Level = 8
                    }
                }
            };

            // Act.
            var actual = await _service.GetPersonByIdAsync(1);

            // Assert.
            Assert.That(actual, Is.EqualTo(expected).Using(new PersonEqualityComparer()));
        }

        [Test]
        public async Task CreatePersonAsync_InvokeCreationMethod_AddAsyncWasCalled()
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

            // Act.
            await _service.CreatePersonAsync(dto);

            // Assert.
            _repositoryMock.Verify(
                m => m.AddAsync(It.Is<Person>(p =>
                    p.Name == dto.Name &&
                    p.DisplayName == dto.DisplayName &&
                    p.Skills.Any(s => s.Name == "Kotlin" && s.Level == 5))),
                Times.Once
            );
        }

        [Test]
        public async Task UpdatePersonAsync_UpdationCalledOnce_ShouldReturnTrue()
        {
            // Arrange.
            var expected = Is.True;
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

            // Act.
            var actual = await _service.UpdatePersonAsync(id, dto);

            // Assert.
            _repositoryMock.Verify(
                m => m.UpdateAsync(It.Is<Person>(p =>
                    p.Id == id &&
                    p.Name == dto.Name &&
                    p.DisplayName == dto.DisplayName &&
                    p.Skills.Any(s => s.Name == "Kotlin" && s.Level == 5))),
                Times.Once
            );
            Assert.That(actual, expected);
        }

        [Test]
        public async Task UpdatePersonAsync_UpdationCalledNever_ShouldReturnFalse()
        {
            // Arrange.
            var expected = Is.False;
            var id = -1;
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

            // Act.
            var actual = await _service.UpdatePersonAsync(id, dto);

            // Assert.
            _repositoryMock.Verify(
                m => m.UpdateAsync(It.Is<Person>(p =>
                    p.Id == id &&
                    p.Name == dto.Name &&
                    p.DisplayName == dto.DisplayName &&
                    p.Skills.Any(s => s.Name == "Kotlin" && s.Level == 5))),
                Times.Never
            );
            Assert.That(actual, expected);
        }

        [Test]
        public async Task DeletePersonAsync_DeletionCalledOnce_ShouldReturnTrue()
        {
            // Arrange.
            var expected = Is.True;
            var id = 1;

            // Act.
            var actual = await _service.DeletePersonAsync(id);

            // Assert.
            _repositoryMock.Verify(
                m => m.DeleteAsync(id),
                Times.Once
            );
            Assert.That(actual, expected);
        }

        [Test]
        public async Task DeletePersonAsync_DeletionCalledNever_ShouldReturnFalse()
        {
            // Arrange.
            var expected = Is.False;
            var id = -1;

            // Act.
            var actual = await _service.DeletePersonAsync(id);

            // Assert.
            _repositoryMock.Verify(
                m => m.DeleteAsync(id),
                Times.Never
            );
            Assert.That(actual, expected);
        }
    }
}