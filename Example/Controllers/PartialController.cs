using Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult Products()
        {
            var product = new Product
            {
                Name = "Test",
                Price = 1000
            };
            return View(product);
        }
    }
}