using Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Course.Data.Interface
{
    public interface ICursusRepository
    {
        Task<Cursus> GetByIdAsync(int id);

        Task<Cursus> FirstOrDefaultAsync(Expression<Func<Cursus, bool>> predicate);

        void Add(Cursus entity);

        void Update(Cursus entity);

        void Remove(Cursus entity);

        Task<IEnumerable<Cursus>> GetAllAsync();

        void AddRange(IEnumerable<Cursus> entities);

        Task<IEnumerable<Cursus>> GetWhereAsync(Expression<Func<Cursus, bool>> predicate);

        Task SaveAsync();

        void Dispose();

        void Dispose(bool disposing);
    }
}
