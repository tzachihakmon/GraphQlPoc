namespace MeetingIntelgence.Data.Entities
{
    public class AttendanceData
    {
        public MeetingAttendanceInterval[] MeetingAttendanceIntervals { get; set; }

        public double TotalMeetingDurationInSeconds;

    }
}