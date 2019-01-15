﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace WDT_Assignment1
{
    class Result
    {
        public bool Success { get; set; }
        public string ErrorMsg { get; set; }
    }

    class Model
    {
        public List<string> Rooms { get; private set; }
        public List<Person> Users { get; private set; }
        public List<Slot> Slots { get; private set; }
        
        public static string ConnString = "server=wdt2019.australiasoutheast.cloudapp.azure.com;UID=s3542686;PWD=abc123";
        public static string SQLDateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        private static Model instance;

        private Model() { }

        public static Model Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Model();
                }
                return instance;
            }
        }

        // Used singleton structure from https://codeburst.io/singleton-design-pattern-implementation-in-c-62a8daf3d115

        public bool LoadDataFromDB()
        {
            try
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
                        Slots.Add(new Slot
                        {
                            RoomName = item["RoomID"].ToString(),
                            StartTime = DateTime.Parse(item["StartTime"].ToString()),
                            StaffId = item["StaffID"].ToString(),
                            StudentId = item["BookedInStudentID"].ToString()
                        });
                    }
                }
            }
            catch
            {
                // If an error occurs return false
                return false;
            }
            return true;
        }

        private bool ExecuteSql(string str)
        {
            var rowsAffect = 0;
            try
            {
                using (var conn = new SqlConnection(Model.ConnString))
                {
                    conn.Open();
                    
                    var cmd = new SqlCommand(str, conn);

                    rowsAffect = cmd.ExecuteNonQuery();
                }

                // Check that the query actually did anything.
                if (rowsAffect != 0)
                {
                    return true;
                }
            }
            catch
            {
                // Catches any exceptions and continues, function then returns false.
            }

            return false;
        }
        

        /// <summary>
        /// Find the first slot that matches the given roomname and bookingdate
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="bookingDate"></param>
        /// <returns>The found Slot, Null if not found</returns>
        public Slot FindSlot(string roomName, DateTime bookingDate)
        {
            return Slots.FirstOrDefault(x => x.StartTime == bookingDate && x.RoomName == roomName);
        }

        public Person FindPerson(string id)
        {
            return Users.FirstOrDefault(x => x.Id == id);
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

        public List<Slot> GetBookedSlots(string id)
        {
            return Slots.Where(x => x.StaffId == id && !String.IsNullOrEmpty(x.StudentId)).ToList();
        }

        public List<Slot> GetStaffAvailabilty(DateTime date, string id)
        {
            return Slots.Where(x => x.StartTime.Date == date.Date && x.StaffId == id && String.IsNullOrEmpty(x.StudentId)).ToList();
        }

        public Result CreateSlot(string roomName, DateTime bookingDate, string iD)
        {
            // Check room is exists.
            if (!Rooms.Contains(roomName))
            {
                return new Result { Success = false, ErrorMsg = "Room does not exist" };
            }

            if (Slots.Where(x => x.StartTime.Date == bookingDate.Date && x.RoomName == roomName).ToList().Count >= 2)
            {
                return new Result { Success = false, ErrorMsg = "A room can be booked for a maximum of 2 slots per day" };
            }

            // Check slot does not already exist
            if (FindSlot(roomName, bookingDate) != null)
            {
                return new Result { Success = false, ErrorMsg = "Slot already exists" };
            }
            
            // Check id exists
            if (!Users.Any(x => x.Id == iD))
            {
                return new Result { Success = false, ErrorMsg = "Staff member does not exist" };
            }

            if (Slots.Where(x => x.StartTime.Date == bookingDate.Date && x.StaffId == iD).ToList().Count >= 4)
            {
                return new Result { Success = false, ErrorMsg = "Staff can be available for a maximum of 4 slots per day" };
            }

            // Create a slot
            var newSlot = new Slot { RoomName = roomName, StartTime = bookingDate, StaffId = iD };

            // SQL to insert the new slot into the DB.
            bool res = ExecuteSql("INSERT INTO [dbo].[Slot] ([RoomID], [StartTime], [StaffID])" +
                    "VALUES(" +
                    $"(SELECT RoomID from [Room] where RoomID = '{newSlot.RoomName}')," +
                    $"'{newSlot.StartTime.ToString(Model.SQLDateTimeFormat)}'," +
                    $"(SELECT UserID from [User] where UserID = '{newSlot.StaffId}'))");

            if(res)
            {
                Slots.Add(newSlot);
                return new Result { Success = true };
            }
            return new Result { Success = false, ErrorMsg = "Unable to execute database request" };
        }

        public Result RemoveSlot(string roomName, DateTime bookingDate)
        {
            // Check that the room exists
            if(!Rooms.Contains(roomName))
            {
                return new Result { Success = false, ErrorMsg = "Room does not exist" };
            }

            // Check if the slot exists
            var slot = FindSlot(roomName, bookingDate);

            // If the slot does not exist we cannot remove it
            if(slot == null)
            {
                return new Result { Success = false, ErrorMsg = "The given slot does not exist" };
            }

            if(!String.IsNullOrEmpty(slot.StudentId))
            {
                return new Result { Success = false, ErrorMsg = "Cannot remove a slot that a student has booked" };
            }

            var res = ExecuteSql("DELETE FROM [dbo].[Slot] WHERE " +
                $"[RoomID] = '{roomName}' AND " +
                $"[StartTime] = '{bookingDate.ToString(Model.SQLDateTimeFormat)}'");

            // If the SQL execs then remove the slot locally
            if(res)
            {
                Slots.Remove(slot);
                return new Result { Success = true };
            }

            return new Result { Success = false, ErrorMsg = "Unable to execute database request" };
        }

        public Result MakeBooking(string roomName, DateTime bookingDate, string iD)
        {
            // Check that the room exists
            if(!Rooms.Contains(roomName))
            {
                return new Result { Success = false, ErrorMsg = "Room does not exist" };
            }

            // Check that the id exists
            if(!Users.Any(x => x.Id == iD))
            {
                return new Result { Success = false, ErrorMsg = "Student does not exist" };
            }

            //check if a the student has already made a booking on this day
            if(Slots.Where(x => x.StartTime.Date == bookingDate.Date && x.StudentId == iD).Any())
            {
                return new Result { Success = false, ErrorMsg = "Student has already made a booking on this day" };
            }

            var slot = FindSlot(roomName, bookingDate);
            // Check the slot exists
            if (slot == null)
            {
                return new Result { Success = false, ErrorMsg = "The given details do not match a slot" };
            }

            // Check the slot is not already booked
            if(!string.IsNullOrEmpty(slot.StudentId))
            {
                return new Result { Success = false, ErrorMsg = "This slot is already booked" };
            }
                        
            var res = ExecuteSql("UPDATE [dbo].[Slot] SET " +
                $"[BookedInStudentID] = (SELECT [User].[UserID] FROM [User] WHERE UserID = '{iD}') " +
                $"WHERE [RoomID] = '{roomName}' AND " +
                $"[StartTime] = '{bookingDate.ToString(Model.SQLDateTimeFormat)}'");

            // If the sql executes, update the local
            if(res)
            {
                slot.StudentId = iD;
                return new Result { Success = true };
            }

            return new Result { Success = false, ErrorMsg = "Unable to execute database request" };
        }

        public Result CancelBooking(string roomName, DateTime bookingDate)
        {
            if(!Rooms.Contains(roomName))
            {
                return new Result { Success = false, ErrorMsg = "Room does not exist" };
            }

            var slot = FindSlot(roomName, bookingDate);

            // Check the slot exists before canceling the student booking
            if(slot == null)
            {
                return new Result { Success = false, ErrorMsg = "Slot does not exist" };
            }

            var res = ExecuteSql("UPDATE [dbo].[Slot] SET" +
                "[BookedInStudentID] = null " +
                $"WHERE [RoomID] = '{roomName}' AND " +
                $"[StartTime] = '{bookingDate.ToString(Model.SQLDateTimeFormat)}'");

            if(res)
            {
                slot.StudentId = null;
                return new Result { Success = true };
            }

            return new Result { Success = false, ErrorMsg = "Unable to execute database request" };
        }
    }
}
