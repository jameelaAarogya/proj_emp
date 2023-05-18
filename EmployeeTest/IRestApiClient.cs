using EmployeeTest.Services;

namespace EmployeeTest
{
    public  interface IRestApiClient
    {
        Task PutAsync(string v, Employee employee);
        Task PutAsync(string v, StringContent content);

        public interface IRestApiClient
        {
            Task<bool> UpdateEmployeeAsync(Employee employee);
            Task<bool> DeleteEmployeeAsync(int employeeId);


            Task<List<Employee>> GetEmployeesAsync();
        }

    }
}