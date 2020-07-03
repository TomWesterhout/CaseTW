using Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Course.Data.Interface
{
    public interface ICursusInstantieRepository
    {
        Task<CursusInstantie> GetByIdAsync(int id);

        Task<CursusInstantie> FirstOrDefaultAsync(Expression<Func<CursusInstantie, bool>> predicate);

        void Add(CursusInstantie entity);

        void Update(CursusInstantie entity);

        void Remove(CursusInstantie entity);

        Task<IEnumerable<CursusInstantie>> GetAllAsync();

        void AddRange(IEnumerable<CursusInstantie> entities);

        Task<IEnumerable<CursusInstantie>> GetWhereAsync(Expression<Func<CursusInstantie, bool>> predicate);

        Task<IEnumerable<CursusInstantie>> GetByWeekAndYear(int week, int year);

        Task SaveAsync();

        void Dispose();

        void Dispose(bool disposing);
    }
}
