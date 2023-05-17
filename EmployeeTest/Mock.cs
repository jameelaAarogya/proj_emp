namespace EmployeeTest
{
    internal class Mock<T>
    {
        public Mock()
        {
        }

        public object Object { get; internal set; }

        internal object Setup(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}