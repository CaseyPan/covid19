using System.Collections.Generic;
using System;
namespace covid19.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string StudentIdNumber { get; set; }
        public string Name { get; set; }
        // public (DateTime Timelog, (double Lon, double Lat) LocationLog)[] Log { get; set; }
        public bool IsConfirmedInfected { get; set; }
        public bool IsSuspectedInfected { get; set; }

        public ICollection<EventLog> EventLogs { get; set; }
        public Student()
        {
        }
    }
}
