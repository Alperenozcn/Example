using Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.Controllers
{
    public class HomeController : Controller
    {
        private List<Product> products;

        public HomeController() 
        {
            products = new List<Product>
            {
                new Product(){Name = "Iphone 14", Price = 75000},
                new Product(){Name = "Samsung S23",Price= 40000}
            };

        }
        // GET: Home
        public ActionResult Index()
        {
            return View(products);
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}