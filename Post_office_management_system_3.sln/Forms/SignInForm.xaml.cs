using Microsoft.EntityFrameworkCore;
using Post_office_management_system_3.Data.Models;
using Post_office_management_system_3.Data.Repositories;
//using Post_office_management_system_3.sln.Forms;
using System;
using System.Collections.Generic;
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

//namespace Post_office_management_system_3.Forms
//{
//    /// <summary>
//    /// Interaction logic for SignInForm.xaml
//    /// </summary>
//    public partial class SignInForm : Window
//    {
//        public SignInForm()
//        {
//            //InitializeComponent();
//        }
//    }
//}


//namespace Post_office_management_system_3.Forms
//{
//    public partial class SignInForm : Window
//    {
//        private readonly ClientRepository _clientRepository;
//        private readonly EmployeeRepository _employeeRepository;
//        private readonly HeadPostOfficeRepository _headPostOfficeRepository;

//        public SignInForm()
//        {
//            InitializeComponent();

//            // Initialize the DbContext and repositories
//            var dbContext = /*new PostOfficeDbContext();*/ new PostOfficeDbContext(new DbContextOptions<PostOfficeDbContext>());
//            _clientRepository = new ClientRepository(dbContext);
//            _employeeRepository = new EmployeeRepository(dbContext);
//            _headPostOfficeRepository = new HeadPostOfficeRepository(dbContext);
//        }

//        private async void SignInButton_Click(object sender, RoutedEventArgs e)
//        {
//            var selectedRole = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
//            var email = EmailTextBox.Text;
//            var password = PasswordBox.Password;

//            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
//            {
//                MessageBox.Show("Please enter both email and password.");
//                return;
//            }

//            bool isAuthenticated = false;

//            if (selectedRole == "Client")
//            {
//                isAuthenticated = await _clientRepository.ValidateCredentialsAsync(email, password);
//            }
//            else if (selectedRole == "Employee")
//            {
//                isAuthenticated = await _employeeRepository.ValidateCredentialsAsync(email, password);
//            }
//            else if (selectedRole == "HeadPostOffice")
//            {
//                isAuthenticated = await _headPostOfficeRepository.ValidateCredentialsAsync( password);
//            }

//            if (isAuthenticated)
//            {
//                MessageBox.Show("Sign In successful!");
//                // Navigate to the main application or dashboard here
//                Close();
//            }
//            else
//            {
//                MessageBox.Show("Invalid email or password.");
//            }
//        }
//    }
//}


//namespace Post_office_management_system_3.Forms
//{
//    public partial class SignInForm : Window
//    {
//        private readonly ClientRepository _clientRepository;
//        private readonly EmployeeRepository _employeeRepository;
//        private readonly HeadPostOfficeRepository _headPostOfficeRepository;

//        public SignInForm(ClientRepository clientRepository, EmployeeRepository employeeRepository, HeadPostOfficeRepository headPostOfficeRepository)
//        {
//            InitializeComponent();
//            _clientRepository = clientRepository;
//            _employeeRepository = employeeRepository;
//            _headPostOfficeRepository = headPostOfficeRepository;
//        }

//        private async void SignInButton_Click(object sender, RoutedEventArgs e)
//        {
//            var selectedRole = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
//            var email = EmailTextBox.Text;
//            var password = PasswordBox.Password;

//            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
//            {
//                MessageBox.Show("Please enter both email and password.");
//                return;
//            }

//            bool isAuthenticated = false;

//            if (selectedRole == "Client")
//            {
//                isAuthenticated = await _clientRepository.ValidateCredentialsAsync(email, password);

//            }
//            else if (selectedRole == "Employee")
//            {
//                isAuthenticated = await _employeeRepository.ValidateCredentialsAsync(email, password);
//            }
//            else if (selectedRole == "HeadPostOffice")
//            {
//                isAuthenticated = await _headPostOfficeRepository.ValidateCredentialsAsync( password);
//            }

//            if (isAuthenticated)
//            {
//                MessageBox.Show("Sign In successful!");
//                Close();
//            }
//            else
//            {
//                MessageBox.Show("Invalid email or password.");
//            }
//        }
//    }
//}





namespace Post_office_management_system_3.Forms
{
    public partial class SignInForm : Window
    {
        private readonly ClientRepository _clientRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly HeadPostOfficeRepository _headPostOfficeRepository;
        private readonly FormFactory _formFactory;

        public SignInForm(ClientRepository clientRepository, EmployeeRepository employeeRepository, HeadPostOfficeRepository headPostOfficeRepository)
        {
            InitializeComponent();
            _clientRepository = clientRepository;
            _employeeRepository = employeeRepository;
            _headPostOfficeRepository = headPostOfficeRepository;
            _formFactory = new FormFactory();
        }

        private async void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRole = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            var email = EmailTextBox.Text;
            var password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            bool isAuthenticated = false;
            FormType? destinationFormType = null;

            if (selectedRole == "Client")
            {
                isAuthenticated = await _clientRepository.ValidateCredentialsAsync(email, password);
                destinationFormType = FormType.ClientForm;
            }
            else if (selectedRole == "Employee")
            {
                isAuthenticated = await _employeeRepository.ValidateCredentialsAsync(email, password);
                destinationFormType = FormType.EmployeeForm;
            }
            else if (selectedRole == "HeadPostOffice")
            {
                isAuthenticated = await _headPostOfficeRepository.ValidateCredentialsAsync( password);
                destinationFormType = FormType.HeadPostOfficeForm;
            }

            if (isAuthenticated && destinationFormType.HasValue)
            {
                MessageBox.Show("Sign In successful!");
                var nextForm = _formFactory.CreateForm(destinationFormType.Value);
                nextForm.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }
        }
    }
}
