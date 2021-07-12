using JS.CursoDDD.Domain.Entites;
using JS.CursoDDD.Domain.Interfaces;
using JS.CursoDDD.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace JS.CursoDDD.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SqlServerContext _selServerContext;

        public BaseRepository(SqlServerContext selServerContext)
        {
            _selServerContext = selServerContext;
        }

        public void Insert(TEntity obj)
        {
            _selServerContext.Set<TEntity>().Add(obj);
            _selServerContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _selServerContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _selServerContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _selServerContext.Set<TEntity>().Remove(Select(id));
            _selServerContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _selServerContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _selServerContext.Set<TEntity>().Find(id);

    }
}
