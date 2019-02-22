using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.Controllers
{
    [Authorize]

    public class TedarikciController : Controller
    {
        Models ctx = new Models();

        // GET: Tedarikci
        public ActionResult Index()
        {
            List<Tedarikciler> data = ctx.Tedarikciler.ToList();
            return View(data);
        }
        [HttpPost]
        public string Sil(int id)
        {
            Tedarikciler t = ctx.Tedarikciler.FirstOrDefault(x => x.TedarikciID == id);
            ctx.Tedarikciler.Remove(t);
            try
            {
                ctx.SaveChanges();
                return "başarılı";
            }
            catch (Exception)
            {
                return "hata";
                
            }


        }
    }
}