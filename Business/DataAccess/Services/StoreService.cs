using AppCoreLite.Business.DataAccess.EntityFramework.Bases;
using AppCoreLite.Results;
using AppCoreLite.Results.Bases;
using Business.Contexts;
using Business.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.DataAccess.Services
{
	public class StoreServiceBase : Service<Store>
	{
		public StoreServiceBase(Db db) : base(db)
		{
		}
	}


	public class StoreService : StoreServiceBase
	{
		public StoreService(Db db) : base(db)
		{
		}

		public override IQueryable<Store> Query(params Expression<Func<Store, object>>[] entitiesToIncludes)
		{
			return base.Query(entitiesToIncludes).Select(s => new Store()
			{
				Id = s.Id,
				Guid = s.Guid,
				Name = s.Name,
				IsVirtual = s.IsVirtual,

				IsVirtualDisplay = s.IsVirtual ? "Virtual" : "Real"

			});
		}


		public override Result Add(Store entity, bool save = true)
		{

			if(Query().Any(s=>s.Name.ToLower() == entity.Name.ToLower().Trim()))
			{
				return new ErrorResult("Store with the same name exists!");
			}
			entity.Name = entity.Name.Trim();

			return base.Add(entity, save);
		}

		public override Result Update(Store entity, bool save = true)
		{

			if(Query().Any(s=>s.Name.ToLower() == entity.Name.ToLower().Trim() && s.Id != entity.Id))
			{
				return new ErrorResult("Store with the same name exists!");
			}
			entity.Name = entity.Name.Trim();

			return base.Update(entity, save);
		}



	}
}
