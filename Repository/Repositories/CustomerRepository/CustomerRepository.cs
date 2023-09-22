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


        

        public Customer? Find(string email)
        {
            return _context.Customers.FirstOrDefault(customer => customer.Email == email);

        }
    }

    
}
