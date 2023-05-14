using System.Windows;

namespace EmployeeManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApiService _apiService;

        public MainWindow()
        {
            InitializeComponent();
            _apiService = new ApiService();
            LoadEmployees();
        }

        private async void LoadEmployees()
        {
            var employees = await _apiService.GetEmployees();
            dataGrid.ItemsSource = employees;
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new employee object from the input fields
            var employee = new Employee
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Gender =txtgender.Text,
                Status=txtstatus.Text
            };           

            // Call the API to create the employee
            var createdEmployee = await _apiService.CreateEmployee(employee);

            // Refresh the employee list
            LoadEmployees();

            // Clear the input fields
            ClearFields();
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected employee from the DataGrid
            var selectedEmployee = dataGrid.SelectedItem as Employee;
            if (selectedEmployee == null)
            {
                MessageBox.Show("Please select an employee to update.");
                return;
            }

            // Call the API to update the employee
            var updatedEmployee = await _apiService.UpdateEmployee(selectedEmployee);

            // Refresh the employee list
            LoadEmployees();

            // Clear the input fields
            ClearFields();
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected employee from the DataGrid
            var selectedEmployee = dataGrid.SelectedItem as Employee;
            if (selectedEmployee == null)
            {
                MessageBox.Show("Please select an employee to delete.");
                return;
            }

            // Confirm the deletion with the user
            var result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Deletion", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // Call the API to delete the employee
                await _apiService.DeleteEmployee(selectedEmployee.Id);

                // Refresh the employee list
                LoadEmployees();

                // Clear the input fields
                ClearFields();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtgender.Text = "";
            txtstatus.Text = "";
            dataGrid.SelectedItem = null;
        }
    }

}
