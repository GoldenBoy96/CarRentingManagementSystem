using BussinessObject.Models;
using Repositories.Repositories.CustomerRepository;
using Repositories.Repositories.RentingTransactionRepository;
using Service.AccountService;
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
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Window
    {
        Customer? _current;
        public UserProfile()
        {
            InitializeComponent();
            LoadData();
        }

        public Customer Current { get => _current; set => _current = value; }

        private void LoadData()
        {
            try
            {
                Current = CustomerRepository.Instance.Find(AccountService.Instance.CurrentAccount?.Email);
                tbCustomerId.Text = Current?.CustomerId.ToString();
                tbCustomerName.Text = Current?.CustomerName?.ToString();
                tbTelephone.Text = Current?.Telephone?.ToString();
                tbEmail.Text = Current?.Email.ToString();
                tbBirthday.Text = Current?.CustomerBirthday.ToString();
                tbStatus.Text = Current?.CustomerStatus.ToString();
            }
            catch (Exception) { }
        }

        private void btnViewTransactionHistory_Click(object sender, RoutedEventArgs e)
        {
            var next = new RentingTransactionHistory(Current.CustomerId); 
            next.ShowDialog();
        }
    }
}
