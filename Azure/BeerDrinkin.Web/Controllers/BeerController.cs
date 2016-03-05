using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using BeerDrinkin.Web.DataObjects;
using BeerDrinkin.Web.Models;

namespace BeerDrinkin.Web.Controllers
{
    public class BeerController : Controller
    {
        private ApplicationDbContext _context;

        public BeerController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Beer
        public IActionResult Index()
        {
            return View(_context.BeerItems.ToList());
        }

        // GET: Beer/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BeerItem beerItem = _context.BeerItems.Single(m => m.Id == id);
            if (beerItem == null)
            {
                return HttpNotFound();
            }

            return View(beerItem);
        }

        // GET: Beer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BeerItem beerItem)
        {
            if (ModelState.IsValid)
            {
                _context.BeerItems.Add(beerItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beerItem);
        }

        // GET: Beer/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BeerItem beerItem = _context.BeerItems.Single(m => m.Id == id);
            if (beerItem == null)
            {
                return HttpNotFound();
            }
            return View(beerItem);
        }

        // POST: Beer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BeerItem beerItem)
        {
            if (ModelState.IsValid)
            {
                _context.Update(beerItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beerItem);
        }

        // GET: Beer/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            BeerItem beerItem = _context.BeerItems.Single(m => m.Id == id);
            if (beerItem == null)
            {
                return HttpNotFound();
            }

            return View(beerItem);
        }

        // POST: Beer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            BeerItem beerItem = _context.BeerItems.Single(m => m.Id == id);
            _context.BeerItems.Remove(beerItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
