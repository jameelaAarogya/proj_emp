using EmployeeTest;
using EmployeeTest.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCasesEmp
{
    public class EmpController
    {
        private readonly IRestApiClient apiClient;
        private readonly EmployeeService _employeeService;
        public EmpController(IRestApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        private readonly string apiUrl = "https://gorest.co.in/public/v2/users";

        private HttpClient _httpClient;
        private IRestApiClient _apiClient;

        public async Task<List<Employee>> GetEmployees()
        {
            Employee employee = new Employee();
            var response = await _httpClient.GetAsync(apiUrl);


            HttpResponseMessage httpResponse = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Employee>>(content);
        }
    }
}
