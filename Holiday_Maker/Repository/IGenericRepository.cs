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
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        void Save();
    }
}
