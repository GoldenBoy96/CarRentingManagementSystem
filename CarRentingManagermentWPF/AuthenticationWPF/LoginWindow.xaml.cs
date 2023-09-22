using MaterialDesignThemes.Wpf;
using Service.AccountService;
using Service.AppSetting;
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
using Role = Service.AccountService.Role;

namespace CarRentingManagermentWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            if (AppSettingManager.Instance.AppSetting == null)
            {
                AppSettingManager.Instance.GenerateDefaultAppSettingFile();
            }

            AppSettingManager.Instance.ReadAppSettingFile();
        }

        public void Login(string email, string password)
        {
            AccountService.Instance.CheckLogin(email, password);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (tbEmail.Text.Length > 0 && tbPassword.SecurePassword.Length > 0)
            {
                if (AccountService.Instance.CheckLogin(tbEmail.Text, tbPassword.Password.ToString()) != null)
                {
                    if (AccountService.Instance.CurrentAccount.Role == Role.Customer)
                    {
                        var next = new MainWindowCustomer();
                        this.Close();
                        next.ShowDialog();
                    }
                    else if (AccountService.Instance.CurrentAccount.Role == Role.Admin)
                    {
                        var next = new MainWindowAdmin();
                        this.Close();
                        next.ShowDialog();
                    }

                }
            }
        }
    }
}
