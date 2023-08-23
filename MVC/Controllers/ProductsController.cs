﻿#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Business.Contexts;
using Business.DataAccess.Entities;
using Business.DataAccess.Services;

namespace MVC.Controllers
{
    public class ProductsController : Controller
    {
        // Add service injections here
        private readonly ProductServiceBase _productService;

        public ProductsController(ProductServiceBase productService)
        {
            _productService = productService;
        }

        // GET: Products
        public IActionResult Index()
        {
            List<Product> productList = _productService.Query(p => p.Category).ToList(); // TODO: Add get list service logic here
            return View(productList);
        }

        // GET: Products/Details/5
        public IActionResult Details(int id)
        {
            Product product = null; // TODO: Add get item service logic here
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["CategoryId"] = new SelectList(null, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                return RedirectToAction(nameof(Index));
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["CategoryId"] = new SelectList(null, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int id)
        {
            Product product = null; // TODO: Add get item service logic here
            if (product == null)
            {
                return NotFound();
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["CategoryId"] = new SelectList(null, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                return RedirectToAction(nameof(Index));
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["CategoryId"] = new SelectList(null, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int id)
        {
            Product product = null; // TODO: Add get item service logic here
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            return RedirectToAction(nameof(Index));
        }
	}
}
