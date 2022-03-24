using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BucHunt.Controllers;
using BucHunt.Models;

namespace BucHunt.Controllers
{
    public class HomeController : Controller
    {
        EmailProcess email = new EmailProcess();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult SignUp()
        {
            ViewBag.Title = "Sign Up";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(ParticipantModel participant)
        {
            if(ModelState.IsValid)
            {
                email.SendEmail(participant.Email);
                email.SendTexts(participant.PhoneNumber, participant.provider);
                ViewBag.Title = "Successful Sign Up";
                return RedirectToAction("SuccessfulSignUp", "Home");
            }
            

            return View();
        }
        public ActionResult SuccessfulSignUp()
        {
            ViewBag.Title = "Successful Sign Up";

            return View();
        }
        public ActionResult dummySignUp()
        {
            ViewBag.Title = "Dummy Sign Up";

            return View();
        }
    }
}