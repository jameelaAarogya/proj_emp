using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTest.Services
{
    public class EmployeeService
    {
        //private string _baseUrl = ConfigurationManager.AppSettings["_baseUrl"];
        private readonly string apiUrl = "https://gorest.co.in/public/v2/users";

        private HttpClient _httpClient;
        private IRestApiClient _restApiClient;

        public EmployeeService(IRestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
        }


        public EmployeeService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Employee>> GetEmployees()
        {
            Employee employee = new Employee();
            var response = await _httpClient.GetAsync(apiUrl);


            HttpResponseMessage httpResponse = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Employee>>(content);
        }
        private async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var employeeJson = JsonConvert.SerializeObject(employee);
            var content = new StringContent(employeeJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"users/{employee.Id}", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var updatedEmployee = JsonConvert.DeserializeObject<Employee>(responseContent);

            return updatedEmployee;
        }
        private async Task DeleteEmployeeAsync(int employeeId)
        {
            var response = await _httpClient.DeleteAsync($"users/{employeeId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
