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

        private ApplicationDbContext _ctx;
        private DbSet<T> _table;

        public GenericRepository()
        {
            _ctx = new ApplicationDbContext();
            _table = _ctx.Set<T>();
        }
            


        public IEnumerable<T> Get()
        {
            return _table.ToList();
        }
    }
}
