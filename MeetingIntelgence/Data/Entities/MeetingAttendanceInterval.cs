using System;

namespace MeetingIntelgence.Data.Entities
{
    public class MeetingAttendanceInterval 
    {
        public DateTime JoinTimeUTC { get; set; }
        public DateTime LeaveTimeUTC { get; set; }
        public double DurationInSeconds { get; set; }

    }
}