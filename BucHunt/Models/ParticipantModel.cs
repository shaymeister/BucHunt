using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucHunt.Models
{

    /// <summary>The model for the participants</summary>
    public class ParticipantModel
    {
        public int AccessCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Providers provider { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    ///   <para>Sets up service providers for the users</para>
    /// </summary>
    public enum Providers
    {
        TMobile,
        Verison,
        ATnT,
        Metro,
        Cricket,
        Sprint,
        Boost,
        Xfinity
    }
}