using EmployeeService.Models;
using EmployeeService.Repositories;
using Moq;

namespace EmployeeService.UnitTests.Mock
{
    public static class PersonRepositoryMockFactory
    {
        public static Mock<IPersonRepository> Order(List<Person> people)
        {
            var mockRepository = new Mock<IPersonRepository>();

            mockRepository.Setup(m => m.GetAllAsync())
                .ReturnsAsync(people);

            mockRepository.Setup(m => m.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync((long id) => GetById(people, id));

            mockRepository.Setup(m => m.AddAsync(It.IsAny<Person>()))
                .Verifiable();

            mockRepository.Setup(m => m.UpdateAsync(It.IsAny<Person>()))
                .Verifiable();

            mockRepository.Setup(m => m.DeleteAsync(It.IsAny<long>()))
                .Verifiable();

            return mockRepository;
        }

        private static Person? GetById(List<Person> persons, long id)
        {
            return persons.FirstOrDefault(p => p.Id == id);
        }
    }
}