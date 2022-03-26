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
            string emailaddress, string phonenumber, string password)
        {
            ParticipantModel data = new ParticipantModel
            {
                AccessCode = accesscode,
                FirstName = firstname,
                LastName = lastname,
                Email = emailaddress,
                PhoneNumber = phonenumber,
                Password = password
            };

            string sql = @"insert into dbo.Participant (AccessCode, FirstName, LastName, Email, PhoneNumber)
                        values (@AccessCode, @FirstName, @LastName, @Email, @PhoneNumber, @Password);";

            SqlDataAccess.SaveData(sql, data);
        }
    }
}
