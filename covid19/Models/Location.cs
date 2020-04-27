using System.Collections.Generic;
using System;
namespace covid19.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }

        public ICollection<EventLog> EventLogs { get; set; }
        public Location()
        {
        }
    }
}
