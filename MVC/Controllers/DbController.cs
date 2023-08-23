using Business.Contexts;
using Business.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace MVC.Controllers
{
    public class DbController : Controller
    {

        private readonly Db _db;

        public DbController(Db db)
        {
            _db = db;
        }

        public IActionResult Seed()
        {

            var _products = _db.Products.ToList();
            _db.Products.RemoveRange(_products);

            var _categories = _db.Categories.ToList();
            _db.Categories.RemoveRange(_categories);

            _db.Categories.Add(new Category()
            {
                Name = "Computer",
                Description = "Laptops, desktops and computer peripherals",
                Products = new List<Product>()
                {

                    new Product()
                    {
                        Name = "Laptop",
                        UnitPrice = 3000.5,
                        ExpirationDate = new DateTime(2032,1,27),
                        StockAmount = 10,
                        IsContinued = true
                    },

                    new Product()
                    {
                        Name = "Mouse",
                        UnitPrice = 20.5,
                        StockAmount = 50,
                        Description = "Computers peripheral",
                        IsContinued = false
                    },
                    new Product()
                    {
                        Name = "Keyboard",
                        UnitPrice = 40,
                        StockAmount = 45,
                        Description = "Computer peripheral",
                        IsContinued = true

                    },
                    new Product()
                    {
                        Name = "Monitor",
                        UnitPrice = 2500,
                        ExpirationDate = DateTime.Parse("05/19/2027", new CultureInfo("en-US")),
                        StockAmount = 20,
                        Description = "Computer peripheral",
                        IsContinued = true
                    }
                }
            });

            _db.Categories.Add(new Category()
            {
                Name = "Home Theater System",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Name = "Speaker",
                        UnitPrice = 2500,
                        StockAmount = 70,
                        IsContinued = true
                    },
                    new Product()
                    {
                        Name = "Receiver",
                        UnitPrice = 5000,
                        StockAmount = 30,
                        Description = "Home theater system component",
                        IsContinued = false
                    },
                    new Product()
                    {
                        Name = "Equalizer",
                        UnitPrice = 1000,
                        StockAmount = 40,
                        IsContinued = true
                    }
                }
            });

            _db.SaveChanges();

            return Content("Datebase seed successful");
        }
    }
}
