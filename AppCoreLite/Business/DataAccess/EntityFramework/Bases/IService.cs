using AppCoreLite.Results.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppCoreLite.Business.DataAccess.EntityFramework.Bases
{
    public interface IService<TEntity> : IDisposable where TEntity : Record, new()
    {
        //Temel sorgu metodumuz. İçine Include edeceklerimizi parametre olarak gönderiyoruz.
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] entitiesToIncludes);

        Result Add(TEntity entity, bool save = true);

        Result Update(TEntity entity, bool save = true);

        Result Delete(Expression<Func<TEntity, bool>> predicate, bool save = true); // Koşul üzerinde siliyor.
        //Exp: Delete(product=>product.Id==1)

        int Save();


    }
}
