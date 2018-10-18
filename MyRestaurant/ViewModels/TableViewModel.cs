using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRestaurant.Models;

namespace MyRestaurant.ViewModels
{
    public class TableViewModel
    {
        public Table Table { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}