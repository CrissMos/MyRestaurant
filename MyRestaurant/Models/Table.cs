using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRestaurant.Models
{
    public class Table
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfSeats { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}