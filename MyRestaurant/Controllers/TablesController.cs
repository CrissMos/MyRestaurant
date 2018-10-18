using MyRestaurant.Models;
using MyRestaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
            var table = _context.Tables.Include(m => m.Reservations).SingleOrDefault(t => t.Id == id);

            if (table == null)
                return HttpNotFound();

            var viewModel = new TableViewModel
            {
                Table = table,
                Reservations = _context.Reservations.ToList()
            };

            return View(viewModel);                                       
        }

        public ActionResult New()
        {
            var reservations = _context.Reservations.ToList();

            var viewModel = new TableViewModel
            {
                Reservations = reservations
            };

            return View("TableForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Table table)
        {
            if (table.Id == 0)
                _context.Tables.Add(table);
            else
            {
                var tableInDb = _context.Tables.Single(t => t.Id == table.Id);
                tableInDb.Name = table.Name;
                tableInDb.NumberOfSeats = table.NumberOfSeats;
                tableInDb.Reservations = table.Reservations;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Tables");
        }

        public ActionResult Edit(int id)
        {
            var table = _context.Tables.SingleOrDefault(t => t.Id == id);

            if (table == null)
                return HttpNotFound();

            var viewModel = new TableViewModel
            {
                Table = table,
                Reservations = _context.Reservations.ToList()
            };

            return View("TableForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var table = _context.Tables.SingleOrDefault(t => t.Id == id);

            _context.Tables.Remove(table);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}