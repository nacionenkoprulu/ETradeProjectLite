﻿using AppCoreLite.Business.DataAccess.EntityFramework.Bases;
using Business.Contexts;
using Business.DataAccess.Contexts;
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
    public abstract class CategoryServiceBase : Service<Category>
    {
        protected CategoryServiceBase(Db db) : base(db)
        {
        }
    }



    public class CategoryService : CategoryServiceBase
    {
        public CategoryService(Db db) : base(db)
        {
        }


        public override IQueryable<Category> Query(params Expression<Func<Category, object>>[] entitiesToIncludes)
        {
            return base.Query(entitiesToIncludes).OrderBy(c=>c.Name);
        }




    }
}
