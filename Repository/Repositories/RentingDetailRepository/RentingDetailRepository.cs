using BussinessObject.Models;
using DataAccess;

namespace Repositories.Repositories.RentingDetailRepository
{
    public class RentingDetailRepository : GenericRepository<RentingDetail>, IRentingDetailRepository
    {
        public static RentingDetailRepository Instance { get; } = new();

        private RentingDetailRepository()
        {
        }
    }
}
