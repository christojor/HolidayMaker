using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Holiday_Maker.Models;


namespace Holiday_Maker.Repository
{
    public class GenericRepository <T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _ctx = null;
        private DbSet<T> _table = null;
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
