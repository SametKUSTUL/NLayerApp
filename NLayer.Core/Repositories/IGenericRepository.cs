using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task AddAsync(T entity);
        void Update(T entity); // Async methodu yok. çünkü sadece durumu değiştiriliyor
        void Remove(T entity); //Async methodu yok. çünkü sadece durumu değiştiriliyor
        void RemoveRange(IEnumerable<T> entities);

    }
}
