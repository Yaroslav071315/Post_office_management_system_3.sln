using Post_office_management_system_3.Data.Models;
using Post_office_management_system_3.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

//namespace Post_office_management_system_3.sln.Forms
//{
//    /// <summary>
//    /// Interaction logic for HeadPostOfficeForm.xaml
//    /// </summary>
//    public partial class HeadPostOfficeForm : Window
//    {
//        public HeadPostOfficeForm()
//        {
//            InitializeComponent();
//        }
//    }
//}


//namespace Post_office_management_system_3.Forms
//{
//    public partial class HeadPostOfficeForm : Window
//    {
//        private readonly HeadPostOfficeRepository _headPostOfficeRepository;
//        private readonly EmployeeRepository _employeeRepository;

//        public ObservableCollection<HeadPostOffice> HeadPostOffices { get; set; }
//        public ObservableCollection<Employee> Employees { get; set; }

//        public HeadPostOfficeForm(HeadPostOfficeRepository headPostOfficeRepository, EmployeeRepository employeeRepository)
//        {
//            InitializeComponent();
//            _headPostOfficeRepository = headPostOfficeRepository;
//            _employeeRepository = employeeRepository;
//            DataContext = this;
//        }

//        private void LoadHeadPostOfficesButton_Click(object sender, RoutedEventArgs e)
//        {
//            var headPostOffices = _headPostOfficeRepository.GetAll();
//            HeadPostOffices = new ObservableCollection<HeadPostOffice>(headPostOffices);
//            HeadPostOfficesDataGrid.ItemsSource = HeadPostOffices;
//        }

//        private void UpdateHeadPostOfficeButton_Click(object sender, RoutedEventArgs e)
//        {
//            if (HeadPostOfficesDataGrid.SelectedItem is HeadPostOffice selectedOffice)
//            {
//                selectedOffice.Name = HeadPostOfficeNameTextBox.Text;
//                selectedOffice.Address = HeadPostOfficeAddressTextBox.Text;

//                _headPostOfficeRepository.Update(selectedOffice);
//                HeadPostOfficesDataGrid.Items.Refresh();
//            }
//            else
//            {
//                MessageBox.Show("Please select a head post office to update.");
//            }
//        }

//        private void DeleteHeadPostOfficeButton_Click(object sender, RoutedEventArgs e)
//        {
//            if (HeadPostOfficesDataGrid.SelectedItem is HeadPostOffice selectedOffice)
//            {
//                _headPostOfficeRepository.Delete(selectedOffice.Id);
//                HeadPostOffices.Remove(selectedOffice);
//            }
//            else
//            {
//                MessageBox.Show("Please select a head post office to delete.");
//            }
//        }

//        private void LoadEmployeesButton_Click(object sender, RoutedEventArgs e)
//        {
//            var employees = _employeeRepository.GetAll();
//            Employees = new ObservableCollection<Employee>(employees);
//            EmployeesDataGrid.ItemsSource = Employees;
//        }

//        private void UpdateEmployeeButton_Click(object sender, RoutedEventArgs e)
//        {
//            if (EmployeesDataGrid.SelectedItem is Employee selectedEmployee)
//            {
//                selectedEmployee.Name = EmployeeNameTextBox.Text;
//                selectedEmployee.Email = EmployeeEmailTextBox.Text;
//                selectedEmployee.Phone = EmployeePhoneTextBox.Text;

//                _employeeRepository.Update(selectedEmployee);
//                EmployeesDataGrid.Items.Refresh();
//            }
//            else
//            {
//                MessageBox.Show("Please select an employee to update.");
//            }
//        }

//        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
//        {
//            if (EmployeesDataGrid.SelectedItem is Employee selectedEmployee)
//            {
//                _employeeRepository.Delete(selectedEmployee.Id);
//                Employees.Remove(selectedEmployee);
//            }
//            else
//            {
//                MessageBox.Show("Please select an employee to delete.");
//            }
//        }
//    }
//}



namespace Post_office_management_system_3.Forms
{
    public partial class HeadPostOfficeForm : Window
    {
        private readonly HeadPostOfficeRepository _headPostOfficeRepository;
        private readonly EmployeeRepository _employeeRepository;

        public ObservableCollection<HeadPostOffice> HeadPostOffices { get; set; } = new ObservableCollection<HeadPostOffice>();
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();

        public HeadPostOfficeForm(HeadPostOfficeRepository headPostOfficeRepository, EmployeeRepository employeeRepository)
        {
            InitializeComponent();
            _headPostOfficeRepository = headPostOfficeRepository;
            _employeeRepository = employeeRepository;
            DataContext = this;
        }

        private async Task LoadHeadPostOfficesAsync()
        {
            var headPostOffices = await _headPostOfficeRepository.GetAllAsync();
            HeadPostOffices.Clear();
            foreach (var office in headPostOffices)
            {
                HeadPostOffices.Add(office);
            }
        }

        private async Task LoadEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            Employees.Clear();
            foreach (var employee in employees)
            {
                Employees.Add(employee);
            }
        }

        private async void LoadHeadPostOfficesButton_Click(object sender, RoutedEventArgs e)
        {
            await LoadHeadPostOfficesAsync();
            HeadPostOfficesDataGrid.ItemsSource = HeadPostOffices;
        }

        private async void LoadEmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            await LoadEmployeesAsync();
            EmployeesDataGrid.ItemsSource = Employees;
        }

        private async void UpdateHeadPostOfficeButton_Click(object sender, RoutedEventArgs e)
        {
            if (HeadPostOfficesDataGrid.SelectedItem is HeadPostOffice selectedOffice)
            {
                selectedOffice.Name = HeadPostOfficeNameTextBox.Text;
                selectedOffice.Address = HeadPostOfficeAddressTextBox.Text;

                await _headPostOfficeRepository.UpdateAsync(selectedOffice);
                HeadPostOfficesDataGrid.Items.Refresh();
                MessageBox.Show("Head Post Office updated successfully.");
            }
            else
            {
                MessageBox.Show("Please select a head post office to update.");
            }
        }

        private async void DeleteHeadPostOfficeButton_Click(object sender, RoutedEventArgs e)
        {
            if (HeadPostOfficesDataGrid.SelectedItem is HeadPostOffice selectedOffice)
            {
                await _headPostOfficeRepository.DeleteAsync(selectedOffice.Id);
                HeadPostOffices.Remove(selectedOffice);
                MessageBox.Show("Head Post Office deleted successfully.");
            }
            else
            {
                MessageBox.Show("Please select a head post office to delete.");
            }
        }

        private async void UpdateEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem is Employee selectedEmployee)
            {
                selectedEmployee.Name = EmployeeNameTextBox.Text;
                selectedEmployee.Email = EmployeeEmailTextBox.Text;
                selectedEmployee.Phone = EmployeePhoneTextBox.Text;

                await _employeeRepository.UpdateAsync(selectedEmployee);
                EmployeesDataGrid.Items.Refresh();
                MessageBox.Show("Employee updated successfully.");
            }
            else
            {
                MessageBox.Show("Please select an employee to update.");
            }
        }

        private async void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem is Employee selectedEmployee)
            {
                await _employeeRepository.DeleteAsync(selectedEmployee.Id);
                Employees.Remove(selectedEmployee);
                MessageBox.Show("Employee deleted successfully.");
            }
            else
            {
                MessageBox.Show("Please select an employee to delete.");
            }
        }
    }
}