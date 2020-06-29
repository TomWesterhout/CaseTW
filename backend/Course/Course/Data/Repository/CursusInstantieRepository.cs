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
    class CursusInstantieRepository : ICursusInstantieRepository, IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<CursusInstantie> GetById(int id)
        {
            return await db.CursusInstantie.FindAsync(id);
        }

        public async Task<CursusInstantie> FirstOrDefault(Expression<Func<CursusInstantie, bool>> predicate)
        {
            return await db.CursusInstantie.FirstOrDefaultAsync(predicate);
        }

        public void Add(CursusInstantie entity)
        {
            db.CursusInstantie.Add(entity);
        }

        public void Update(CursusInstantie entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(CursusInstantie entity)
        {
            db.CursusInstantie.Remove(entity);
        }

        public async Task<IEnumerable<CursusInstantie>> GetAllAsync()
        {
            return await db.CursusInstantie.ToListAsync();
        }

        public async Task<IEnumerable<CursusInstantie>> GetWhere(Expression<Func<CursusInstantie, bool>> predicate)
        {
            return await db.CursusInstantie.Where(predicate).ToListAsync();
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
