namespace MeetingIntelgence.GraphQl.GraphTypes
{
    using GraphQL.Types;
    using MeetingIntelgence.Data.Entities;
    public class MeetingAttendanceIntervalGraphType: ObjectGraphType<MeetingAttendanceInterval>
    {
        /*
 * 
 *      Field("StartTimeUTC",t => t.StartTimeUTC.ToLongTimeString());
        Field("EndTimeUTC",t => t.EndTImeUTC.ToLongTimeString());
*/
        public MeetingAttendanceIntervalGraphType()
        {
            Field("joinTimeUTC", meetingAttendanceInterval => meetingAttendanceInterval.JoinTimeUTC.ToLongTimeString()); 
            Field("leaveTimeUTC", meetingAttendanceInterval => meetingAttendanceInterval.LeaveTimeUTC.ToLongTimeString());
            Field(meetingAttendanceInterval => meetingAttendanceInterval.DurationInSeconds);
        }
    }
}
