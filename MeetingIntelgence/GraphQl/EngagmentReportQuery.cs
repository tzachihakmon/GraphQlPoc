using GraphQL.Types;
using MeetingIntelgence.Data;
using MeetingIntelgence.GraphQl.GraphTypes;
using MeetingIntelgence.Managers;
using System.Collections.Generic;

namespace MeetingIntelgence.GraphQl
{
    public class EngagmentReportQuery: ObjectGraphType
    {
        public EngagmentReportQuery(EngagmentReportManager engagmentReportManager)
        {
            Field<ListGraphType<EngagmentReportGraphType>>(
                "engagmentReports",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> {
                    Name = "meetingId"
                }),
                resolve: context =>
                {
                    string id = context.GetArgument<string>("meetingId");
                    return engagmentReportManager.GetReport(id);
                }
            );
        }
    }
}
