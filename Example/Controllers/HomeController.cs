using Dapper;
using Example.Entities;
using Example.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SqlConnection connection = new SqlConnection("server=ALPEREN\\ALPERENMSSQL; database=CvDb; integrated security=true");

            var about = connection.QueryFirst<About>(sql: "select * from About");


            //SqlCommand command = new SqlCommand();
            //command.Connection = connection;
            //command.CommandType = System.Data.CommandType.Text;
            //command.CommandText = "select * from About where Id = 1";

            //connection.Open();
            //var reader = command.ExecuteReader();
            //About about = new About();
            //while (reader.Read())
            //{
            //    about.Id = reader.GetInt32(0);
            //    about.Fullname = reader.GetString(1);
            //    about.JobTitle = reader.GetString(2);
            //    about.Description = reader.GetString(3);
            //    about.ImagePath = reader.IsDBNull(4)?"userprofile.jpg": reader.GetString(4);
            //    about.LınkedIn = reader.GetString(5);
            //    about.Gıt = reader.GetString(6);
            //    about.Instagram = reader.GetString(7);
            //    about.Twitter = reader.GetString(8);
            //}

            //connection.Close();
            //reader.Close();

            //var dataSingle = connection.QuerySingle(sql: "select * from Product");

            return View(about);
        }

        public ActionResult Portfolio()
        {
            SqlConnection connection = new SqlConnection("server=ALPEREN\\ALPERENMSSQL; database=CvDb; integrated security=true");
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "ap_ListSlogan";
            command.Parameters.Add("@sectionName","Skills");

            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var title = reader.GetString(2);
                var description = reader.GetString(3);
            }
            connection.Close();
            reader.Close();
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public string GetFirstElementName(List<Product>products)
        {
            return products[0].Name;
        }

        public string GetSingleElementName(Product product)
        {
            return product.Name;
        }
    }
}