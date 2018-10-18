using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyRestaurant.Models
{
    public class Table
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name ="Number of Seats")]
        public int NumberOfSeats { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}