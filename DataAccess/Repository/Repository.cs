//using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //private project2dbEntities _entities;
     //   private DbSet<T> _dbSet;
     //   public Repository(project2dbEntities entities)
     //   {
          //  _entities = entities;
          //  _dbSet = _entities.Set<T>();
      //  }
        public void Add(T dto)
        {
           // _dbSet.Add(dto);
        }

        public void Delete(T dto)
        {
          //  _dbSet.Remove(dto);
        }

        public T Get()
        {
            //  return _dbSet.Find();
            throw new NotImplementedException();
        }

        public void Update(T dto)
        {
          //  _dbSet.Attach(dto);
          //  _entities.Entry(dto).State = EntityState.Modified;
        }
    }
}
