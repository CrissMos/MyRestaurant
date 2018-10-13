using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRestaurant.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public RestaurantTable Table { get; set; }

        public int RestaurantTableId { get; set; }
    }
}