using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucHunt.Models
{
    public class LocationModel
    { 
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string Completion { get; set; } //has the location been visited
        public string DecodedQR { get; set; } //the correct QR code
        public string UserEntry { get; set; } //QR code entered by the participant
    }
}