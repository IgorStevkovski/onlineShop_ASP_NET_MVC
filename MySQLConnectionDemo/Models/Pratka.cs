using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySQLConnectionDemo.Models
{
    public class Pratka
    {
        public int PratkaId { get; set; }
        public string PratkaIme { get; set; }
        public List<Naracka> Naracki { get; set; }
    }
}