namespace EmployeeTest
{
    public  interface IRestApiClient
    {
        public interface IRestApiClient
        {
            Task<TResponse> GetAsync<TResponse>(string url);
            Task<TResponse> PostAsync<TResponse>(string url, object data);
            Task<TResponse> PutAsync<TResponse>(string url, object data);
            Task<bool> DeleteAsync(string url);
        }

    }
}