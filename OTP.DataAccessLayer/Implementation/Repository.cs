using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using OTP.DataAccessLayer.Interface;

namespace OTP.DataAccessLayer.Implementation
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly NpgSqlDBContext _db;
        private DbSet<T> dbSet;

        public Repository(NpgSqlDBContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity).ConfigureAwait(true);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IQueryable<T> query = dbSet;
            return await query.ToListAsync().ConfigureAwait(true);
        }
    }
}




