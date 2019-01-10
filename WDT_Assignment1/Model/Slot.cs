namespace WDT_Assignment1
{
    public class Slot
    {
        public string RoomName { get; private set; }
        public string StartTime { get; private set; }
        public string EndTime { get; private set; }
        public string StaffId { get; private set; }
        public string Bookings { get; private set; }

        public Slot(string roomName, string startTime, string endTime, string staffId, string bookings)
        {
            RoomName = roomName;
            StartTime = startTime;
            EndTime = endTime;
            StaffId = staffId;
            Bookings = bookings;
        }
    }
}
