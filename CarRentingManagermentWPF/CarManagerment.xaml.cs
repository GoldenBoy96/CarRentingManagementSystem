using BussinessObject.Models;
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
    public partial class CarManagerment : Page
    {
        public CarManagerment()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgCarData.ItemsSource = CarInformationRepository.Instance.Load().ToList();
        }

        private void dgCarData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMenu();
        }

        private void UpdateMenu()
        {

            try
            {
                CarInformation? rentingTransaction = dgCarData.SelectedItem as CarInformation;

                if (rentingTransaction != null)
                {
                    tbCarId.Text = rentingTransaction.CarId.ToString();
                    tbCarName.Text = rentingTransaction?.CarName.ToString();
                    tbCarDescription.Text = rentingTransaction?.CarDescription?.ToString();
                    tbNumberOfDoors.Text = rentingTransaction?.NumberOfDoors.ToString();
                    tbSeatingCapacity.Text = rentingTransaction?.SeatingCapacity.ToString();
                    tbFuelType.Text = rentingTransaction?.FuelType?.ToString();
                    tbYear.Text = rentingTransaction?.Year.ToString();
                    tbManufacturerId.Text = rentingTransaction?.ManufacturerId.ToString();
                    tbSupplierId.Text = rentingTransaction?.SupplierId.ToString();
                    tbCarStatus.Text = rentingTransaction?.CarStatus.ToString();
                    tbCarRentingPricePerDay.Text = rentingTransaction?.CarRentingPricePerDay?.ToString();

                }
                //Customer? customer = dgCustomerData.SelectedItem as Customer;
                //if (customer != null)
                //{
                //    tbCustomerId.Text = customer.CustomerId.ToString();
                //    if (customer.CustomerName != null) tbCustomerName.Text = customer.CustomerName.ToString();
                //    if (customer.Telephone != null) tbTelephone.Text = customer.Telephone.ToString();
                //    if (customer.CustomerBirthday != null) tbBirthday.Text = customer.CustomerBirthday.ToString();
                //    if (customer.Email != null) tbEmail.Text = customer.Email.ToString();
                //    if (customer.CustomerStatus != null) tbStatus.Text = customer.CustomerStatus.ToString();
                //}


            }
            catch (Exception)
            {
                System.Diagnostics.Trace.Write("Hello via Trace!");
                return;
            }

        }
    }
}
