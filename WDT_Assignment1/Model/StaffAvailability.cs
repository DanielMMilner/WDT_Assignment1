using System;
using System.Collections.Generic;
using System.Text;

namespace WDT_Assignment1
{
    public class StaffAvailability
    {
        public string RoomName { get; private set; }
        public string StartTime { get; private set; }
        public string EndTime { get; private set; }

        public StaffAvailability(string roomName, string startTime, string endTime)
        {
            RoomName = roomName;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
