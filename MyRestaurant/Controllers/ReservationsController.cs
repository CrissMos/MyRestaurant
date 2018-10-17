using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MyRestaurant.Models;
using MyRestaurant.ViewModels;

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
            var reservevation = _context.Reservations.Include(c => c.Table).SingleOrDefault(r => r.Id == id);

            if (reservevation == null)
                return HttpNotFound();

            return View(reservevation);
        }

        public ActionResult New()
        {
            var tables = _context.Tables.ToList();
            var viewModel = new ReservationViewModel
            {
                Tables = tables
            };

            return View("ReservationForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Reservation reservation)
        {
            if (reservation.Id == 0)
                _context.Reservations.Add(reservation);
            else
            {
                var reservationInDb = _context.Reservations.Single(r => r.Id == reservation.Id);
                reservationInDb.Number = reservation.Number;
                reservationInDb.Name = reservation.Name;
                reservationInDb.Date = reservation.Date;
                reservationInDb.TableId = reservation.TableId;
            }
            //_context.Reservations.Add(reservation);
            _context.SaveChanges();

            return RedirectToAction("Index", "Reservations");
        }

        public ActionResult Edit(int id)
        {
            var reserve = _context.Reservations.SingleOrDefault(r => r.Id == id);

            if (reserve == null)
                return HttpNotFound();

            var viewModel = new ReservationViewModel
            {
                Reservation = reserve,
                Tables = _context.Tables.ToList()
            };

            return View("ReservationForm", viewModel);  
        }

        public ActionResult Delete(int id)
        {
            var reservation = _context.Reservations.SingleOrDefault(r => r.Id == id);

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}