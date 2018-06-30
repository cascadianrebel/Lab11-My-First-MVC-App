using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab11_My_First_MVC_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_My_First_MVC_App.Controllers
{
    public class HomeController : Controller
    {
        //the initial page view
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //posts the parameters for the query
        [HttpPost]
        public IActionResult Index(int begYear, int endYear)
        {
            return RedirectToAction("Results", new {startYear = begYear, finalYear = endYear });
        }

        public IActionResult Results(int startYear, int finalYear)
        {
            //allows me to send the results data to the view
            ViewData["Message"] = "Person of the year";

            Person Person = new Person();
            //Person.GetPeople(startYear, finalYear);
            //return View(Person);
            return View(Person.GetPeople(startYear, finalYear));
        }
    }
}
