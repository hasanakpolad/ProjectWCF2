using Data;
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
        private project2dbEntities _context = new project2dbEntities();
        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            return new Repository<T>(_context);
        }
    }
}
