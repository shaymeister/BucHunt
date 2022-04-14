// add file header docs

using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucHunt.Controllers
{
    // add class docs
    public class EmailProcess
    {
        bool messageSent;
        /// <summary>Sends the email from the buchunt email to the emial the participant entered</summary>
        /// <param name="email">The email.</param>
        public bool SendEmail(string email, string accessCode)
        {
            //Sets up the message we are going to send to the participant
            string subject = "Here's you're access code";
            
            // extract BucHunt specific name and email addresses to variable
            string body = string.Format("Your access code to BucHunt is {0}", accessCode);
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
            
            // extract email password to variable
            client.Credentials = new NetworkCredential(from.Address, "Yowhat$good317");
            try
            {
                client.Send(message);
            }
            catch (SmtpFailedRecipientsException ex)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///   <para>
        /// Sends texts to the participant utilizing their phone provider and phone number</para>
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="p">The service provider</param>
        public bool SendTexts(string phoneNumber, Models.Providers p, string AccessCode)
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
                case Models.Providers.Verizon:
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
            messageSent = SendEmail(EmailAddress, AccessCode);
            return messageSent;
        }
    }
}
