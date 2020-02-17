using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T:class
    {
        private Model1 ctx = new Model1();

        public void Save()
        {
            ctx.SaveChanges();
        }
        public virtual T Update(T t, int id)
        {
            if (t == null)
                return null;

            T exist = ctx.Set<T>().Find(id);
            if (exist != null)
            {
                ctx.Entry(exist).CurrentValues.SetValues(t);
                Save();
            }
            return exist;
        }
        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> match = null)
        {
            if (match == null)
                return ctx.Set<T>().ToList();
            else
                return ctx.Set<T>().Where(match).ToList();
        }

        public List<T> List()
        {

            return ctx.Set<T>().ToList();
        }
        public T getById(int id)
        {

            return ctx.Set<T>().Find(id);

        }
        public void Add(T entity)
        {

            ctx.Set<T>().Add(entity);
            Save();
        }
        public void Delete(int id)
        {
            T selectedId = ctx.Set<T>().Find(id);
            ctx.Set<T>().Remove(selectedId);
            Save();
        }

        public void Edit(int id)
        {
            T selectedId = ctx.Set<T>().Find(id);
            ctx.Set<T>().Attach(selectedId);
            ctx.Entry(selectedId).State = EntityState.Modified;
            Save();

        }
        public T FindbyId(int? id)
        {
            return ctx.Set<T>().Find(id);
        }
    }
}
