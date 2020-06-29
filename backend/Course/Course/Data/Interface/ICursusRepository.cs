using Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Course.Data.Interface
{
    interface ICursusRepository
    {
        Task<Cursus> GetById(int id);

        Task<Cursus> FirstOrDefault(Expression<Func<Cursus, bool>> predicate);

        void Add(Cursus entity);

        void Update(Cursus entity);

        void Remove(Cursus entity);

        Task<IEnumerable<Cursus>> GetAllAsync();

        Task<IEnumerable<Cursus>> GetWhere(Expression<Func<Cursus, bool>> predicate);

        Task SaveAsync();
    }
}
