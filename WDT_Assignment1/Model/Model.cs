using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WDT_Assignment1
{
    class Model
    {
        public List<string> Rooms { get; private set; }
        public List<Person> Users { get; private set; }
        public List<Slot> Slots { get; private set; }

        public Model()
        {
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

        public List<string> GetRoomsOnDate(string date)
        {
            List<string> rooms = new List<string>();

            //TODO: Talk to database and get the rooms using date
            //add the slots to the list
            rooms.Add("room42");
            rooms.Add("room65");
            rooms.Add("room86");

            return rooms;
        }

        public bool CreateSlot(string roomName, string bookingDate, string time, string iD)
        {
            //TODO: talk to database and create a slot if possible
            return true;
        }

        public bool RemoveSlot(string roomName, string bookingDate, string time)
        {
            //TODO: talk to database and remove a slot if possible
            return true;
        }

        public bool MakeBooking(string roomName, string bookingDate, string time, string iD)
        {
            //TODO: talk to database and make a booking if possible
            return true;
        }

        public bool CancelBooking(string roomName, string bookingDate, string time)
        {
            //TODO: talk to database and cancel a booking if possible
            return true;
        }

        public List<StaffAvailability> GetStaffAvailability(string date, string staffId)
        {
            List<StaffAvailability> staffAvailabilities = new List<StaffAvailability>();

            //TODO: talk to database and get staff availabilities using date and staff Id
            //place availabilities in list

            staffAvailabilities.Add(new StaffAvailability("RoomA", "1pm", "2pm"));
            staffAvailabilities.Add(new StaffAvailability("RoomB", "2pm", "3pm"));
            staffAvailabilities.Add(new StaffAvailability("RoomC", "3pm", "5pm"));
            staffAvailabilities.Add(new StaffAvailability("RoomD", "10pm", "12am"));

            return staffAvailabilities;            
        }
    }
}
