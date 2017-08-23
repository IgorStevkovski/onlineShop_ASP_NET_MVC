using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySQLConnectionDemo.Models
{
    public class Naracka
    {
        public int NarackaId { get; set; }
        public double Kolicina { get; set; }
        public int Kupeno { get; set; }
        public int? PratkaId { get; set; }
        public Pratka Pratka { get; set; }
        public int ProduktId { get; set; }
        public Produkt Produkt { get; set; }
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}