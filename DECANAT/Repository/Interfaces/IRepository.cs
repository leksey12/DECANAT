using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECANAT.Repozitory
{
    interface IRepository<T,base_T> 
    {
        IEnumerable<base_T> GetAll(string querry = null);
        T Get(int id);
        void Create(base_T item);
        void Update(T item);
        void Delete(int id);
    }
}
