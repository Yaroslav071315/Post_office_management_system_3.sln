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
//    /// Interaction logic for EmployeeForm.xaml
//    /// </summary>
//    public partial class EmployeeForm : Window
//    {
//        public EmployeeForm()
//        {
//            InitializeComponent();
//        }
//    }
//}


//namespace Post_office_management_system_3.Forms
//{
//    public partial class EmployeeForm : Window
//    {
//        private readonly ClientRepository _clientRepository;
//        private readonly ParcelRepository _parcelRepository;

//        public ObservableCollection<Client> Clients { get; set; }
//        public ObservableCollection<Parcel> Parcels { get; set; }

//        public EmployeeForm(ClientRepository clientRepository, ParcelRepository parcelRepository)
//        {
//            InitializeComponent();
//            _clientRepository = clientRepository;
//            _parcelRepository = parcelRepository;
//        }

//        private void LoadClientsButton_Click(object sender, RoutedEventArgs e)
//        {
//            var clients = _clientRepository.GetAll();
//            Clients = new ObservableCollection<Client>(clients);
//            ClientsDataGrid.ItemsSource = Clients;
//        }

//        private void LoadParcelsButton_Click(object sender, RoutedEventArgs e)
//        {
//            var parcels = _parcelRepository.GetAll();
//            Parcels = new ObservableCollection<Parcel>(parcels);
//            ParcelsDataGrid.ItemsSource = Parcels;
//        }

//        private void UpdateClientButton_Click(object sender, RoutedEventArgs e)
//        {
//            if (ClientsDataGrid.SelectedItem is Client selectedClient)
//            {
//                // Prompt user to edit client properties (could be a new window or form).
//                // Here, just update it directly as an example.
//                selectedClient.Name = "New Name"; // For example purposes.
//                _clientRepository.Update(selectedClient);
//                ClientsDataGrid.Items.Refresh();
//            }
//            else
//            {
//                MessageBox.Show("Please select a client to update.");
//            }
//        }

//        private void DeleteClientButton_Click(object sender, RoutedEventArgs e)
//        {
//            if (ClientsDataGrid.SelectedItem is Client selectedClient)
//            {
//                _clientRepository.Delete(selectedClient.Id);
//                Clients.Remove(selectedClient);
//            }
//            else
//            {
//                MessageBox.Show("Please select a client to delete.");
//            }
//        }

//        private void UpdateParcelButton_Click(object sender, RoutedEventArgs e)
//        {
//            if (ParcelsDataGrid.SelectedItem is Parcel selectedParcel)
//            {
//                // Prompt user to edit parcel properties.
//                selectedParcel.Weight = 50; // Update as needed, for example purposes.
//                _parcelRepository.Update(selectedParcel);
//                ParcelsDataGrid.Items.Refresh();
//            }
//            else
//            {
//                MessageBox.Show("Please select a parcel to update.");
//            }
//        }

//        private void DeleteParcelButton_Click(object sender, RoutedEventArgs e)
//        {
//            if (ParcelsDataGrid.SelectedItem is Parcel selectedParcel)
//            {
//                _parcelRepository.Delete(selectedParcel.Id);
//                Parcels.Remove(selectedParcel);
//            }
//            else
//            {
//                MessageBox.Show("Please select a parcel to delete.");
//            }
//        }
//    }
//}



namespace Post_office_management_system_3.Forms
{
    public partial class EmployeeForm : Window
    {
        private readonly ClientRepository _clientRepository;
        private readonly ParcelRepository _parcelRepository;

        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Parcel> Parcels { get; set; }

        public EmployeeForm(ClientRepository clientRepository, ParcelRepository parcelRepository)
        {
            InitializeComponent();
            _clientRepository = clientRepository;
            _parcelRepository = parcelRepository;
            DataContext = this;
        }

        private void LoadClientsButton_Click(object sender, RoutedEventArgs e)
        {
            var clients = _clientRepository.GetAll();
            Clients = new ObservableCollection<Client>(clients);
            ClientsDataGrid.ItemsSource = Clients;
        }

        private void LoadParcelsButton_Click(object sender, RoutedEventArgs e)
        {
            var parcels = _parcelRepository.GetAll();
            Parcels = new ObservableCollection<Parcel>(parcels);
            ParcelsDataGrid.ItemsSource = Parcels;
        }

        private void UpdateClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsDataGrid.SelectedItem is Client selectedClient)
            {
                selectedClient.Name = ClientNameTextBox.Text;
                selectedClient.Email = ClientEmailTextBox.Text;
                selectedClient.Phone = ClientPhoneTextBox.Text;

                _clientRepository.Update(selectedClient);
                ClientsDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a client to update.");
            }
        }

        private void DeleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsDataGrid.SelectedItem is Client selectedClient)
            {
                _clientRepository.Delete(selectedClient.Id);
                Clients.Remove(selectedClient);
            }
            else
            {
                MessageBox.Show("Please select a client to delete.");
            }
        }

        private void UpdateParcelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ParcelsDataGrid.SelectedItem is Parcel selectedParcel)
            {
                selectedParcel.Weight = int.Parse(ParcelWeightTextBox.Text);
                selectedParcel.Price = decimal.Parse(ParcelPriceTextBox.Text);
                //selectedParcel.DateSend = DateTime.Parse(ParcelDateSendTextBox.Text);
                //selectedParcel.DateCome = DateTime.Parse(ParcelDateComeTextBox.Text);
                //selectedParcel.PostOfficeSendId = int.Parse(PostOfficeSendTextBox.Text);
                //selectedParcel.PostOfficeComeId = int.Parse(PostOfficeComeTextBox.Text);

                _parcelRepository.Update(selectedParcel);
                ParcelsDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a parcel to update.");
            }
        }

        private void DeleteParcelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ParcelsDataGrid.SelectedItem is Parcel selectedParcel)
            {
                _parcelRepository.Delete(selectedParcel.Id);
                Parcels.Remove(selectedParcel);
            }
            else
            {
                MessageBox.Show("Please select a parcel to delete.");
            }
        }
    }
}
