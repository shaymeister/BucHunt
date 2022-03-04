<<<<<<< Updated upstream
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BucHunt.Models;
using System.Net.Mail;
using System.Net;

namespace BucHunt.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult SignUp(ParticipantModel participant)
        {
            SendEmail(participant.Email);
            SendTexts(participant.PhoneNumber, participant.provider);
            return View();
        }

        /// <summary>Sends the email from the buchunt email to the emial the participant entered</summary>
        /// <param name="email">The email.</param>
        void SendEmail(string email)
        {
            //Sets up the message we are going to send to the participant
            string subject = "Here's you're access code";
            string body = "123231";
            MailAddress to = new MailAddress(email);
            MailAddress from = new MailAddress("buchunt2022@gmail.com");

            MailMessage message = new MailMessage(from, to);
            message.IsBodyHtml = false;
            message.Subject = subject;
            message.Body = body;

            //Creates the pathway to send our message to the participant
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(from.Address, "Yowhat$good317");
            try
            {
                client.Send(message);
            }
            catch (Exception)
            {

            }

            Console.WriteLine("Ayooooooo");
        }

        /// <summary>
        ///   <para>
        /// Sends texts to the participant utilizing their phone provider and phone number</para>
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="p">The service provider</param>
        void SendTexts(string phoneNumber, Models.Providers p)
        {
            string EmailAddress = "";
            //Creates the email string from their phone number and service provider
            switch (p)
            {
                case Models.Providers.TMobile:
                    {
                        EmailAddress = phoneNumber + "@vtext.com";
                        break;
                    }
                case Models.Providers.Verison:
                    {
                        EmailAddress = phoneNumber + "@tmomail.net";
                        break;
                    }
                case Models.Providers.ATnT:
                    {
                        EmailAddress = phoneNumber + "@txt.att.net";
                        break;
                    }
                case Models.Providers.Metro:
                    {
                        EmailAddress = phoneNumber + "@mymetropcs.com";
                        break;
                    }
                case Models.Providers.Cricket:
                    {
                        EmailAddress = phoneNumber + "@mms.mycricket.com";
                        break;
                    }
                case Models.Providers.Sprint:
                    {
                        EmailAddress = phoneNumber + "@messaging.sprintpcs.com";
                        break;
                    }
                case Models.Providers.Boost:
                    {
                        EmailAddress = phoneNumber + "@myboostmobile.com";
                        break;
                    }
                case Models.Providers.Xfinity:
                    {
                        EmailAddress = phoneNumber + "@vtext.com";
                        break;
                    }

            }
            SendEmail(EmailAddress);
        }
    }
=======
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
>>>>>>> Stashed changes
}