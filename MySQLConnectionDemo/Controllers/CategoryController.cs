using MySQLConnectionDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;

namespace MySQLConnectionDemo.Controllers
{
    public class CategoryController : Controller
    {
        public ProdavnicaDbContext db = new ProdavnicaDbContext();

        // GET: /Category/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BelaTehnika(int tipId = 1)//pri klik na "Bela Tehnika" od meni
        {
            List<Produkt> produkti = db.Produkti.Where(d => d.TipId == tipId).ToList();

            string currentUserId = "";
            currentUserId = User.Identity.GetUserId();

            List<Produkt> naracaniProdukti = new List<Produkt>();
            if (currentUserId != "")
            {
                List<Naracka> naracki = db.Naracki.Where(n => n.ApplicationUserId == currentUserId && n.Kupeno == 0).ToList();

                foreach (Naracka nar in naracki)
                {
                    int narProduktId = nar.ProduktId;
                    Produkt narProdukt = db.Produkti.Find(narProduktId);//Where(p => p.ProduktId == narProduktId);
                    naracaniProdukti.Add(narProdukt);
                }

            }
            Produkti_NarProduktiVM obj = new Produkti_NarProduktiVM();
            obj.produkti = produkti;
            obj.narProdukti = naracaniProdukti;

            return View("BelaTehnika", obj);
            //return tipId;
        }

        //public ActionResult Hrana()
        //{
        //    //List<Produkt> produkti = db.Tipovi.Find(1).Produkti.ToList();
        //    return View("Hrana");
        //}

        public ActionResult Nakit(int tipId)
        {
            List<Produkt> produkti = db.Produkti.Where(d => d.TipId == tipId).ToList();

            string currentUserId = "";
            currentUserId = User.Identity.GetUserId();

            List<Produkt> naracaniProdukti = new List<Produkt>();
            if (currentUserId != "")
            {
                List<Naracka> naracki = db.Naracki.Where(n => n.ApplicationUserId == currentUserId && n.Kupeno == 0).ToList();

                foreach (Naracka nar in naracki)
                {
                    int narProduktId = nar.ProduktId;
                    Produkt narProdukt = db.Produkti.Find(narProduktId);//Where(p => p.ProduktId == narProduktId);
                    naracaniProdukti.Add(narProdukt);
                }

            }
            Produkti_NarProduktiVM obj = new Produkti_NarProduktiVM();
            obj.produkti = produkti;
            obj.narProdukti = naracaniProdukti;

            //return tipId;
            return View("Nakit",obj);
        }
        public ActionResult Obleka(int tipId)
        {
            List<Produkt> produkti = db.Produkti.Where(d => d.TipId == tipId).ToList();

            string currentUserId = "";
            currentUserId = User.Identity.GetUserId();

            List<Produkt> naracaniProdukti = new List<Produkt>();
            if (currentUserId != "")
            {
                List<Naracka> naracki = db.Naracki.Where(n => n.ApplicationUserId == currentUserId && n.Kupeno == 0).ToList();

                foreach (Naracka nar in naracki)
                {
                    int narProduktId = nar.ProduktId;
                    Produkt narProdukt = db.Produkti.Find(narProduktId);//Where(p => p.ProduktId == narProduktId);
                    naracaniProdukti.Add(narProdukt);
                }

            }
            Produkti_NarProduktiVM obj = new Produkti_NarProduktiVM();
            obj.produkti = produkti;
            obj.narProdukti = naracaniProdukti;

            //return tipId;
            return View("Obleka",obj);
        }

        //public ActionResult AddProduct()
        //{
        //    var model = new Produkt();//da bi view-to vo koe ima FORM tag vratilo Produkt objekt
        //    return View("AddProduct", model);
        //}

        //[HttpPost]
        //public string AddProduct(Produkt product,HttpPostedFileBase file)
        //{
        //    string ImageName = "";
        //    string physicalPath = "";
        //    if (file != null)
        //    {
        //        if(Path.GetExtension(file.FileName).ToLower()==".jpg" ||
        //            Path.GetExtension(file.FileName).ToLower() == ".jpeg" ||
        //            Path.GetExtension(file.FileName).ToLower() == ".gif" ||
        //            Path.GetExtension(file.FileName).ToLower() == ".png")
        //        {
        //            ImageName = Path.GetFileName(file.FileName);
        //            physicalPath = Path.Combine(Server.MapPath("~/Content/Images"), ImageName);

        //            file.SaveAs(physicalPath);//zacuvaj ja slikata
        //        }
                
        //    }
        //    Produkt p = new Produkt { Ime=product.Ime, Cena=product.Cena, Kolicina=product.Kolicina, SlikaIme=ImageName,TipId=product.TipId, Popust=1};
        //    db.Produkti.Add(p);
        //    db.SaveChanges();
        //    return product.Ime + " " + product.Cena + " " + product.TipId + " " + file.FileName + "<br>" + physicalPath;//ova da se smeni
        //}

        [Authorize]
        public ActionResult DodajKosnica(int productId, int categoryId)//pri klik na "DodajKosnica"
        {
            //string imeUser = User.Identity.Name;
            string currentUserId = User.Identity.GetUserId();
            Naracka naracka = new Naracka { ProduktId=productId, ApplicationUserId=currentUserId, Kolicina=1, Kupeno=0, PratkaId=null};
            db.Naracki.Add(naracka);
            db.SaveChanges();

            List<Produkt> produkti = db.Produkti.Where(p => p.TipId == categoryId).ToList();
            List<Naracka> naracki = db.Naracki.Where(n => n.ApplicationUserId == currentUserId && n.Kupeno == 0).ToList();
            List<Produkt> naracaniProdukti = new List<Produkt>();
            
            foreach(Naracka nar in naracki)
            {
                int narProduktId = nar.ProduktId;
                Produkt narProdukt = db.Produkti.Find(narProduktId);//Where(p => p.ProduktId == narProduktId);
                naracaniProdukti.Add(narProdukt);
            }

            Produkti_NarProduktiVM obj = new Produkti_NarProduktiVM();
            obj.produkti = produkti;
            obj.narProdukti = naracaniProdukti;

            if (categoryId == 1){
                return View("BelaTehnika", obj);
            }
            //else if (categoryId == 2)
            //{
            //    return View("Hrana");
            //}
            else if (categoryId == 3)
            {
                return View("Nakit", obj);
            }
            else
                return View("Obleka", obj);
            
        }

        [Authorize]
        public ActionResult Buy()// prik klik na "Kupi" vo kosnicata
        {
            string currentUserId = User.Identity.GetUserId();
            List<Naracka> naracki = db.Naracki.Where(n => n.ApplicationUserId == currentUserId && n.Kupeno == 0).ToList();
            
            List<Produkt> produkti = new List<Produkt>();
            double suma = 0;

            //sozdavanje na pratkata i update na narackatite od nea
            Pratka pratka = new Pratka();
            pratka.PratkaIme = currentUserId;
            db.Pratki.Add(pratka);
            db.SaveChanges();

            foreach(Naracka nar in naracki)
            {
                Produkt p = db.Produkti.Find(nar.ProduktId);//inace vo edna naracka ima samo 1 produkt
                suma += p.Cena;
                produkti.Add(p);
                // zemi go tukusto AVTOMATSKI dodadenoto IDENTITY value --CUDNO ALI RADI!!!
                int upravoDodanoId = pratka.PratkaId;
                nar.PratkaId = upravoDodanoId;
                //update-iranje deka narackata e kupena
                nar.Kupeno = 1;
                db.SaveChanges();

            }
            ViewBag.Suma = suma;
            return View("Buy", produkti);
        }

        [Authorize]
        public ActionResult BrisiOdKosnica(int tipId, int brisiProduktId)//pri klik na "Brisi" na naracan produkt vo kosnica
        {
            List<Produkt> produkti = db.Produkti.Where(d => d.TipId == tipId).ToList();

            string currentUserId = "";
            currentUserId = User.Identity.GetUserId();

            List<Produkt> naracaniProdukti = new List<Produkt>();
            if (currentUserId != "")
            {
                List<Naracka> naracki = db.Naracki.Where(n => n.ApplicationUserId == currentUserId && n.Kupeno == 0).ToList();

                foreach (Naracka nar in naracki)
                {
                    int narProduktId = nar.ProduktId;
                    if (narProduktId != brisiProduktId)
                    {
                        Produkt narProdukt = db.Produkti.Find(narProduktId);//Where(p => p.ProduktId == narProduktId);
                        naracaniProdukti.Add(narProdukt);
                    }
                    else//ako e narackata koja go ima produktot sto se brise, se brise toj cel Naracka objekt od baza
                    {
                        db.Naracki.Remove(nar);
                        db.SaveChanges();
                    }
                }

            }
            Produkti_NarProduktiVM obj = new Produkti_NarProduktiVM();
            obj.produkti = produkti;
            obj.narProdukti = naracaniProdukti;

            return View("BelaTehnika", obj);
        }
	}
}