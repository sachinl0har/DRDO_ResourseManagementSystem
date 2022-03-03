using System.ComponentModel.DataAnnotations.Schema;

namespace DRDO_ResourseManagementSystem.Models
{
    public class Book
    {
        public int ID { get; set; }
        public int RoomID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public bool IsBook { get; set; } = false;
        public DateTime BookFor { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsFullDay { get; set; } = false;
        public string ColorStatus { get; set; }
        public DateTime BookingDateTime { get; set; } = DateTime.Now;
    }
}
