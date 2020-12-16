//using Data;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
      //  private project2dbEntities entities = new project2dbEntities();
        public void Dispose()
        {
       //     entities.Dispose();
        }

        public int Save()
        {
            //  return entities.SaveChanges(); 
            return 1;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            return new Repository<T>();
        }
    }
}
