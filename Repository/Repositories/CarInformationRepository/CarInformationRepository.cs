using BussinessObject.Models;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Repositories.Repositories.CarInformationRepository
{
    public class CarInformationRepository : GenericRepository<CarInformation>, ICarInformationRepository
    {
        public static CarInformationRepository Instance { get; } = new();

        private CarInformationRepository()
        {
        }

        public void Create(CarInformation entity)
        {
            _context.CarInformations.Add(entity);
                _context.SaveChanges();
            
        }

        void IGenericRepository<CarInformation>.Update(CarInformation entity)
        {
            if (entity.CarId == 0)
            {
                Create(entity);
            }
            else
            {
                CarInformation? carInformation = _context.CarInformations
                  .Where(c => c.CarId == entity.CarId)
                  .FirstOrDefault();

                if (carInformation != null)
                {
                    _context.Entry(carInformation).CurrentValues.SetValues(entity);
                }
            }

            _context.SaveChanges();
        }
        
        public void Delete(CarInformation entity)
        {
            var carInformation = _context.CarInformations.FirstOrDefault(c => c.CarId == entity.CarId);
            if (carInformation != null)
            {
                _context.Entry(carInformation).State = EntityState.Deleted;
                _context.CarInformations.Remove(carInformation);
                _context.SaveChanges();
            }
        }

        public bool IsIdExisted(int carId)
        {
            if (!(Find(carId) == null)) return true;
            return false;
        }
    }
}
