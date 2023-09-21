using DataAccess;

namespace Repositories.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        

        public readonly FucarRentingManagementContext _context;

        public GenericRepository()
        {
            _context = new();
        }
        public GenericRepository(FucarRentingManagementContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public T? Find(int id)
        {
            return _context.Set<T>().Find(id) as T;
        }

        public IEnumerable<T> Load() => _context.Set<T>();
        

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
