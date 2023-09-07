using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.Controllers
{
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        public ActionResult Sevgul()
        {
            return View();
        }

        public ActionResult Alperen()
        {
            return View("Alperen");
        }

        public ActionResult yavuz()
        {
            return View();
        }
        public ActionResult Alperen(int id, string name)
        {
            //var yavuz = HttpContext.request.querystring["yavuz"];
            return View();
        }
    }
}