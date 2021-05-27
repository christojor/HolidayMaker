using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holiday_Maker.Models;
using Microsoft.EntityFrameworkCore;

namespace Holiday_Maker.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _context = null;
        private DbSet<T> table = null;
        public GenericRepository()
        {
            this._context = new ApplicationDbContext();
            table = _context.Set<T>();
        }
        public GenericRepository(ApplicationDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();

        }
        public IQueryable<T> GetAllRaw()
        {
            return table;
        }
        public async Task<T> GetById(int id)
        {
            return await table.FindAsync(id);
        }
        public async Task<T> GetById(string id)
        {
            return await table.FindAsync(id);
        }
        public async Task Insert(T obj)
        {
            table.Add(obj);
            await Save();
        }
        public async Task Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            await Save();
        }
        public async Task Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
            await Save();
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
       
    }
}
