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

        [Display(Name ="Reservation Number")]
        public int Number { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Client Name")]
        public string Name { get; set; }

        public Table Table { get; set; }

        [Display(Name ="Table")]
        public int TableId { get; set; }

        public DateTime? Date { get; set; }
    }
}