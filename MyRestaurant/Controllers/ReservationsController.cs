using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MyRestaurant.Models;

namespace MyRestaurant.Controllers
{
    public class ReservationsController : Controller
    {
        private ApplicationDbContext _context;

        public ReservationsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Reservations
        public ActionResult Index()
        {
            var reservations = _context.Reservations.Include(r => r.Table).ToList();

            return View(reservations);
        }

        public ActionResult Details(int id)
        {
            var reserve = _context.Reservations.Include(c => c.Table).SingleOrDefault(r => r.Id == id);

            if (reserve == null)
                return HttpNotFound();

            return View(reserve);
        }
    }
}