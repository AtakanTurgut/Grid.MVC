using Grid_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grid_MVC.Controllers
{
    public class HomeController : Controller
    {
        private static List<Person> _persons;

        // GET: Home
        public ActionResult Index()
        {
            if (_persons is null)
                _persons = Person.GetAllPersons(70);

            return View(_persons);
        }

        public ActionResult Index2()
        {
            if (_persons is null)
                _persons = Person.GetAllPersons(70);

            return View(_persons);
        }

        public JsonResult GetPersonsAjax()
        {
            List<string> names = new List<string>();

            /*
            names.Add("Atakan Turgut");
            names.Add("Furkan Uvenc");
            names.Add("Yagmur Soydan");
            */

            names.AddRange(_persons.Select(x => x.FullName));

            return Json(names);
        }
    }

}