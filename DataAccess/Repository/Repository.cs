using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public void Add(T dto)
        {
            throw new NotImplementedException();
        }

        public void Delete(T dto)
        {
            throw new NotImplementedException();
        }

        public void Get()
        {
            throw new NotImplementedException();
        }

        public void Update(T dto)
        {
            throw new NotImplementedException();
        }
    }
}
