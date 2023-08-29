using AppCoreLite.Business.DataAccess.EntityFramework.Bases;
using AppCoreLite.Results;
using AppCoreLite.Results.Bases;
using Business.Contexts;
using Business.DataAccess.Contexts;
using Business.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.DataAccess.Services
{
    public abstract class ProductServiceBase : Service<Product>
    {
        protected ProductServiceBase(Db db) : base(db)
        {
        }
    }


    public class ProductService : ProductServiceBase
    {
        public ProductService(Db db) : base(db)
        {
        }

        public override IQueryable<Product> Query(params Expression<Func<Product, object>>[] entitiesToIncludes)
        {
            return base.Query(entitiesToIncludes).Select(p=> new Product()
            {
                Id = p.Id,
                Guid = p.Guid,
                Name = p.Name,
                StockAmount = p.StockAmount,
                Category = p.Category,
                UnitPrice = p.UnitPrice,
                CategoryId = p.CategoryId,
                Description = p.Description,
                ExpirationDate = p.ExpirationDate,
                IsContinued = p.IsContinued,

                UnitPriceDisplay = p.UnitPrice.HasValue ? p.UnitPrice.Value.ToString("C2", new CultureInfo("en-US")): "",
                IsContinuedDisplay = p.IsContinued ? "Yes" : "No",
                ExpirationDateDisplay = p.ExpirationDate.HasValue ? p.ExpirationDate.Value.ToString("MM/dd/yyyy", new CultureInfo("en-US")) : ""

            });
        }


        public override Result Add(Product entity, bool save = true)
        {

            if(Query().Any(p=>p.Name.ToLower() == entity.Name.ToLower().Trim()))
            {
                return new ErrorResult("Product with the same name exists!");
            }
            entity.Name = entity.Name.Trim();
            entity.Description = entity.Description?.Trim();
            entity.IsContinued = true;
            return base.Add(entity, save);
        }

		public override Result Update(Product entity, bool save = true)
		{

            if (Query().Any(p => p.Name.ToLower() == entity.Name.ToLower().Trim() && p.Id != entity.Id))
                return new ErrorResult("Product with the same name exist!");

            entity.Name = entity.Name.Trim();
            entity.Description = entity.Description?.Trim();

			return base.Update(entity, save);
		}



	}
}
