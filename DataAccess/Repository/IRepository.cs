using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T dto);

        void Update(T dto);

        void Delete(T dto);

        T Get(int Id);
    }
}
