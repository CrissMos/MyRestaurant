using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyRestaurant.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int Number { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Table Table { get; set; }

        public int TableId { get; set; }
    }
}