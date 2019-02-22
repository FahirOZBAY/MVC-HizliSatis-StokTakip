using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.Controllers
{
    [Authorize]

    public class KategoriController : Controller
    {
        // GET: Kategori
        Models ctx = new Models();

        public ActionResult Index()
        {
            List<Kategoriler> ktg  = ctx.Kategoriler.ToList();

            return View(ktg);
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Kategoriler k)
        {
            ctx.Kategoriler.Add(k);
            ctx.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpPost]
        public void Sil (int id)
        {
            Kategoriler k = ctx.Kategoriler.FirstOrDefault(x=>x.KategoriID==id);
            ctx.Kategoriler.Remove(k);
            ctx.SaveChanges();

        }

    }
}