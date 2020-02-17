using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IBaseRepository<T>
    {
        void Save();

        T Update(T t, int id);

        IEnumerable<T> Select(Expression<Func<T, bool>> match = null);

        List<T> List();

        T getById(int id);

        void Add(T entity);

        void Delete(int id);

        void Edit(int id);

        T FindbyId(int? id);
    }
}
