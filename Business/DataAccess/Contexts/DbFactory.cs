using Business.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Scaffolding işlemleri için bu class oluşturulmalıdır.

namespace Business.DataAccess.Contexts
{
    public class DbFactory : IDesignTimeDbContextFactory<Db>
    {
        public Db CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Db>();
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=ETradeDB;user id=sa;password=sa;multipleactiveresultsets=true;trustservercertificate=true;");
            return new Db(optionsBuilder.Options); ;
        }
    }
}
