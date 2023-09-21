using BussinessObject.Models;
using DataAccess;

namespace Repositories.Repositories.RentingTransactionRepository
{
    public class RentingTransactionRepository : GenericRepository<RentingTransaction>, IRentingTransactionRepository
    {
        public static RentingTransactionRepository Instance { get; } = new();

        private RentingTransactionRepository()
        {
        }

        public IEnumerable<RentingTransaction>? Load(int customerId)
        {
            return _context.Set<RentingTransaction>().Where(rentingTransaction => rentingTransaction.CustomerId == customerId).ToList();

        }
    }
}
