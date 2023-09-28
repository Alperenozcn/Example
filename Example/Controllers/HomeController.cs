using Dapper;
using Example.Entities;
using Example.Extensions;
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

            var skills = connection.Query<Skill>(sql: "ap_ListSkill", commandType:System.Data.CommandType.StoredProcedure);

            var services = connection.Query<Service>(sql: "Select * from Services");

            var serviceSlogan = connection.QuerySingle<Slogan>(commandType: System.Data.CommandType.StoredProcedure, sql: "ap_ListSlogan", param: new
            {
                @sectionName = "Services"
            });

            var skillSlogan = connection.QuerySingle<Slogan>(sql: "ap_ListSlogan", param: new
            {
                @sectionName = "Skills"
            },commandType: System.Data.CommandType.StoredProcedure);

            var reviews = connection.Query<CustomerReview>(sql: "ap_ListCustomerReviews", commandType: System.Data.CommandType.StoredProcedure);

            var viewModel = new IndexViewModel();

            viewModel.About = about;
            viewModel.Skills = skills;
            viewModel.Services = services;
            viewModel.ServiceSlogan = serviceSlogan;
            viewModel.SkillSlogan = skillSlogan;
            viewModel.CustomerReviews = reviews;

            //List<Skill> skills = new List<Skill>();
            //skills.AddDuplicate(new Skill() { Id = 1, Rate = 70, Title = "Bu kayıttan iki tane olması lazım" });

            //List<About> abouts = new List<About>();
            //abouts.AddDuplicate(new About { Id = 1 });

            //var kayit = skills;
            //var kayit2 = abouts;

            //skills.Count();

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

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            SqlConnection connection = new SqlConnection("server=ALPEREN\\ALPERENMSSQL; database=CvDb; integrated security=true");
            var affectedRows = connection.Execute(sql: "ap_CreateContact", commandType: System.Data.CommandType.StoredProcedure, param:contact);
            return RedirectToAction("Index");
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
        //public ActionResult Contact()
        //{
        //    return View();
        //}

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