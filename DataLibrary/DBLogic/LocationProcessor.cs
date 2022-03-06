using BucHunt.Models;
using DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DBLogic
{
    internal class LocationProcessor
    {
        public static void CreateLocation(string locationName , string completion, string decodedQR, string userEntry)
        {
            LocationModel data = new LocationModel()
            {
                LocationName = locationName,
                Completion = completion,
                DecodedQR = decodedQR,
                UserEntry = userEntry
            };

            string sql = @" insert into dbo.Location (LocationName, Completion, DecodedQR, UserEntry)
                            values (@LocationName, @Completion, @DecodedQR, @UserEntry)";
            
            SqlDataAccess.SaveData(sql, data);
        }
    }
}
