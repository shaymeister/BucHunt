// add file header documentation

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucHunt.Controllers
{
    // add class docs
    public class CodeProcessor
    {
        private string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        
        // add method docs
        public string CreateAccessCode()
        {
            // TODO: implement functionality to determine if the new codes are unique (hashtable?)
            // extract hard coded 6 value out of loop
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
