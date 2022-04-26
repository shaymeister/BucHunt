// ---------------------------------------------------------------------------
// File name: CodeProcessor.cs
// Project name: BucHunt
// ---------------------------------------------------------------------------
// Creators: Carlos Ortiz						
// Course-Section: CSCI 4250-001
// Creation Date:		
// ---------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucHunt.Controllers
{
    /**
    * Class Name: CodeProcessor <br>
    * Class Purpose: Used to create random access codes for participants. 
    * Have not implemented checking if an access code exists yet 
    * 
    * 
    * <hr>
    * Date created:  <br>
    * @author Carlos Ortiz
    */
    public class CodeProcessor
    {
        private int codeLength = 6;
        private string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";


        /// <summary>Creates the random access code.</summary>
        /// <returns>
        ///   <para>The access code</para>
        /// </returns>
        public string CreateAccessCode()
        {
            // TODO: implement functionality to determine if the new codes are unique (hashtable?)
            Random rand = new Random();
            string accessCode = "";
            for(int x = 0; x < codeLength; x++)
            {
                accessCode += letters[rand.Next(letters.Length)];
            }
            return accessCode;
        }
    }
}
