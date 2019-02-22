using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication6.App_Classes;

namespace WebApplication6.Controllers
{
    [Authorize]

    public class KullaniciController : Controller
    {
        // GET: Kullanici
        public ActionResult Index()
        {
           MembershipUserCollection users= Membership.GetAllUsers();

            return View(users);
        }
        public ActionResult Ekle() {

            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Kullanici k)
        {

            Membership.CreateUser(k.KullaniciAdi, k.Parola);
            return View();
        }
        [Authorize(Roles="Admin")]
        public ActionResult RolAta()
        {

            ViewBag.Roller = Roles.GetAllRoles().ToList();
            ViewBag.Kullanicilar = Membership.GetAllUsers();
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]

        public ActionResult RolAta(string KullaniciAdi,string RolAdi )
        {

            Roles.AddUserToRole(KullaniciAdi, RolAdi);
           return  RedirectToAction("Index");
        }
        [HttpPost]
        public string UyeRolleri (string kullaniciAdi)
        {
            List<string> roller=Roles.GetRolesForUser(kullaniciAdi).ToList();
            string rol = "";
            foreach (string r in roller)
            {
                rol += r + "-";
            }
            rol = rol.Remove(rol.Length - 1, 1);
            return rol;
        }
    }
}