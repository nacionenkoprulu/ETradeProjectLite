using AppCoreLite.Business.DataAccess.EntityFramework.Bases;
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
                Name = p.Name,
                StockAmount = p.StockAmount,
                Category = p.Category,

                UnitPriceDisplay = p.UnitPrice.ToString("C2", new CultureInfo("en-US")),
                IsContinuedDisplay = p.IsContinued ? "Yes" : "No",
                ExpirationDateDisplay = p.ExpirationDate.HasValue ? p.ExpirationDate.Value.ToString("MM/dd/yyyy", new CultureInfo("en-US")) : ""

            });
        }




    }
}
