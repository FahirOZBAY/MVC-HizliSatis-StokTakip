using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        Models ctx = new Models();

        public ActionResult Sepet()
        {
            ViewBag.Kategoriler = ctx.Kategoriler.ToList<Kategoriler>();
            ViewBag.Urunler = ctx.Urunler.ToList<Urunler>();
            return View();
        }
        public ActionResult Sepet2()
        {
            ViewBag.Kategoriler = ctx.Kategoriler.ToList<Kategoriler>();
            ViewBag.Urunler = ctx.Urunler.ToList<Urunler>();
            return View();
        }
        public ActionResult Sepet3()
        {
            ViewBag.Kategoriler = ctx.Kategoriler.ToList<Kategoriler>();
            ViewBag.Urunler = ctx.Urunler.ToList<Urunler>();
            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Kategoriler = ctx.Kategoriler.ToList();
            ViewBag.Urunler = ctx.Urunler.ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult KategoriUrun()
        {
            return View(new Homevm

            {
                KategoriList = ctx.Kategoriler.ToList()



            });
        }

        public ActionResult KategoriUr(int? id)
        {
            ViewBag.Kurunler = ctx.Urunler.Where(x => x.KategoriID == id).ToList();

            return View();
        }

    }
}
  

