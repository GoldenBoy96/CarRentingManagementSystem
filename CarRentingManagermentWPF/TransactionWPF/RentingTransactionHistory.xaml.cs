using BussinessObject.Models;
using Repositories.Repositories.CustomerRepository;
using Repositories.Repositories.RentingTransactionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Interaction logic for RentingTransactionHistory.xaml
    /// </summary>
    public partial class RentingTransactionHistory : Window
    {
        public RentingTransactionHistory(int customerId)
        {
            InitializeComponent();
            LoadData(customerId);
        }

        private void LoadData(int customerId)
        {
            dgTransactionData.ItemsSource = RentingTransactionRepository.Instance.Load(customerId);
        }

        private void dgTransactionData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMenu();
        }

        private void UpdateMenu()
        {

            try
            {
                RentingTransaction? rentingTransaction = dgTransactionData.SelectedItem as RentingTransaction;
                if (rentingTransaction != null)
                {
                    tbTransationId.Text = rentingTransaction.RentingTransationId.ToString();
                    tbRentingDate.Text = rentingTransaction.RentingDate.ToString();
                    tbTotalPrice.Text = rentingTransaction.TotalPrice.ToString();
                    tbRentingStatus.Text = rentingTransaction?.RentingStatus.ToString();
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
