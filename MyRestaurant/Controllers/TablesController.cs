using MyRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyRestaurant.Controllers
{
    public class TablesController : Controller
    {
        private ApplicationDbContext _context;

        public TablesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Tables
        public ActionResult Index()
        {
            var tables = _context.Tables.ToList();

            return View(tables);
        }

        public ActionResult Details(int id)
        {
            var table = _context.Tables.SingleOrDefault(t => t.Id == id);

            if (table == null)
                return HttpNotFound();

            return View(table);
        }
    }
}