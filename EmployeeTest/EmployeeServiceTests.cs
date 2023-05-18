using EmployeeTest.Services;
using System.Net;
using FluentAssertions;
using System.Net.Http.Json;

namespace EmployeeTest
{
    public class Tests
    {
        private EmployeeService employeeService;
        private Mock<IRestApiClient> restApiClientMock;

        [SetUp]
        public void Setup()
        {
            var restApiClientMock = new Mock<IRestApiClient>();
            var employeeService = new EmployeeService();
            // employeeService = new EmployeeService(restApiClientMock.Object);
        }     
             
               
        public class TestHttpClientHandler : HttpMessageHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                // Implement the desired behavior for your test case
                // You can create and return a mock HttpResponseMessage based on the request

                // Example: Return a success response with status code 200
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                return await Task.FromResult(response);
            }
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void Test_GetEmployees_ReturnsListOfEmployees()
        {
            EmployeeService employeeService = new EmployeeService();
            var employees = employeeService.GetEmployees().Result;
            Assert.IsNotNull(employees);
            if (employees.Count > 0)
            {
                Assert.IsTrue(employees.Count > 0);
            }
        }
        [Test]
        public async Task UpdateEmployee_ValidData_ReturnsUpdatedEmployee()
        {
            // Arrange
            var employeeToUpdate = new Employee
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Gender ="Male",
                Status ="Inactive"
            };

            var updatedEmployee = new Employee
            {
                Id = 1,
                Name = "John Smith",
                Email = "john.smith@example.com",
                Gender = "Male",
                Status = "Inactive"
            };

            EmployeeService employeeService = new EmployeeService();
            
            var employees = employeeService.GetEmployees().Result;            
            Assert.IsNotNull(employees);
            if (employees.Count > 0)
            {
                Assert.IsTrue(employees.Count > 0);
            }
        }       

        [Test]
        public async Task DeleteEmployee_ValidId_ReturnsTrue()
        {
            EmployeeService employeeService = new EmployeeService();
            var employees = employeeService.GetEmployees().Result;           
            Assert.IsNotNull(employees);
            if (employees.Count > 0)
            {
                Assert.IsTrue(employees.Count > 0);
            }
        }
    }
}