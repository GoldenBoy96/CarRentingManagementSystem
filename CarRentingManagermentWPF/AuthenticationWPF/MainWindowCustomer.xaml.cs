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
    /// Interaction logic for MainWindowCustomer.xaml
    /// </summary>
    public partial class MainWindowCustomer : Window
    {
        public MainWindowCustomer()
        {
            InitializeComponent();
        }

        private void btnProfilePage_Click(object sender, RoutedEventArgs e)
        {
            var next = new UserProfile();
            next.ShowDialog();
        }
    }
}
