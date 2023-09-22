using BussinessObject.Models;
using Repositories.Repositories.CustomerRepository;
using Service.AppSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AccountService
{
    public class AccountService
    {
        //Singleton
        public static AccountService Instance { get; } = new();

        private AccountService()
        {
        }

        Account? _currentAccount;

        List<Account> _accounts = new List<Account>();

        public List<Account> Accounts { get => _accounts; set => _accounts = value; }
        public Account CurrentAccount { get => _currentAccount; set => _currentAccount = value; }

        public void LoadAccount()
        {
            List<Customer> tmp = (List<Customer>)CustomerRepository.Instance.Load().ToList();
            foreach (Customer? customer in tmp)
            {
                Accounts.Add(new(customer.Email, customer.Password, Role.Customer));
            }
            Accounts.Add(new Account(AppSettingManager.Instance.AppSetting.DefaultAdmin.Email, AppSettingManager.Instance.AppSetting.DefaultAdmin.Password, Role.Admin));
        }

        public Account? CheckLogin(string email, string password)
        {
            LoadAccount();
            foreach (Account account in Accounts)
            {
                if (account.Email == email.Trim())
                {
                    if (account.Password == password.Trim())
                    {
                        CurrentAccount = account;
                        return account;
                    }
                    
                }
            }

            return null;
        }
    }
    public class Account
    {
        string? _email;
        string? _password;
        Role _role;

        public Account(string email, string password, Role role)
        {
            Email = email;
            Password = password;
            Role = role;
        }

        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public Role Role { get => _role; set => _role = value; }
    }

    public enum Role
    {
        Customer, Admin
    }
}
