using MeetingIntelgence.GraphQl.GraphTypes;
using MeetingIntelgence.Managers;
using GraphQL.Types;
using MeetingIntelgence.GraphQl.Messaging;

namespace MeetingIntelgence.GraphQl
{
    public class EngagmentReportMutation:ObjectGraphType
    {
        public EngagmentReportMutation(EngagmentReportManager engagmentReportManager, EngagmentReportService messageService)
        {
            Field<EngagmentReportGraphType>(
                "createEngagmentReport",

                resolve:  context =>
                {
                    var engagmentReport = engagmentReportManager.AddReport();
                    var meetingId = engagmentReport.MeetingData.CallId;
                    messageService.AddReportAddedMessage(meetingId);
                    return engagmentReportManager.AddReport();
                });
        }
    }
}

