using MyRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyRestaurant.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(products);
        }

        public ActionResult Details(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }
    }
}