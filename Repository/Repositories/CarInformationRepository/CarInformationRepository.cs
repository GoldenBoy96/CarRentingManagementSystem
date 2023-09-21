using BussinessObject.Models;
using DataAccess;

namespace Repositories.Repositories.CarInformationRepository
{
    public class CarInformationRepository : GenericRepository<CarInformation>, ICarInformationRepository
    {
        public static CarInformationRepository Instance { get; } = new();

        private CarInformationRepository()
        {
        }
    }
}
