namespace DRDO_ResourseManagementSystem.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public string RoomImg { get; set; }
        public int Roomcapacity { get; set; }
        public DateTime RoomCreateTime { get; set; } = DateTime.Now;
    }
}
