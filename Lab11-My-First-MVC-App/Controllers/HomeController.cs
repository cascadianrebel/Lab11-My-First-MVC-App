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
        /// <summary>
        /// initiate page view
        /// </summary>
        /// <returns>View Index Page</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //posts the parameters for the query
        /// <summary>
        /// queries database with given parameters
        /// </summary>
        /// <param name="begYear">Beginning Year</param>
        /// <param name="endYear">Ending Year</param>
        /// <returns>results page data</returns>
        [HttpPost]
        public IActionResult Index(int begYear, int endYear)
        {
            return RedirectToAction("Results", new {startYear = begYear, finalYear = endYear });
        }

        /// <summary>
        /// Displays the results of the data query
        /// </summary>
        /// <param name="startYear">beginning year</param>
        /// <param name="finalYear">ending year</param>
        /// <returns></returns>
        public IActionResult Results(int startYear, int finalYear)
        {
            //allows me to send the results data to the view
            ViewData["Message"] = "Person of the year";

            Person Person = new Person();

            return View(Person.GetPeople(startYear, finalYear));
        }
    }
}
