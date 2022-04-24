using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BucHunt.Controllers;
using BucHunt.Models;
using DataLibrary.DBLogic;

namespace BucHunt.Controllers
{
    public class HomeController : Controller
    {
        EmailProcess email = new EmailProcess();
        CodeProcessor code = new CodeProcessor();
        string AccessCode;

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
                //Sends Access Code to the participants through email and text
                AccessCode = code.CreateAccessCode();
                email.SendEmail(participant.Email, AccessCode);
                if(email.SendTexts(participant.PhoneNumber, participant.provider, AccessCode))
                {
                    ViewBag.Title = "Successful Sign Up";
                    return RedirectToAction("SuccessfulSignUp", "Home", new { AccessCode });
                }
                else //Sends message if the text does not successfully send
                {
                    ViewBag.Error = "Text Message Did Not Send.\nTry Again";
                }
            }
            

            return View();
        }
        public ActionResult SuccessfulSignUp(string accesscode)
        {
            ViewBag.Title = "Successful Sign Up";
            ViewBag.AccessCode = accesscode;
            return View();
        }
        public ActionResult dummySignUp()
        {
            ViewBag.Title = "Dummy Sign Up";

            return View();
        }
    }
}