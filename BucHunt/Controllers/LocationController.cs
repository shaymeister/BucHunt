using BucHunt.Models;
using System;
using System.Web.Mvc;

namespace BucHunt.Controllers
{
    public class LocationController : Controller
    {
        public ActionResult Locations()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Locations(LocationModel coordinates)
        {
            ViewBag.Message = string.Format("You Got The Right Location!!!");

            return View();
        }
    }
}