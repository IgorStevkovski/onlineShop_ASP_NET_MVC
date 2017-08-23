using MySQLConnectionDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySQLConnectionDemo.Controllers
{
    [Authorize(Users="stevkovskigor2")]
    public class AdminController : Controller
    {
        private ProdavnicaDbContext db = new ProdavnicaDbContext();
        
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            var model = new Produkt();//da bi view-to vo koe ima FORM tag vratilo Produkt objekt
            return View("AddProduct", model);
        }

        [HttpPost]
        public ActionResult AddProduct(Produkt product, HttpPostedFileBase file)
        {
            string ImageName = "";
            string physicalPath = "";
            if (file != null)
            {
                if (Path.GetExtension(file.FileName).ToLower() == ".jpg" ||
                    Path.GetExtension(file.FileName).ToLower() == ".jpeg" ||
                    Path.GetExtension(file.FileName).ToLower() == ".gif" ||
                    Path.GetExtension(file.FileName).ToLower() == ".png")
                {
                    ImageName = Path.GetFileName(file.FileName);
                    physicalPath = Path.Combine(Server.MapPath("~/Content/Images"), ImageName);

                    file.SaveAs(physicalPath);//zacuvaj ja slikata
                }

            }
            Produkt p = new Produkt { Ime = product.Ime, Cena = product.Cena, Kolicina = product.Kolicina, SlikaIme = ImageName, TipId = product.TipId, Popust = 1 };
            db.Produkti.Add(p);
            db.SaveChanges();

            return View("Index");
            //return product.Ime + " " + product.Cena + " " + product.TipId + " " + file.FileName + "<br>" + physicalPath;//ova da se smeni
        }

        public ActionResult Edit(int tipId)
        {
            List<Produkt> produkti = db.Produkti.Where(d => d.TipId == tipId).ToList();
           
            ViewBag.ime = "";
            if (tipId == 1)
                ViewBag.ime = "Bela Tehnika";
            else if (tipId == 3)
                ViewBag.ime = "Nakit";
            else if (tipId == 4)
                ViewBag.ime = "Obleka";
            return View("Edit", produkti);
        }

        public ActionResult EditProduct(int produktId)//pri klik na "Edit" za produkti
        {
            Produkt nov = new Produkt();
            Produkt zaEdit = db.Produkti.Find(produktId);
            Produkt_NovProduktVM obj = new Produkt_NovProduktVM();
            obj.noVProdukt = nov;
            obj.produkt = zaEdit;
            return View("EditProduct", obj);
        }

        [HttpPost]
        public ActionResult EditProduct(Produkt product, HttpPostedFileBase file, string starProduktId)
        {
            //return starProduktId + " "+product.Ime +" "+ product.SlikaIme +" "+product.Kolicina;
            int starProduktId2 = Convert.ToInt32(starProduktId);

            Produkt p = db.Produkti.Find(starProduktId2);

            string ImageName = "";
            string physicalPath = "";
            if (file != null)
            {
                if (Path.GetExtension(file.FileName).ToLower() == ".jpg" ||
                    Path.GetExtension(file.FileName).ToLower() == ".jpeg" ||
                    Path.GetExtension(file.FileName).ToLower() == ".gif" ||
                    Path.GetExtension(file.FileName).ToLower() == ".png")
                {
                    ImageName = Path.GetFileName(file.FileName);
                    physicalPath = Path.Combine(Server.MapPath("~/Content/Images"), ImageName);

                    file.SaveAs(physicalPath);//zacuvaj ja slikata
                }
                p.SlikaIme = ImageName;
            }
            else
                p.SlikaIme = product.SlikaIme;

            
            p.Ime = product.Ime;
            p.Cena = product.Cena;
            p.Kolicina = product.Kolicina;
            p.TipId = product.TipId;
            db.SaveChanges();
            return RedirectToAction("Index","Admin");
        }

        public ActionResult DeleteProduct(int produktId)
        {
            Produkt p = db.Produkti.Find(produktId);
            db.Produkti.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
	}
}