using BucHunt.Models;
using System;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.Web.Helpers;

namespace BucHunt.Controllers
{

    /// <summary>
    ///   <para>Allows you to send emails</para>
    /// </summary>
    public class EmailController : Controller
    {

        /// <summary>Allows the user to see the sign up page</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public ActionResult SignUp()
        {
            return View();
        }
        /// <summary>
        ///   <para>
        /// Gets the information from the sign up page to send emails. The information is linked to the participant model</para>
        /// </summary>
        /// <param name="participant">The participant.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost]

        public ActionResult SignUp(ParticipantModel participant)
        {
           //SendEmail(participant.Email);
           //SendTexts(participant.PhoneNumber, participant.provider);
            return View();
        }
        /*
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
            switch(p)
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
        }*/

    }
}