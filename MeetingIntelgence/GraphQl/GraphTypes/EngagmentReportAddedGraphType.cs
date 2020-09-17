using GraphQL.Types;
using MeetingIntelgence.GraphQl.Messaging;

namespace MeetingIntelgence.GraphQl.GraphTypes
{
    public class EngagmentReportAddedGraphType: ObjectGraphType<EngagmentReportAdded>
    {
        public EngagmentReportAddedGraphType()
        {
            Field(t => t.MeetingId);
        }

    }
}
