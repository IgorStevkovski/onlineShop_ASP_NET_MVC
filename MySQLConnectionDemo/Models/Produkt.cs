using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySQLConnectionDemo.Models
{
    public class Produkt
    {
        public int ProduktId { get; set; }
        public string Ime { get; set; }
        public string SlikaIme { get; set; }
        public double Cena { get; set; }
        public double Popust { get; set; }
        public double Kolicina { get; set; }
        public int TipId { get; set; }
        public Tip Tip { get; set; }
        public List<Naracka> Naracki { get; set; }
    }
}