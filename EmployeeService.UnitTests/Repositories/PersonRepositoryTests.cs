using FluentAssertions;
using Moq;
using Moq.EntityFrameworkCore;
using EmployeeService.Repositories;
using NUnit.Framework;
using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using EmployeeService.Data;
using Microsoft.Extensions.Configuration;

namespace EmployeeService.UnitTests.Repositories
{
    [TestFixture]
    public class PersonRepositoryTests
    {
        private Mock<PostgresContext> _contextMock;
        private Mock<DbSet<Person>> _mockPersons;
        private IPersonRepository _repository;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAll_ShouldReturnPersonsWithSkills()
        {
            // Arrange
            

            // Act
            
            var result = _repository.GetAll();

            // Assert
            result.Should().HaveCount(2);
            result.First().Name.Should().Be("John");
            result.Last().Name.Should().Be("Jane");
        }
    }
}