using MySQLConnectionDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySQLConnectionDemo.Controllers
{
    public class HomeController : Controller
    {
        public ProdavnicaDbContext db = new ProdavnicaDbContext();

        public ActionResult Index()
        {
            return View();
        }

        //[Authorize(Users="stevkovskigor")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(); 
        }

        public ActionResult Contact()
        {
            Tip tip = db.Tipovi.Find(1);
            ViewBag.Message = "Your contact page.";

            
            return View(tip);
        }
    }
}