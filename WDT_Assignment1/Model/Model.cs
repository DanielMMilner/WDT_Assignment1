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

        public static string ConnString = "server=wdt2019.australiasoutheast.cloudapp.azure.com;UID=s3542686;PWD=abc123";

        public Model()
        {
            // Connect to the sql database and load all tables into memory
            using (var conn = new SqlConnection(Model.ConnString))
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

        public bool LoadDataFromDB()
        {
            return true;
        }

        public IEnumerable<string> GetAvaliableRooms(DateTime date)
        {
            return Rooms.Except(GetBookingsOnDate(date).Select(x => x.RoomName));
        }

        public IEnumerable<Slot> GetBookingsOnDate(DateTime date)
        {
            return Slots.Where(x => x.StartTime.Date == date.Date);
        }

        public bool CreateSlot(string roomName, DateTime bookingDate, string iD)
        {
            // Check slot does not already exist
            if (Slots.Any(x => x.StartTime.Date == bookingDate.Date))
            {
                return false;
            }

            // Check room is exists.
            if (!Rooms.Contains(roomName))
            {
                return false;
            }
           
            // Check booking date is valid
            if (!Slots.Any(x => x.StartTime.Date == bookingDate.Date))
            {
                return false;
            }

            // Check id exists
            if (!Users.Any(x => x.Id == iD))
            {
                return false;
            }
            
            // Create a slot
            var newSlot = new Slot { RoomName = roomName, StartTime = bookingDate, EndTime = bookingDate.AddHours(1), StaffId = iD };

            bool res = ExecuteSql("INSERT INTO [dbo].[Slot] ([RoomID], [StartTime], [EndTime], [StaffID])" +
                    "VALUES(" +
                    $"(SELECT RoomID from [Room] where RoomID = '{newSlot.RoomName}')," +
                    $"'{newSlot.StartTime.ToString("yyyy-MM-dd HH:mm:ss")}'," +
                    $"'{newSlot.EndTime.ToString("yyyy-MM-dd HH:mm:ss")}'," +
                    $"(SELECT UserID from [User] where UserID = '{newSlot.StaffId}'))");

            if(res)
            {
                Slots.Add(newSlot);
                return true;
            }
            return false;
        }

        private bool ExecuteSql(string str)
        {
            var rowsAffect = 0;
            using (var conn = new SqlConnection(Model.ConnString))
            {
                conn.Open();

                var cmd = new SqlCommand(str, conn);

                rowsAffect = cmd.ExecuteNonQuery();
            }

            if (rowsAffect != 0)
            {
                return true;
            }

            return false;
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
