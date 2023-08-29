using Business.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contexts
{
    public class Db : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Store> Stores { get; set; }


        public Db(DbContextOptions option) : base(option)
        {
            
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    string connectionString = "server=.\\SQLEXPRESS;database=ETradeDB;user id=sa;password=sa;multipleactiveresultsets=true;trustservercertificate=true;";

        //    optionsBuilder.UseSqlServer(connectionString);
        //}



    }
}
