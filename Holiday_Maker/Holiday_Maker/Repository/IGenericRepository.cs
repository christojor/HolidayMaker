using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holiday_Maker.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> Get();
    }
}
