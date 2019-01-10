using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WDT_Assignment1
{
    class Database : Model
    {
        private SqlConnection conn;
        private SqlDataAdapter adapRoom;
        private SqlDataAdapter adapSlot;
        private SqlDataAdapter adapUser;

        private DataSet roomData = new DataSet();
        private DataSet slotData = new DataSet();
        private DataSet userData = new DataSet();

        public Database()
        {
            conn = new SqlConnection("server=wdt2019.australiasoutheast.cloudapp.azure.com;UID=s3542686;PWD=abc123");
            adapRoom = new SqlDataAdapter("SELECT * FROM dbo.Room", conn);
            adapSlot = new SqlDataAdapter("SELECT * FROM dbo.Slot", conn);
            adapUser = new SqlDataAdapter("SELECT * FROM dbo.[User]", conn);

            roomData = new DataSet();
            slotData = new DataSet();
            userData = new DataSet();

            adapRoom.Fill(roomData, "Rooms");
            adapSlot.Fill(slotData, "Slots");
            adapUser.Fill(userData, "Users");

        }

        public override List<string> GetRooms()
        {
            var rooms = new List<string>();
            foreach (DataRow item in roomData.Tables["Rooms"].Rows)
            {
                rooms.Add(item["RoomID"].ToString());
            }
            return rooms;
        }
    }
}
