using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.Controllers
{
    public class DenemeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddItem(string dataparam)
        {
            return PartialView("AddItem", dataparam);//view name optional if partial view name is addItem
        }
    }
}