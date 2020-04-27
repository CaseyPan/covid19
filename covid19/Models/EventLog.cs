using System;
namespace covid19.Models
{
    public class EventLog
    {
        public int ID { get; set; }
        public int LocationID { get; set; }
        public int StudentID { get; set; }
        public DateTime TimeStamp { get; set; }

        public Location Location { get; set; }
        public Student Student { get; set; }
        public EventLog()
        {
        }
    }
}
