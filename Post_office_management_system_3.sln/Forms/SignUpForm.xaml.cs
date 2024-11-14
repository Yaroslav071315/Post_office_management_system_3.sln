using System;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Post_office_management_system_3.Data.Models;
using System.Windows.Controls;
using Post_office_management_system_3.Data.Repositories;

//namespace Post_office_management_system_3.Forms
//{
//    public partial class SignUpForm : Window
//    {
//        private readonly PostOfficeDbContext _dbContext;

//        public SignUpForm()
//        {
//            InitializeComponent();
//            _dbContext = new PostOfficeDbContext(new DbContextOptions<PostOfficeDbContext>());
//        }




//        // Show or hide fields based on selected role
//        private void RoleComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
//        {
//            var selectedRole = (RoleComboBox.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString();

//            AddressLabel.Visibility = selectedRole == "HeadPostOffice" ? Visibility.Visible : Visibility.Collapsed;
//            AddressTextBox.Visibility = selectedRole == "HeadPostOffice" ? Visibility.Visible : Visibility.Collapsed;
//            HeadPostOfficeLabel.Visibility = selectedRole == "Employee" ? Visibility.Visible : Visibility.Collapsed;
//            HeadPostOfficeIdTextBox.Visibility = selectedRole == "Employee" ? Visibility.Visible : Visibility.Collapsed;
//        }

//        // Handle Sign Up button click
//        private void SignUpButton_Click(object sender, RoutedEventArgs e)
//        {
//            var selectedRole = (RoleComboBox.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString();

//            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
//                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
//                string.IsNullOrWhiteSpace(PhoneTextBox.Text) ||
//                string.IsNullOrWhiteSpace(PasswordBox.Password))
//            {
//                MessageBox.Show("Please fill in all required fields.");
//                return;
//            }

//            if (selectedRole == "Client")
//            {
//                if (_dbContext.Clients.Any(c => c.Email == EmailTextBox.Text))
//                {
//                    MessageBox.Show("This email is already registered as a client.");
//                    return;
//                }

//                var client = new Client
//                {
//                    Name = NameTextBox.Text,
//                    Email = EmailTextBox.Text,
//                    Phone = PhoneTextBox.Text,
//                    Password = PasswordBox.Password,
//                };

//                _dbContext.Clients.Add(client);
//            }
//            else if (selectedRole == "Employee")
//            {
//                if (_dbContext.Employees.Any(e => e.Email == EmailTextBox.Text))
//                {
//                    MessageBox.Show("This email is already registered as an employee.");
//                    return;
//                }

//                if (!int.TryParse(HeadPostOfficeIdTextBox.Text, out int headPostOfficeId))
//                {
//                    MessageBox.Show("Invalid Head Post Office ID.");
//                    return;
//                }

//                var employee = new Employee
//                {
//                    Name = NameTextBox.Text,
//                    Email = EmailTextBox.Text,
//                    Phone = PhoneTextBox.Text,
//                    HeadPostOfficeId = headPostOfficeId,
//                    Password = PasswordBox.Password,
//                };

//                _dbContext.Employees.Add(employee);
//            }
//            else if (selectedRole == "HeadPostOffice")
//            {
//                if (string.IsNullOrWhiteSpace(AddressTextBox.Text))
//                {
//                    MessageBox.Show("Please enter an address for the Head Post Office.");
//                    return;
//                }

//                var headPostOffice = new HeadPostOffice
//                {
//                    Name = NameTextBox.Text,
//                    Address = AddressTextBox.Text,
//                    Password = PasswordBox.Password,
//                };

//                _dbContext.HeadPostOffices.Add(headPostOffice);
//            }

//            try
//            {
//                _dbContext.SaveChanges();
//                MessageBox.Show($"{selectedRole} registration successful!");
//                Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"An error occurred: {ex.Message}");
//            }
//        }
//    }





//}






namespace Post_office_management_system_3.Forms
{
    public partial class SignUpForm : Window
    {
        private readonly ClientRepository _clientRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly HeadPostOfficeRepository _headPostOfficeRepository;

        public SignUpForm()
        {
            InitializeComponent();

            // Initialize the DbContext and repositories
            var dbContext = /*new PostOfficeDbContext();*/ new PostOfficeDbContext(new DbContextOptions<PostOfficeDbContext>());
            _clientRepository = new ClientRepository(dbContext);
            _employeeRepository = new EmployeeRepository(dbContext);
            _headPostOfficeRepository = new HeadPostOfficeRepository(dbContext);
        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRole = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            AddressLabel.Visibility = selectedRole == "HeadPostOffice" ? Visibility.Visible : Visibility.Collapsed;
            AddressTextBox.Visibility = selectedRole == "HeadPostOffice" ? Visibility.Visible : Visibility.Collapsed;
            HeadPostOfficeLabel.Visibility = selectedRole == "Employee" ? Visibility.Visible : Visibility.Collapsed;
            HeadPostOfficeIdTextBox.Visibility = selectedRole == "Employee" ? Visibility.Visible : Visibility.Collapsed;
        }

        private async void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRole = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                string.IsNullOrWhiteSpace(PhoneTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            if (selectedRole == "Client")
            {
                if (await _clientRepository.EmailExistsAsync(EmailTextBox.Text))
                {
                    MessageBox.Show("This email is already registered as a client.");
                    return;
                }

                var client = new Client
                {
                    Name = NameTextBox.Text,
                    Email = EmailTextBox.Text,
                    Phone = PhoneTextBox.Text,
                    Password = PasswordBox.Password
                };

                await _clientRepository.AddAsync(client);
            }
            else if (selectedRole == "Employee")
            {
                if (await _employeeRepository.EmailExistsAsync(EmailTextBox.Text))
                {
                    MessageBox.Show("This email is already registered as an employee.");
                    return;
                }

                if (!int.TryParse(HeadPostOfficeIdTextBox.Text, out int headPostOfficeId))
                {
                    MessageBox.Show("Invalid Head Post Office ID.");
                    return;
                }

                var employee = new Employee
                {
                    Name = NameTextBox.Text,
                    Email = EmailTextBox.Text,
                    Phone = PhoneTextBox.Text,
                    HeadPostOfficeId = headPostOfficeId,
                    Password = PasswordBox.Password
                };

                await _employeeRepository.AddAsync(employee);
            }
            else if (selectedRole == "HeadPostOffice")
            {
                if (string.IsNullOrWhiteSpace(AddressTextBox.Text))
                {
                    MessageBox.Show("Please enter an address for the Head Post Office.");
                    return;
                }

                var headPostOffice = new HeadPostOffice
                {
                    Name = NameTextBox.Text,
                    Address = AddressTextBox.Text,
                    Password = PasswordBox.Password
                };

                await _headPostOfficeRepository.AddAsync(headPostOffice);
            }

            MessageBox.Show($"{selectedRole} registration successful!");
            Close();
        }

        private void NavigateToSignInButton_Click(object sender, RoutedEventArgs e)
        {
            //var signInForm = new SignInForm();
            //signInForm.Show();
            //Close();
            var formFactory = new FormFactory();
            var signInForm = formFactory.CreateForm(FormType.SignIn);
            signInForm.Show();
        }
    }
}




//namespace Post_office_management_system_3.Forms
//{
//    public partial class SignUpForm : Window
//    {
//        private readonly ClientRepository _clientRepository;
//        private readonly EmployeeRepository _employeeRepository;
//        private readonly HeadPostOfficeRepository _headPostOfficeRepository;

//        public SignUpForm(ClientRepository clientRepository, EmployeeRepository employeeRepository, HeadPostOfficeRepository headPostOfficeRepository)
//        {
//            InitializeComponent();
//            _clientRepository = clientRepository;
//            _employeeRepository = employeeRepository;
//            _headPostOfficeRepository = headPostOfficeRepository;
//        }

//        private async void SignUpButton_Click(object sender, RoutedEventArgs e)
//        {
//            var selectedRole = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

//            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
//                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
//                string.IsNullOrWhiteSpace(PhoneTextBox.Text) ||
//                string.IsNullOrWhiteSpace(PasswordBox.Password))
//            {
//                MessageBox.Show("Please fill in all required fields.");
//                return;
//            }

//            if (selectedRole == "Client")
//            {
//                if (await _clientRepository.EmailExistsAsync(EmailTextBox.Text))
//                {
//                    MessageBox.Show("This email is already registered as a client.");
//                    return;
//                }

//                var client = new Client
//                {
//                    Name = NameTextBox.Text,
//                    Email = EmailTextBox.Text,
//                    Phone = PhoneTextBox.Text,
//                    Password = PasswordBox.Password
//                };

//                await _clientRepository.AddAsync(client);
//            }
//            else if (selectedRole == "Employee")
//            {
//                if (await _employeeRepository.EmailExistsAsync(EmailTextBox.Text))
//                {
//                    MessageBox.Show("This email is already registered as an employee.");
//                    return;
//                }

//                if (!int.TryParse(HeadPostOfficeIdTextBox.Text, out int headPostOfficeId))
//                {
//                    MessageBox.Show("Invalid Head Post Office ID.");
//                    return;
//                }

//                var employee = new Employee
//                {
//                    Name = NameTextBox.Text,
//                    Email = EmailTextBox.Text,
//                    Phone = PhoneTextBox.Text,
//                    HeadPostOfficeId = headPostOfficeId,
//                    Password = PasswordBox.Password
//                };

//                await _employeeRepository.AddAsync(employee);
//            }
//            else if (selectedRole == "HeadPostOffice")
//            {
//                if (string.IsNullOrWhiteSpace(AddressTextBox.Text))
//                {
//                    MessageBox.Show("Please enter an address for the Head Post Office.");
//                    return;
//                }

//                var headPostOffice = new HeadPostOffice
//                {
//                    Name = NameTextBox.Text,
//                    Address = AddressTextBox.Text,
//                    Password = PasswordBox.Password
//                };

//                await _headPostOfficeRepository.AddAsync(headPostOffice);
//            }

//            MessageBox.Show($"{selectedRole} registration successful!");
//            Close();
//        }
//    }
//}


//namespace Post_office_management_system_3.Forms
//{
//    public partial class SignUpForm : Window
//    {
//        private readonly ClientRepository _clientRepository;
//        private readonly EmployeeRepository _employeeRepository;
//        private readonly HeadPostOfficeRepository _headPostOfficeRepository;

//        public SignUpForm(ClientRepository clientRepository, EmployeeRepository employeeRepository, HeadPostOfficeRepository headPostOfficeRepository)
//        {
//            InitializeComponent();
//            _clientRepository = clientRepository;
//            _employeeRepository = employeeRepository;
//            _headPostOfficeRepository = headPostOfficeRepository;
//        }

//        // Event handler for role selection change
//        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {
//            var selectedRole = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

//            AddressLabel.Visibility = selectedRole == "HeadPostOffice" ? Visibility.Visible : Visibility.Collapsed;
//            AddressTextBox.Visibility = selectedRole == "HeadPostOffice" ? Visibility.Visible : Visibility.Collapsed;
//            HeadPostOfficeLabel.Visibility = selectedRole == "Employee" ? Visibility.Visible : Visibility.Collapsed;
//            HeadPostOfficeIdTextBox.Visibility = selectedRole == "Employee" ? Visibility.Visible : Visibility.Collapsed;
//        }

//        // Event handler for navigating to the Sign In form
//        private void NavigateToSignInButton_Click(object sender, RoutedEventArgs e)
//        {
//            var signInForm = new SignInForm(_clientRepository, _employeeRepository, _headPostOfficeRepository);
//            signInForm.Show();
//            Close();
//        }

//        private async void SignUpButton_Click(object sender, RoutedEventArgs e)
//        {
//            var selectedRole = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

//            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
//                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
//                string.IsNullOrWhiteSpace(PhoneTextBox.Text) ||
//                string.IsNullOrWhiteSpace(PasswordBox.Password))
//            {
//                MessageBox.Show("Please fill in all required fields.");
//                return;
//            }

//            if (selectedRole == "Client")
//            {
//                if (await _clientRepository.EmailExistsAsync(EmailTextBox.Text))
//                {
//                    MessageBox.Show("This email is already registered as a client.");
//                    return;
//                }

//                var client = new Client
//                {
//                    Name = NameTextBox.Text,
//                    Email = EmailTextBox.Text,
//                    Phone = PhoneTextBox.Text,
//                    Password = PasswordBox.Password
//                };

//                await _clientRepository.AddAsync(client);
//            }
//            else if (selectedRole == "Employee")
//            {
//                if (await _employeeRepository.EmailExistsAsync(EmailTextBox.Text))
//                {
//                    MessageBox.Show("This email is already registered as an employee.");
//                    return;
//                }

//                if (!int.TryParse(HeadPostOfficeIdTextBox.Text, out int headPostOfficeId))
//                {
//                    MessageBox.Show("Invalid Head Post Office ID.");
//                    return;
//                }

//                var employee = new Employee
//                {
//                    Name = NameTextBox.Text,
//                    Email = EmailTextBox.Text,
//                    Phone = PhoneTextBox.Text,
//                    HeadPostOfficeId = headPostOfficeId,
//                    Password = PasswordBox.Password
//                };

//                await _employeeRepository.AddAsync(employee);
//            }
//            else if (selectedRole == "HeadPostOffice")
//            {
//                if (string.IsNullOrWhiteSpace(AddressTextBox.Text))
//                {
//                    MessageBox.Show("Please enter an address for the Head Post Office.");
//                    return;
//                }

//                var headPostOffice = new HeadPostOffice
//                {
//                    Name = NameTextBox.Text,
//                    Address = AddressTextBox.Text,
//                    Password = PasswordBox.Password
//                };

//                await _headPostOfficeRepository.AddAsync(headPostOffice);
//            }

//            MessageBox.Show($"{selectedRole} registration successful!");
//            Close();
//        }
//    }
//}