using Data;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork 
     {
        //private DbContext context;

        //public DbContext Context
        //{
        //    get
        //    {
        //        if (context == null)
        //            context =(DbContext)Activator.CreateInstance(typeof(T));
        //        return context; 
        //    }
        //    set { context = value; }
        //}
        private project2dbEntities context = new project2dbEntities();
       
        public int Save()
        {
            return context.SaveChanges();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            return new Repository<T>(context);
        }

        public void Dispose()
        {
            //GC.SuppressFinalize(this);
            //GC.Collect();
            context.Dispose();
        }
    }
}
