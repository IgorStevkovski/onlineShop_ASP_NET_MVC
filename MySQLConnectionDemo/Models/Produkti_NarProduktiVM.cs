using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySQLConnectionDemo.Models
{
    public class Produkti_NarProduktiVM
    {
        public List<Produkt> produkti { get; set; }
        public List<Produkt> narProdukti { get; set; }
    }
}