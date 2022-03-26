using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucHunt.Controllers
{
    public class CodeProcessor
    {
        private string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        public string CreateAccessCode()
        {
            Random rand = new Random();
            string accessCode = "";
            for(int x = 0; x < 6; x++)
            {
                accessCode += letters[rand.Next(letters.Length)];
            }
            return accessCode;
        }
    }
}