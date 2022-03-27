using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DBLogic
{
    public static class LocationProcessor
    {
        public static void CreateLocation(string locationName , string completion, string decodedQR, string userEntry = "")
        {
            LocationModel data = new LocationModel()
            {
                LocationName = locationName,
                Completion = completion,
                DecodedQR = decodedQR,
                UserEntry = userEntry
            };

            string sql = @"insert into dbo.Location (LocationName, Completion, DecodedQR, UserEntry)
                            values (@LocationName, @Completion, @DecodedQR, @UserEntry)";
            
            SqlDataAccess.SaveData(sql, data);
        }

        public static List<LocationModel> LoadLocations()
        {
            string sql = "select Id, LocationName, Completion, DecodedQR, UserEntry from dbo.Location";

            return SqlDataAccess.LoadData<LocationModel>(sql);
        }

        public static List<LocationModel> LoadSingleLocation(int locId)
        {
            string sql = $"select Id, LocationName, Completion, DecodedQR, UserEntry from dbo.Location where id = {locId}";

            return SqlDataAccess.LoadSingleData<LocationModel>(sql);
        }

        public static void UpdateLocation(int locId, string locationName, string completion, string decodedQR, string userEntry)
        {
            LocationModel data = new LocationModel()
            {
                Id = locId,
                LocationName = locationName,
                Completion = completion,
                DecodedQR = decodedQR,
                UserEntry = userEntry
            };
            //Id = @Id, 
            string sql = @"update dbo.Location set LocationName = @LocationName, 
                            Completion = @Completion, DecodedQR = @DecodedQR, UserEntry = @UserEntry
                            where Id = @Id";

            SqlDataAccess.SaveData(sql, data);
        }

        public static void DeleteLocation(int locId)
        {
            string sql = $"delete from dbo.Location where Id = {locId}";

            SqlDataAccess.DeleteData(sql);
        }
    }
}
