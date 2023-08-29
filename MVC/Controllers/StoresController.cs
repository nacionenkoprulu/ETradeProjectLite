#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Business.Contexts;
using Business.DataAccess.Entities;
using Business.DataAccess.Services;

namespace MVC.Controllers
{
    public class StoresController : Controller
    {
        // Add service injections here
        private readonly StoreServiceBase _storeService;

        public StoresController(StoreServiceBase storeService)
        {
            _storeService = storeService;
        }

        // GET: Stores
        public IActionResult Index()
        {
            List<Store> storeList = _storeService.Query().ToList();
            return View(storeList);
        }

        // GET: Stores/Details/5
        public IActionResult Details(int id)
        {
            Store store = _storeService.Query().SingleOrDefault(s => s.Id == id);
            if (store == null)
            {
                return View("_Error","Store not found!");
            }
            return View(store);
        }

        // GET: Stores/Create
        public IActionResult Create()
        {
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
                var result = _storeService.Add(store);
                if(result.IsSuccessfully)
                {
                    TempData["Message"] = result.Message;
					return RedirectToAction(nameof(Index));
				}
                ViewData["Message"] = result.Message;
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(store);
        }

        // GET: Stores/Edit/5
        public IActionResult Edit(int id)
        {
            Store store = _storeService.Query().SingleOrDefault(s => s.Id == id);
            if (store == null)
            {
                return View("_Error", "Store not found!");
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(store);
        }

        // POST: Stores/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Store store)
        {
            if (ModelState.IsValid)
            {
				var result = _storeService.Update(store);
                if (result.IsSuccessfully)
                {

                    TempData["Message"] = result.Message;
					return RedirectToAction(nameof(Index));

				}
                ViewData["Message"] = result.Message;
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(store);
        }

        // GET: Stores/Delete/5
        public IActionResult Delete(int id)
        {
            Store store = _storeService.Query().SingleOrDefault(s => s.Id == id);
            if (store == null)
            {
                return View("_Error", "Store not found!");
            }
            return View(store);
        }

        // POST: Stores/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var result = _storeService.Delete(s => s.Id == id);

            TempData["Message"]= result.Message;

            return RedirectToAction(nameof(Index));
        }
	}
}
