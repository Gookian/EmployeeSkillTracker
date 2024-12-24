using EmployeeService.Dto;
using EmployeeService.IntegrationTests.Mock;
using EmployeeService.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace EmployeeService.IntegrationTests.Controllers
{
    [TestFixture]
    internal class PersonsControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, Order(1)]
        public async Task CreatePersonAsync_SendRequest_ShouldReturnOk()
        {
            // Arrange.
            var expected = HttpStatusCode.OK;

            var factory = new EmployeeServiceWebApplicationFactory();
            var client = factory.CreateClient();

            var dto = new PersonDTO()
            {
                Name = "Test",
                DisplayName = "Test",
                Skills = new List<Skill>()
                {
                    new Skill()
                    {
                        Name = "Test_Skill",
                        Level = 1,
                    }
                }
            };

            // Act.
            string json = JsonConvert.SerializeObject(dto);
            var httpContext = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/v1/persons", httpContext);
            var actual = response.StatusCode;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Order(1)]
        public async Task CreatePersonAsync_SendRequest_ShouldReturnBadRequest()
        {
            // Arrange.
            var expected = HttpStatusCode.BadRequest;

            var factory = new EmployeeServiceWebApplicationFactory();
            var client = factory.CreateClient();

            var dto = new PersonDTO()
            {
                Name = "Test",
                DisplayName = "Test",
                Skills = new List<Skill>()
                {
                    new Skill()
                    {
                        Name = "Test_Skill",
                        Level = 0,
                    }
                }
            };

            // Act.
            string json = JsonConvert.SerializeObject(dto);
            var httpContext = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/v1/persons", httpContext);
            var actual = response.StatusCode;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Order(2)]
        public async Task GetAllPersonsAsync_SendRequest_ShouldReturnOk()
        {
            // Arrange.
            var expected = HttpStatusCode.OK;

            var factory = new EmployeeServiceWebApplicationFactory();
            var client = factory.CreateClient();

            // Act.
            var response = await client.GetAsync("/api/v1/persons");
            var actual = response.StatusCode;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Order(2)]
        public async Task GetAllPersonsAsync_SendRequest_ShouldReturnInternalServerError()
        {
            // Arrange.
            var expected = HttpStatusCode.InternalServerError;

            var factory = new EmployeeServiceErrorWebApplicationFactory();
            var client = factory.CreateClient();

            // Act.
            var response = await client.GetAsync("/api/v1/persons");
            var actual = response.StatusCode;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Order(3)]
        public async Task GetPersonByIdAsync_SendRequest_ShouldReturnOk()
        {
            // Arrange.
            var expected = HttpStatusCode.OK;

            var factory = new EmployeeServiceWebApplicationFactory();
            var client = factory.CreateClient();

            // Act.
            var response = await client.GetAsync("/api/v1/persons/1");
            var actual = response.StatusCode;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Order(3)]
        public async Task GetPersonByIdAsync_SendRequest_ShouldReturnBadRequest()
        {
            // Arrange.
            var expected = HttpStatusCode.BadRequest;

            var factory = new EmployeeServiceWebApplicationFactory();
            var client = factory.CreateClient();

            // Act.
            var response = await client.GetAsync("/api/v1/persons/test");
            var actual = response.StatusCode;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Order(3)]
        public async Task GetPersonByIdAsync_SendRequest_ShouldReturnNotFound()
        {
            // Arrange.
            var expected = HttpStatusCode.NotFound;

            var factory = new EmployeeServiceWebApplicationFactory();
            var client = factory.CreateClient();

            // Act.
            var response = await client.GetAsync("/api/v1/persons/100");
            var actual = response.StatusCode;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Order(3)]
        public async Task GetPersonByIdAsync_SendRequest_ShouldReturnInternalServerError()
        {
            // Arrange.
            var expected = HttpStatusCode.InternalServerError;

            var factory = new EmployeeServiceErrorWebApplicationFactory();
            var client = factory.CreateClient();

            // Act.
            var response = await client.GetAsync("/api/v1/persons/1");
            var actual = response.StatusCode;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Order(4)]
        public async Task UpdatePersonAsync_SendRequest_ShouldReturnOk()
        {
            // Arrange.
            var expected = HttpStatusCode.OK;

            var factory = new EmployeeServiceWebApplicationFactory();
            var client = factory.CreateClient();

            var dto = new PersonDTO()
            {
                Name = "Test",
                DisplayName = "Test",
                Skills = new List<Skill>()
                {
                    new Skill()
                    {
                        Name = "Test_Skill",
                        Level = 1,
                    }
                }
            };

            // Act.
            string json = JsonConvert.SerializeObject(dto);
            var httpContext = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/v1/persons/1", httpContext);
            var actual = response.StatusCode;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Order(4)]
        public async Task UpdatePersonAsync_SendRequest_ShouldReturnBadRequest()
        {
            // Arrange.
            var expected = HttpStatusCode.BadRequest;

            var factory = new EmployeeServiceWebApplicationFactory();
            var client = factory.CreateClient();

            var dto = new PersonDTO()
            {
                Name = "Test",
                DisplayName = "Test",
                Skills = new List<Skill>()
                {
                    new Skill()
                    {
                        Name = "Test_Skill",
                        Level = 11,
                    }
                }
            };

            // Act.
            string json = JsonConvert.SerializeObject(dto);
            var httpContext = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/v1/persons/1", httpContext);
            var actual = response.StatusCode;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Order(4)]
        public async Task UpdatePersonAsync_SendRequest_ShouldReturnNotFound()
        {
            // Arrange.
            var expected = HttpStatusCode.NotFound;

            var factory = new EmployeeServiceWebApplicationFactory();
            var client = factory.CreateClient();

            var dto = new PersonDTO()
            {
                Name = "Test",
                DisplayName = "Test",
                Skills = new List<Skill>()
                {
                    new Skill()
                    {
                        Name = "Test_Skill",
                        Level = 5,
                    }
                }
            };

            // Act.
            string json = JsonConvert.SerializeObject(dto);
            var httpContext = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/v1/persons/100", httpContext);
            var actual = response.StatusCode;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Order(4)]
        public async Task UpdatePersonAsync_SendRequest_ShouldReturnInternalServerError()
        {
            // Arrange.
            var expected = HttpStatusCode.InternalServerError;

            var factory = new EmployeeServiceErrorWebApplicationFactory();
            var client = factory.CreateClient();

            var dto = new PersonDTO()
            {
                Name = "Test",
                DisplayName = "Test",
                Skills = new List<Skill>()
                {
                    new Skill()
                    {
                        Name = "Test_Skill",
                        Level = 1,
                    }
                }
            };

            // Act.
            string json = JsonConvert.SerializeObject(dto);
            var httpContext = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/v1/persons/1", httpContext);
            var actual = response.StatusCode;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Order(5)]
        public async Task DeletePersonAsync_SendRequest_ShouldReturnOk()
        {
            // Arrange.
            var expected = HttpStatusCode.OK;

            var factory = new EmployeeServiceWebApplicationFactory();
            var client = factory.CreateClient();

            // Act.
            var response = await client.DeleteAsync("/api/v1/persons/1");
            var actual = response.StatusCode;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Order(5)]
        public async Task DeletePersonAsync_SendRequest_ShouldReturnBadRequest()
        {
            // Arrange.
            var expected = HttpStatusCode.BadRequest;

            var factory = new EmployeeServiceWebApplicationFactory();
            var client = factory.CreateClient();

            // Act.
            var response = await client.DeleteAsync("/api/v1/persons/test");
            var actual = response.StatusCode;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Order(5)]
        public async Task DeletePersonAsync_SendRequest_ShouldReturnNotFound()
        {
            // Arrange.
            var expected = HttpStatusCode.NotFound;

            var factory = new EmployeeServiceWebApplicationFactory();
            var client = factory.CreateClient();

            // Act.
            var response = await client.DeleteAsync("/api/v1/persons/-1");
            var actual = response.StatusCode;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Order(5)]
        public async Task DeletePersonAsync_SendRequest_ShouldReturnInternalServerError()
        {
            // Arrange.
            var expected = HttpStatusCode.InternalServerError;

            var factory = new EmployeeServiceErrorWebApplicationFactory();
            var client = factory.CreateClient();

            // Act.
            var response = await client.DeleteAsync("/api/v1/persons/1");
            var actual = response.StatusCode;

            // Assert.
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}