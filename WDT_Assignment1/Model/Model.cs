using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace WDT_Assignment1
{
    class Model
    {
        public List<string> Rooms { get; private set; }
        public List<Person> Users { get; private set; }
        public List<Slot> Slots { get; private set; }
        
        public Model()
        {
            // Connect to the sql database and load all tables into memory
            using (var conn = new SqlConnection("server=wdt2019.australiasoutheast.cloudapp.azure.com;UID=s3542686;PWD=abc123"))
            {
                var userAdap = new SqlDataAdapter("SELECT * FROM dbo.[User]", conn);
                var slotAdap = new SqlDataAdapter("SELECT * FROM dbo.[Slot]", conn);
                var roomAdap = new SqlDataAdapter("SELECT * FROM dbo.[Room]", conn);

                var userData = new DataSet();
                var slotData = new DataSet();
                var roomData = new DataSet();

                userAdap.Fill(userData);
                slotAdap.Fill(slotData);
                roomAdap.Fill(roomData);

                Rooms = new List<string>();
                Users = new List<Person>();
                Slots = new List<Slot>();

                // Convert the DataSets into normal arrays
                foreach (DataRow item in userData.Tables[0].Rows)
                {
                    Users.Add(new Person { Id = item["UserID"].ToString(), Email = item["Email"].ToString(), Name = item["Name"].ToString() });
                }

                foreach (DataRow item in roomData.Tables[0].Rows)
                {
                    Rooms.Add(item["RoomID"].ToString());
                }

                foreach (DataRow item in slotData.Tables[0].Rows)
                {
                    Slots.Add(new Slot {
                        RoomName = item["RoomID"].ToString(),
                        StartTime = DateTime.Parse(item["StartTime"].ToString()),
                        EndTime = DateTime.Parse(item["EndTime"].ToString()),
                        StaffId = item["StaffID"].ToString(),
                        StudentId = item["BookedInStudentID"].ToString()
                    });
                }

                
            }
        }
        public IEnumerable<Slot> GetBookingsOnDate(DateTime date)
        {
            return Slots.Where(x => x.StartTime.Date == date.Date);
        }

        public bool CreateSlot(string roomName, DateTime bookingDate, string iD)
        {
            //TODO: talk to database and create a slot if possible
            return true;
        }

        public bool RemoveSlot(string roomName, DateTime bookingDate)
        {
            //TODO: talk to database and remove a slot if possible
            return true;
        }

        public bool MakeBooking(string roomName, DateTime bookingDate, string iD)
        {
            //TODO: talk to database and make a booking if possible
            return true;
        }

        public bool CancelBooking(string roomName, DateTime bookingDate)
        {
            //TODO: talk to database and cancel a booking if possible
            return true;
        }
    }
}
