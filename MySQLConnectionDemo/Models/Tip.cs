using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySQLConnectionDemo.Models
{
    public class Tip
    {
        public int TipId { get; set; }
        public string Ime { get; set; }
        public List<Produkt> Produkti { get; set; }
    }
}