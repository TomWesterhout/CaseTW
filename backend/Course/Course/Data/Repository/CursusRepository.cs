using Course.Data.Interface;
using Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Course.Data.Repository
{
    class CursusRepository : ICursusRepository, IDisposable
    {
        private ApplicationDbContext db;

        public CursusRepository()
        {
        }

        public CursusRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<Cursus> GetByIdAsync(int id)
        {
            return await db.Cursus.FindAsync(id);
        }

        public async Task<Cursus> FirstOrDefaultAsync(Expression<Func<Cursus, bool>> predicate)
        {
            return await db.Cursus.FirstOrDefaultAsync(predicate);
        }

        public void Add(Cursus entity)
        {
            db.Cursus.Add(entity);
        }

        public void Update(Cursus entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(Cursus entity)
        {
            db.Cursus.Remove(entity);
        }

        public async Task<IEnumerable<Cursus>> GetAllAsync()
        {
            return await db.Cursus.ToListAsync();
        }

        public void AddRange(IEnumerable<Cursus> entities)
        {
            db.Cursus.AddRange(entities);
        }

        public async Task<IEnumerable<Cursus>> GetWhereAsync(Expression<Func<Cursus, bool>> predicate)
        {
            return await db.Cursus.Where(predicate).ToListAsync();
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
