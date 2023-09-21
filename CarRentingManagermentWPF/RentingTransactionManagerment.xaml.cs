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
    /// Interaction logic for RentingTransactionManagerment.xaml
    /// </summary>
    public partial class RentingTransactionManagerment : Page
    {
        public RentingTransactionManagerment()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgTransactionData.ItemsSource = RentingTransactionRepository.Instance.Load().ToList();
        }

        private void dgTransactionData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMenu();
        }

        private void UpdateMenu()
        {

            try
            {
                RentingTransaction rentingTransaction = dgTransactionData.SelectedItem as RentingTransaction;
                if (rentingTransaction != null)
                {
                    tbCustomerId.Text = rentingTransaction.CustomerId.ToString();
                    tbCustomerName.Text = CustomerRepository.Instance.Find(Int32.Parse( rentingTransaction.CustomerId.ToString())).CustomerName.ToString();
                    if (rentingTransaction.RentingTransationId != null) tbTransationId.Text = rentingTransaction.RentingTransationId.ToString();
                    if (rentingTransaction.RentingDate != null) tbRentingDate.Text = rentingTransaction.RentingDate.ToString();
                    if (rentingTransaction.TotalPrice != null) tbTotalPrice.Text = rentingTransaction.TotalPrice.ToString();
                    if (rentingTransaction.RentingStatus != null) tbRentingStatus.Text = rentingTransaction.RentingStatus.ToString();


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
