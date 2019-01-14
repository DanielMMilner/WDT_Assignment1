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
                        StaffId = item["StaffID"].ToString(),
                        StudentId = item["BookedInStudentID"].ToString()
                    });
                }

                
            }
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

        public bool LoadDataFromDB()
        {
            return true;
        }


        /// <summary>
        /// Find the first slot that matches the given roomname and bookingdate
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="bookingDate"></param>
        /// <returns>The found Slot, Null if not found</returns>
        public Slot FindSlot(string roomName, DateTime bookingDate)
        {
            return Slots.Find(x => x.StartTime == bookingDate && x.RoomName == roomName);
        }


        public List<string> GetAvaliableRooms(DateTime date)
        {
            return Rooms.Except(GetSlotsOnDate(date).Select(x => x.RoomName)).ToList();
        }

        public List<Person> GetStaff()
        {
            return Users.Where(x => x.IsStaff).ToList();
        }

        public List<Person> GetStudents()
        {
            return Users.Where(x => !x.IsStaff).ToList();
        }

        public List<Slot> GetSlotsOnDate(DateTime date)
        {
            return Slots.Where(x => x.StartTime.Date == date.Date).ToList();
        }

        public bool CreateSlot(string roomName, DateTime bookingDate, string iD)
        {
            // Check slot does not already exist
            if (Slots.Any(x => x.StartTime == bookingDate))
            {
                return false;
            }

            // Check room is exists.
            if (!Rooms.Contains(roomName))
            {
                return false;
            }

            // Check id exists
            if (!Users.Any(x => x.Id == iD))
            {
                return false;
            }
            
            // Create a slot
            var newSlot = new Slot { RoomName = roomName, StartTime = bookingDate, StaffId = iD };

            bool res = ExecuteSql("INSERT INTO [dbo].[Slot] ([RoomID], [StartTime], [StaffID])" +
                    "VALUES(" +
                    $"(SELECT RoomID from [Room] where RoomID = '{newSlot.RoomName}')," +
                    $"'{newSlot.StartTime.ToString("yyyy-MM-dd HH:mm:ss")}'," +
                    $"(SELECT UserID from [User] where UserID = '{newSlot.StaffId}'))");

            if(res)
            {
                Slots.Add(newSlot);
                return true;
            }
            return false;
        }

        public bool RemoveSlot(string roomName, DateTime bookingDate)
        {
            // Check if the slot exists
            var slot = FindSlot(roomName, bookingDate);

            // If the slot does not exist we cannot remove it
            if(slot == null)
            {
                return false;
            }

            

            //TODO: talk to database and remove a slot if possible
            return true;
        }

        public bool MakeBooking(string roomName, DateTime bookingDate, string iD)
        {
            // Check that the room exists
            if(!Rooms.Contains(roomName))
            {
                return false;
            }

            // Check that the id exists
            if(!Users.Any(x => x.Id == iD))
            {
                return false;
            }

            var slot = FindSlot(roomName, bookingDate);
            // Check the slot exists
            if (slot == null)
            {
                return false;
            }
                        
            var res = ExecuteSql("UPDATE [dbo].[Slot] SET " +
                $"[BookedInStudentID] = (SELECT [User].[UserID] FROM [User] WHERE UserID = '{iD}') " +
                $"WHERE [RoomID] = '{roomName}' AND " +
                $"[StartTime] = '{bookingDate.ToString("yyyy-MM-dd hh:mm:ss")}'");

            // If the sql executes, update the local
            if(res)
            {
                slot.StudentId = iD;
                return true;
            }
            
            return false;
        }

        public bool CancelBooking(string roomName, DateTime bookingDate)
        {
            //TODO: talk to database and cancel a booking if possible
            return true;
        }
    }
}
