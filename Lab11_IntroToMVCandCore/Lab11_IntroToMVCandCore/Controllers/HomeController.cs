using Lab11_IntroToMVCandCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11_IntroToMVCandCore.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
		/// Default page of Home Controller where user inputs search
		/// </summary>
		/// <returns>Generated Home View</returns>
		[HttpGet]
        public ViewResult Index()
        {
            // Looks for the Razor View Page located in
            // Views -> Home -> Index.cshtml
            return View();
        }
        
        /// <summary>
        /// Post action for form submission of Time Person based on years searched
        /// </summary>
        /// <param name="start">start year</param>
        /// <param name="end">end year</param>
        /// <returns>Redirect to the Results</returns>
        [HttpPost]
        public IActionResult Index(int start, int end)
        {
            return RedirectToAction("Results", new { start, end });
        }

        public ViewResult Results (int start, int end)
        {
            List<TimePerson> persons = new List<TimePerson>();

            List<TimePerson> listofPeople = persons.Where(p => (p.Year >= start) && (p.Year <= end)).ToList();
            return View(listofPeople);
        }

    }
}

