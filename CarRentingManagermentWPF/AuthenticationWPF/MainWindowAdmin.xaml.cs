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
    /// Interaction logic for MainWindowAdmin.xaml
    /// </summary>
    public partial class MainWindowAdmin : Window
    {
        public MainWindowAdmin()
        {
            InitializeComponent();
        }

        private void btnCarManagermentPage_Click(object sender, RoutedEventArgs e)
        {
            var next = new CarManagerment();
            next.ShowDialog();
        }

        private void btnCustomerManagermentPage_Click(object sender, RoutedEventArgs e)
        {
            var next = new CustomerManagerment();
            next.ShowDialog();
        }

        private void btnTransactionManagermentPage_Click(object sender, RoutedEventArgs e)
        {
            var next = new RentingTransactionManagerment();
            next.ShowDialog();
        }

        private void btnReportStatisticPage_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        
    }
}
