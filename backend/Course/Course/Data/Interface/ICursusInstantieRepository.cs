using Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Course.Data.Interface
{
    interface ICursusInstantieRepository
    {
        Task<CursusInstantie> GetById(int id);

        Task<CursusInstantie> FirstOrDefault(Expression<Func<CursusInstantie, bool>> predicate);

        void Add(CursusInstantie entity);

        void Update(CursusInstantie entity);

        void Remove(CursusInstantie entity);

        Task<IEnumerable<CursusInstantie>> GetAllAsync();

        Task<IEnumerable<CursusInstantie>> GetWhere(Expression<Func<CursusInstantie, bool>> predicate);

        Task SaveAsync();
    }
}
