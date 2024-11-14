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


//namespace Post_office_management_system_3.Forms
//{
//public partial class ClientForm : Window
//{
//    private readonly ClientRepository _clientRepository;

//    public ClientForm(ClientRepository clientRepository)
//    {
//        InitializeComponent();
//        _clientRepository = clientRepository;
//    }

//    private async void ReadClientButton_Click(object sender, RoutedEventArgs e)
//    {
//        // Code to read client details based on ClientId
//    }

//    private async void UpdateClientButton_Click(object sender, RoutedEventArgs e)
//    {
//        // Code to update client information
//    }

//    private async void DeleteClientButton_Click(object sender, RoutedEventArgs e)
//    {
//        // Code to delete client
//        }
//    }

//}

//namespace Post_office_management_system_3.Forms
//{
//    public partial class ClientForm : Window
//    {
//        private readonly ParcelRepository _parcelRepository;
//        private readonly PostOfficeRepository _postOfficeRepository;
//        private readonly int _clientId; // Assuming client ID is passed to the form on creation
//        public ObservableCollection<Parcel> Parcels { get; set; }

//        public ClientForm(int clientId, ParcelRepository parcelRepository, PostOfficeRepository postOfficeRepository)
//        {
//            InitializeComponent();
//            _clientId = clientId;
//            _parcelRepository = parcelRepository;
//            _postOfficeRepository = postOfficeRepository;
//            ClientIdTextBox.Text = _clientId.ToString();
//            // Initialize data
//            LoadPostOffices();
//            LoadClientParcels();
//        }

//        private void LoadPostOffices()
//        {
//            var postOffices = _postOfficeRepository.GetAll();
//            PostOfficeSendComboBox.ItemsSource = postOffices;
//            PostOfficeComeComboBox.ItemsSource = postOffices;
//        }

//        private void LoadClientParcels()
//        {
//            var parcels = _parcelRepository.GetParcelsByClientId(_clientId);
//            Parcels = new ObservableCollection<Parcel>(parcels);
//            ParcelsDataGrid.ItemsSource = Parcels;
//        }

//        private void CreateParcelButton_Click(object sender, RoutedEventArgs e)
//        {
//            if (!decimal.TryParse(PriceTextBox.Text, out decimal price) ||
//                !int.TryParse(WeightTextBox.Text, out int weight) ||
//                DateSendPicker.SelectedDate == null ||
//                DateComePicker.SelectedDate == null ||
//                PostOfficeSendComboBox.SelectedItem == null ||
//                PostOfficeComeComboBox.SelectedItem == null)
//            {
//                MessageBox.Show("Please fill in all fields correctly.");
//                return;
//            }

//            var parcel = new Parcel
//            {
//                ClientId = _clientId,
//                Weight = weight,
//                Price = price,
//                DateSend = DateSendPicker.SelectedDate.Value,
//                DateCome = DateComePicker.SelectedDate.Value,
//                PostOfficeSendId = ((PostOffice)PostOfficeSendComboBox.SelectedItem).Id,
//                PostOfficeComeId = ((PostOffice)PostOfficeComeComboBox.SelectedItem).Id
//            };

//            _parcelRepository.Add(parcel);
//            Parcels.Add(parcel); // Add to the observable collection to update the UI
//            MessageBox.Show("Parcel created successfully.");
//        }
//    }
//}







//namespace Post_office_management_system_3.Forms
//{
//    public partial class ClientForm : Window
//    {
//        private readonly ParcelRepository _parcelRepository;
//        private readonly PostOfficeRepository _postOfficeRepository;
//        public ObservableCollection<Parcel> Parcels { get; set; }

//        public ClientForm(ParcelRepository parcelRepository, PostOfficeRepository postOfficeRepository)
//        {
//            InitializeComponent();
//            _parcelRepository = parcelRepository;
//            _postOfficeRepository = postOfficeRepository;

//            // Initialize data
//            LoadPostOffices();
//        }

//        private void LoadPostOffices()
//        {
//            var postOffices = _postOfficeRepository.GetAll();
//            PostOfficeSendComboBox.ItemsSource = postOffices;
//            PostOfficeComeComboBox.ItemsSource = postOffices;
//        }

//        //private void LoadClientParcels()
//        //{
//        //    if (!int.TryParse(ClientIdTextBox.Text, out int clientId) || clientId <= 0)
//        //    {
//        //        MessageBox.Show("Please enter a valid Client ID.");
//        //        return;
//        //    }

//        //    var parcels = _parcelRepository.GetParcelsByClientId(clientId);
//        //    Parcels = new ObservableCollection<Parcel>(parcels);
//        //    ParcelsDataGrid.ItemsSource = Parcels;
//        //}
//        private void LoadClientParcels()
//        {
//            if (!int.TryParse(ClientIdTextBox.Text, out int clientId) || clientId <= 0)
//            {
//                MessageBox.Show("Please enter a valid Client ID.");
//                return;
//            }

//            var parcels = _parcelRepository.GetParcelsByClientId(clientId) ?? new List<Parcel>();
//            Parcels = new ObservableCollection<Parcel>(parcels);
//            ParcelsDataGrid.ItemsSource = Parcels;
//        }

//        private void CreateParcelButton_Click(object sender, RoutedEventArgs e)
//        {
//            //if (!int.TryParse(ClientIdTextBox.Text, out int clientId) || clientId <= 0)
//            //{
//            //    MessageBox.Show("Please enter a valid Client ID.");
//            //    return;
//            //}

//            //if (!decimal.TryParse(PriceTextBox.Text, out decimal price) ||
//            //    !int.TryParse(WeightTextBox.Text, out int weight) ||
//            //    DateSendPicker.SelectedDate == null ||
//            //    DateComePicker.SelectedDate == null ||
//            //    PostOfficeSendComboBox.SelectedItem == null ||
//            //    PostOfficeComeComboBox.SelectedItem == null)
//            //{
//            //    MessageBox.Show("Please fill in all fields correctly.");
//            //    return;
//            //}

//            //var parcel = new Parcel
//            //{
//            //    ClientId = clientId,
//            //    Weight = weight,
//            //    Price = price,
//            //    DateSend = DateSendPicker.SelectedDate.Value,
//            //    DateCome = DateComePicker.SelectedDate.Value,
//            //    PostOfficeSendId = ((PostOffice)PostOfficeSendComboBox.SelectedItem).Id,
//            //    PostOfficeComeId = ((PostOffice)PostOfficeComeComboBox.SelectedItem).Id
//            //};

//            //try
//            //{
//            //    _parcelRepository.Add(parcel);
//            //    Parcels.Add(parcel); // Add to the observable collection to update the UI
//            //    MessageBox.Show("Parcel created successfully.");
//            //    LoadClientParcels(); // Refresh the list to show the new parcel
//            //}
//            //catch (Exception ex)
//            //{
//            //    MessageBox.Show($"Error creating parcel: {ex.Message}");
//            //}



//            if (!int.TryParse(ClientIdTextBox.Text, out int clientId) || clientId <= 0)
//            {
//                MessageBox.Show("Please enter a valid Client ID.");
//                return;
//            }

//            if (!decimal.TryParse(PriceTextBox.Text, out decimal price) ||
//                !int.TryParse(WeightTextBox.Text, out int weight) ||
//                DateSendPicker.SelectedDate == null ||
//                DateComePicker.SelectedDate == null ||
//                PostOfficeSendComboBox.SelectedItem == null ||
//                PostOfficeComeComboBox.SelectedItem == null)
//            {
//                MessageBox.Show("Please fill in all fields correctly.");
//                return;
//            }

//            // Ensure Parcels collection is initialized
//            if (Parcels == null)
//            {
//                Parcels = new ObservableCollection<Parcel>();
//                ParcelsDataGrid.ItemsSource = Parcels;
//            }

//            var parcel = new Parcel
//            {
//                ClientId = clientId,
//                Weight = weight,
//                Price = price,
//                DateSend = DateSendPicker.SelectedDate.Value,
//                DateCome = DateComePicker.SelectedDate.Value,
//                PostOfficeSendId = ((PostOffice)PostOfficeSendComboBox.SelectedItem).Id,
//                PostOfficeComeId = ((PostOffice)PostOfficeComeComboBox.SelectedItem).Id
//            };

//            try
//            {
//                _parcelRepository.Add(parcel);
//                Parcels.Add(parcel); // Add to the observable collection to update the UI
//                MessageBox.Show("Parcel created successfully.");
//                LoadClientParcels(); // Refresh the list to show the new parcel
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error creating parcel: {ex.Message}");
//            }
//        }
//    }
//}


namespace Post_office_management_system_3.Forms
{
    public partial class ClientForm : Window
    {
        private readonly ParcelRepository _parcelRepository;
        private readonly PostOfficeRepository _postOfficeRepository;
        public ObservableCollection<Parcel> Parcels { get; set; }

        public ClientForm(ParcelRepository parcelRepository, PostOfficeRepository postOfficeRepository)
        {
            InitializeComponent();
            _parcelRepository = parcelRepository;
            _postOfficeRepository = postOfficeRepository;

            LoadPostOffices();
        }

        private void LoadPostOffices()
        {
            var postOffices = _postOfficeRepository.GetAll();
            PostOfficeSendComboBox.ItemsSource = postOffices;
            PostOfficeComeComboBox.ItemsSource = postOffices;
        }

        private void LoadClientParcels()
        {
            if (!int.TryParse(ClientIdTextBox.Text, out int clientId) || clientId <= 0)
            {
                MessageBox.Show("Please enter a valid Client ID.");
                return;
            }

            var parcels = _parcelRepository.GetParcelsByClientId(clientId) ?? new List<Parcel>();
            Parcels = new ObservableCollection<Parcel>(parcels);
            ParcelsDataGrid.ItemsSource = Parcels;
        }

        private void ReadParcelsButton_Click(object sender, RoutedEventArgs e)
        {
            LoadClientParcels();
        }

        private void CreateParcelButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(ClientIdTextBox.Text, out int clientId) || clientId <= 0)
            {
                MessageBox.Show("Please enter a valid Client ID.");
                return;
            }

            if (!decimal.TryParse(PriceTextBox.Text, out decimal price) ||
                !int.TryParse(WeightTextBox.Text, out int weight) ||
                DateSendPicker.SelectedDate == null ||
                DateComePicker.SelectedDate == null ||
                PostOfficeSendComboBox.SelectedItem == null ||
                PostOfficeComeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields correctly.");
                return;
            }

            if (Parcels == null)
            {
                Parcels = new ObservableCollection<Parcel>();
                ParcelsDataGrid.ItemsSource = Parcels;
            }

            var parcel = new Parcel
            {
                ClientId = clientId,
                Weight = weight,
                Price = price,
                DateSend = DateSendPicker.SelectedDate.Value,
                DateCome = DateComePicker.SelectedDate.Value,
                PostOfficeSendId = ((PostOffice)PostOfficeSendComboBox.SelectedItem).Id,
                PostOfficeComeId = ((PostOffice)PostOfficeComeComboBox.SelectedItem).Id
            };

            _parcelRepository.Add(parcel);
            Parcels.Add(parcel);
        }
    }
}
