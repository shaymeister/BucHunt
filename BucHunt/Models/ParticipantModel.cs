using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Please Enter an Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Select a Service Provider")]
        public Providers provider { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please Enter a Phone Number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Enter a Phone Number that is Ten Digits Long")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Enter a Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your passwords do not match")]
        public string RetypePassWd { get; set; }
    }

    /// <summary>
    ///   <para>Sets up service providers for the users</para>
    /// </summary>
    public enum Providers
    {
        TMobile,
        Verizon,
        ATnT,
        Metro,
        Cricket,
        Sprint,
        Boost,
        Xfinity
    }
}