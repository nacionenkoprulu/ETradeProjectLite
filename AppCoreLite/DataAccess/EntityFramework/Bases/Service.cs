using AppCoreLite.Results;
using AppCoreLite.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace AppCoreLite.DataAccess.EntityFramework.Bases
{

    //Repository pattern uygulayacağız.
    // Service --> Repository
    //CRUD işlemleri gerçekleştirilecek.

    public abstract class Service<TEntity> : IService<TEntity> where TEntity : Record, new()
    {

        protected readonly DbContext _db;

        protected Service(DbContext db)
        {
            _db = db;
        }

        public virtual IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] entitiesToIncludes)
        {
            IQueryable<TEntity> query = _db.Set<TEntity>().AsQueryable();

            foreach (var entityToInclude in entitiesToIncludes)
            {

                query = query.Include(entityToInclude);
                //Select ile projeksiyon yaptığın ThenInclude da yapıyor. O tabloyu da include ediyor.

            }
            return query;
        }

        //Query Metodunun koşullu overload'ı
        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] entitiesToIncludes)
        {
            var query = Query(entitiesToIncludes).Where(predicate);

            return query;
        }

        public virtual IQueryable<TEntity> QueryAsNoTracking(params Expression<Func<TEntity, object>>[] entitiesToIncludes)
        {
            return Query(entitiesToIncludes).AsNoTracking();
        }

        public virtual IQueryable<TEntity> QueryAsNoTrackingExpression(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] entitiesToIncludes)
        {
            return Query(entitiesToIncludes).Where(predicate);
        }

        //Eğer istenirse Query metodları üzerinden list ve tek bir entity dönecek metodlar da yazılabilir.

        public virtual Result Add(TEntity entity, bool save = true)
        {
            _db.Set<TEntity>().Add(entity);

            if (save)
            {
                Save();
                return new SuccessResult("Added successfully");
            }
            return new ErrorResult("Changes not saved!");
        }

        public virtual Result Update(TEntity entity, bool save = true)
        {
            throw new NotImplementedException();
        }

        public virtual Result Delete(Expression<Func<TEntity, bool>> predicate, bool save = true)
        {
            throw new NotImplementedException();
        }



        public virtual int Save()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (Exception exc)
            {
                //Logglama işlemleri yapılması gerekiyor.
                throw exc;
            }

        }

        public void Dispose()
        {
            _db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
