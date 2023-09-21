namespace Repositories.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        public void Add(T entity);
        public void Update(T entity);

        public void Remove(T entity);

        public T Find(int id);

        public IEnumerable<T> Load();

    }
}
