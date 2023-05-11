using System.Linq.Expressions;

namespace DonationBank.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> Filter, string? includeproperties = null);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> ?Filter=null, string? includeProperties = null);
        void Add(T item);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> item);
    }
}
