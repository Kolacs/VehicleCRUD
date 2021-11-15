using System.Collections.Generic;

namespace DataLayer.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T entity);
        void Delete(T entity);
        T Read(string id);
        IEnumerable<T> ReadAll();
        void Savechanges();
        void Update(T entity);
    }
}