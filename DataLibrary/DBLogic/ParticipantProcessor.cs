using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DBLogic
{
    public static class ParticipantProcessor
    {
        public static void CreateParticipant(int accesscode, string firstname, string lastname,
            string emailaddress, int phonenumber)
        {
            ParticipantModel data = new ParticipantModel
            {
                AccessCode = accesscode,
                FirstName = firstname,
                LastName = lastname,
                Email = emailaddress,
                PhoneNumber = phonenumber
            };

            string sql = @"insert into dbo.Participant (AccessCode, FirstName, LastName, Email, PhoneNumber)
                        values (@AccessCode, @FirstName, @LastName, @Email, @PhoneNumber);";

            SqlDataAccess.SaveData(sql, data);
        }
    }
}
