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
		/// Default page of Home Controller
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
        /// Post action for form submission of Time Person information
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="year">year</param>
        /// <returns>Redirect to the Results</returns>
        [HttpPost]
        public IActionResult Index(string name, int year)
        {
            TimePerson timePerson = new TimePerson();
            return RedirectToAction("ViewImports", new { name, year });
        }

        public IActionResult ViewImports(string name, int year)
        {
            TimePerson timePerson = new TimePerson();

            return View(name);
        }

    }
}

