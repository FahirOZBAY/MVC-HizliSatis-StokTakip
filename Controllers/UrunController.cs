using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.Controllers
{
    [Authorize]
    public class UrunController : Controller
    {
        Models ctx = new Models();
        public ActionResult UrunEkle()
        {
            ViewBag.Kategoriler = ctx.Kategoriler.ToList();
            ViewBag.Tedarikciler = ctx.Tedarikciler.ToList();
            return View();
        }

        public ActionResult Index()
        {
            List<Urunler> urunlers = ctx.Urunler.ToList();

            return View(urunlers);
        }
        
        public ActionResult Inndex()
        {
           
          
            {
                string i = "beverages";
            
                ViewBag[i] =ctx.Urunler.Where(x => x.KategoriID == 1).ToList();
                
            }

           ViewBag.Beveragess = ctx.Urunler.Where(x=>x.KategoriID==1).ToList();
            ViewBag.Urunler = ctx.Urunler.Where(x => x.KategoriID ==2).ToList();
            return View();
         
        }


        [HttpPost]
        public ActionResult UrunEkle(Urunler u)
        {
            ctx.Urunler.Add(u);
            ctx.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id)
        {
            Urunler u = ctx.Urunler.FirstOrDefault(x => x.UrunID == id);
            return View(u);
        }
        [HttpPost]
        public ActionResult Sil(Urunler u)
        {
            Urunler urn = ctx.Urunler.FirstOrDefault(x => x.UrunID == u.UrunID);
            ctx.Urunler.Remove(urn);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunDetay()
        {
            int id =Convert.ToInt32(Request.QueryString["id"].ToString());
            //string adi = Request.QueryString["adi"].ToString();
            Urunler u = ctx.Urunler.FirstOrDefault(x => x.UrunID == id);
                return View(u);

        }


    }

}