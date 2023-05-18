namespace EmployeeTest
{
    internal class Mock<T>
    {
        public Mock()
        {
        }

        public object Object { get; internal set; }

        internal Task GetAsync(string apiUrl)
        {
            throw new NotImplementedException();
        }

        internal object Setup(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}