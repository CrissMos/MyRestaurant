using MyRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyRestaurant.Controllers.Api
{
    public class ReservationsController : ApiController
    {
        private ApplicationDbContext _context;

        public ReservationsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/reservations
        public IEnumerable<Reservation> GetReservations()
        {
            return _context.Reservations.ToList();
        }

        // GET /api/reservations/1
        public Reservation GetReservation(int id)
        {
            var reservation = _context.Reservations.SingleOrDefault(r => r.Id == id);

            if (reservation == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return reservation;
        }

        // POST /api/reservations
        [HttpPost]
        public Reservation CreateReservation(Reservation reservation)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            return reservation;
        }

        // PUT /api/reservation/1
        [HttpPut]
        public void UpdateReservation(int id, Reservation reservation)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var reservationInDb = _context.Reservations.SingleOrDefault(r => r.Id == id);

            if (reservationInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            reservationInDb.Name = reservation.Name;
            reservationInDb.Number = reservation.Number;
            reservationInDb.TableId = reservation.TableId;

            _context.SaveChanges();
        }

        // DELETE /api/reservation/1
        [HttpDelete]
        public void DeleteReservation(int id)
        {
            var reservationInDb = _context.Reservations.SingleOrDefault(r => r.Id == id);

            if (reservationInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Reservations.Remove(reservationInDb);
            _context.SaveChanges();
        }
    }
}
