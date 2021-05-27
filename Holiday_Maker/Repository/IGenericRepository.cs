using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holiday_Maker.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        IQueryable<T> GetAllRaw();
        Task<T> GetById(int id);
        Task<T> GetById(string id);
        Task Insert(T obj);
        Task Update(T obj);
        Task Delete(int id);
        Task Save();
    }
}
