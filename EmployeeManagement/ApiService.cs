using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class ApiService
    {
        private HttpClient _httpClient;
        private string _baseUrl = "https://gorest.co.in/public/v2/users";
        private string _accessToken = "9e86ac006c47e4d1cdfce6a7eb10fac27dce5a0d6392aedf69c07a44d6c133d2"; 

        public ApiService()
        {
            _httpClient = new HttpClient();
        }
        private void AddAuthenticationHeader()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
        }
        public async Task<List<Employee>> GetEmployees()
        {
            AddAuthenticationHeader();
            var response = await _httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();           
            return JsonConvert.DeserializeObject<List<Employee>>(content);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            AddAuthenticationHeader();
            var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Employee>(content);
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            AddAuthenticationHeader();
            var json = JsonConvert.SerializeObject(employee);
            var response = await _httpClient.PostAsync(_baseUrl, new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Employee>(content);
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            AddAuthenticationHeader();
            var json = JsonConvert.SerializeObject(employee);
            var response = await _httpClient.PutAsync($"{_baseUrl}/{employee.Id}", new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Employee>(content);
        }

        public async Task DeleteEmployee(int id)
        {
            AddAuthenticationHeader();
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }

}
