namespace MeetingIntelgence.GraphQl.GraphTypes
{
    using GraphQL.Types;
    using MeetingIntelgence.Data.Entities;
    using System.Linq;

    public class AttendanceDataGraphType: ObjectGraphType<AttendanceData>
    {
        public AttendanceDataGraphType()
        {
            Field<ListGraphType<MeetingAttendanceIntervalGraphType>>(
                "meetingAttendanceIntervals",
                resolve: attendanceDataContext => attendanceDataContext.Source.MeetingAttendanceIntervals.ToList());

            Field(attendanceData => attendanceData.TotalMeetingDurationInSeconds);
        }

    }
}
