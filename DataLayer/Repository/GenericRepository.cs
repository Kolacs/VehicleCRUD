using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private VehicleContext Context { get; set; }
        private DbSet<T> Table { get; set; }

        public GenericRepository(VehicleContext context)
        {
            Context = context;
            Table = Context.Set<T>();
        }

        public void Create(T entity)
        {
            Table.Add(entity);
            Savechanges();
        }
        public void Delete(T entity)
        {
            Table.Remove(entity);
            Savechanges();
        }
        public void Update(T entity)
        {
            Table.Update(entity);
            Savechanges();
        }
        public T Read(string id)
        {
            return Table.Find(id);
        }
        public IEnumerable<T> ReadAll()
        {
            return Table;
        }
        public void Savechanges()
        {
            Context.SaveChanges();
        }
    }
}
