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
        public static void CreateLocation(string name, string Location)
        {
            LocationModel data = new LocationModel()
            {
                Name = name,
                Location = Location
            };

            string sql = @" insert into dbo.Location (Name, Location)
                            values (@Name, @Location)";
            
            SqlDataAccess.SaveData(sql, data);
        }
    }
}
