using BussinessObject.Models;
using Repositories.Repositories.CustomerRepository;
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
    /// Interaction logic for CustomerManagerment.xaml
    /// </summary>
    public partial class CustomerManagerment : Window
    {
        public CustomerManagerment()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgCustomerData.ItemsSource = CustomerRepository.Instance.Load().ToList();
        }

        private void dgCustomerData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMenu();
        }

        private void UpdateMenu()
        {

            try
            {
                Customer? customer = dgCustomerData.SelectedItem as Customer;
                if (customer != null)
                {
                    tbCustomerId.Text = customer.CustomerId.ToString();
                    if(customer.CustomerName != null) tbCustomerName.Text = customer.CustomerName.ToString();
                    if (customer.Telephone != null) tbTelephone.Text = customer.Telephone.ToString();
                    if (customer.CustomerBirthday != null) tbBirthday.Text = customer.CustomerBirthday.ToString();
                    if (customer.Email != null) tbEmail.Text = customer.Email.ToString();
                    if (customer.CustomerStatus != null) tbStatus.Text = customer.CustomerStatus.ToString();
                }
                
                
            }
            catch (Exception)
            {
                System.Diagnostics.Trace.Write("Hello via Trace!");
                return;
            }

        }
    }
}
