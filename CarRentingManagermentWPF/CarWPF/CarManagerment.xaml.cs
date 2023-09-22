using BussinessObject.Models;
using CarRentingManagermentWPF.CarWPF;
using MyUtils;
using Repositories.Repositories.CarInformationRepository;
using Repositories.Repositories.RentingTransactionRepository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRentingManagermentWPF
{
    /// <summary>
    /// Interaction logic for CarManagerment.xaml
    /// </summary>
    public partial class CarManagerment : Window
    {
        public CarManagerment()
        {
            InitializeComponent();
            LoadData();
            dgCarData.SelectedIndex = 0;
        }

        public void LoadData()
        {
            List<CarInformation> carInformations = CarInformationRepository.Instance.Load().ToList();
            dgCarData.ItemsSource = carInformations;
        }

        private void dgCarData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMenu();
        }

        private void UpdateMenu()
        {

            try
            {
                CarInformation? carInformation = dgCarData.SelectedItem as CarInformation;

                if (carInformation != null)
                {
                    tbCarId.Text = carInformation.CarId.ToString();
                    tbCarName.Text = carInformation?.CarName.ToString();
                    tbCarDescription.Text = carInformation?.CarDescription?.ToString();
                    tbNumberOfDoors.Text = carInformation?.NumberOfDoors.ToString();
                    tbSeatingCapacity.Text = carInformation?.SeatingCapacity.ToString();
                    tbFuelType.Text = carInformation?.FuelType?.ToString();
                    tbYear.Text = carInformation?.Year.ToString();
                    tbManufacturerId.Text = carInformation?.ManufacturerId.ToString();
                    tbSupplierId.Text = carInformation?.SupplierId.ToString();
                    tbCarStatus.Text = carInformation?.CarStatus.ToString();
                    tbCarRentingPricePerDay.Text = carInformation?.CarRentingPricePerDay?.ToString();

                }


            }
            catch (Exception)
            {
                System.Diagnostics.Trace.Write("Hello via Trace!");
                return;
            }

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var next = new CarCreate(this);
            next.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var next = new CarEdit(this, (CarInformation)dgCarData.SelectedItem );
            next.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgCarData.SelectedItem != null)
            {
                CarInformation? carInformation = dgCarData.SelectedItem as CarInformation;

                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Trace.WriteLine(carInformation.CarId);
                    CarInformationRepository.Instance.Delete(carInformation);
                    LoadData();
                }
            }
            
        }

        
    }
}
