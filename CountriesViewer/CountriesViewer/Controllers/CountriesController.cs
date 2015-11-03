using CountriesViewer.Helpers;
using CountriesViewer.Models;
using CountriesViewer.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountriesViewer.Controllers
{
    public class CountriesController : Controller
    {
        CountryRepository repository = new CountryRepository();
        
        public ActionResult Index()
        {
            var countries = repository.GetAllCountries();
            return View(countries);
        }

        public PartialViewResult Details(string name)
        {
            var country = repository.GetCountry(name);
            return PartialView("_CountryDetailsPartial", country);
        }

        public ActionResult Create()
        {
            return View("CountryCreate");
        }

        [HttpPost]
        public ActionResult Create(Country country)
        {
            repository.AddCountry(country);
            return RedirectToAction("Index");
        }
	}
}