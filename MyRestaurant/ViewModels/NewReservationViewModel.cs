using MyRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRestaurant.ViewModels
{
    public class NewReservationViewModel
    {
        public IEnumerable<Table> Tables { get; set; }
        public Reservation Reservation { get; set; }
    }
}