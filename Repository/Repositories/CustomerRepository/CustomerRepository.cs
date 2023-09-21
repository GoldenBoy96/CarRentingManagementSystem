using BussinessObject.Models;
using DataAccess;

namespace Repositories.Repositories.CustomerRepository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        

        //Singleton
        public static CustomerRepository Instance { get; } = new();

        private CustomerRepository()
        {
        }


        List<Account> _accounts = new List<Account>();

        public void LoadAccount()
        {
            List<Customer> tmp = (List<Customer>)Load();
            foreach (Customer customer in tmp)
            {
                _accounts.Add(new(customer.Email, customer.Password, Role.Customer));
            }
        }

        public Customer? CheckLogin (string email, string password)
        {
            LoadAccount();
            foreach (Account account in _accounts) { 
                if (account.Email == email)
                {
                    account.Password = password;
                    return Find(email);
                }
            }
            //Find Admin account here
            return null;
        }

        public Customer? Find(string email)
        {
            return _context.Customers.FirstOrDefault(customer => customer.Email == email);

        }
    }

    public class Account
    {
        string _email;
        string _password;
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
