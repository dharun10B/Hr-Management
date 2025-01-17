using System;

namespace Hr_Management.Models
{
    public class AttendanceModule
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan InTime { get; set; }
        public TimeSpan OutTime { get; set; }
        public TimeSpan? ShortFall { get; set; }

        public void CalculateShortFall()
        {
            // Define standard working hours (9 hours)
            TimeSpan standardWorkingHours = new TimeSpan(9, 0, 0); // 9 hours

            // Calculate the actual worked hours
            TimeSpan actualWorkedHours = OutTime - InTime;

            // Calculate the shortfall
            ShortFall = actualWorkedHours - standardWorkingHours;
        }
        
    }
}