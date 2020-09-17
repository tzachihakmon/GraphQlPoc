using MeetingIntelgence.GraphQl.GraphTypes;
using MeetingIntelgence.Managers;
using GraphQL.Types;
using MeetingIntelgence.GraphQl.Messaging;
using GraphQL.Resolvers;

namespace MeetingIntelgence.GraphQl
{

    public class EngagmentReportSubscription : ObjectGraphType
    {
        public EngagmentReportSubscription(EngagmentReportService messageService)
        {
            Name = "ReportsSubscription";
            AddField(new EventStreamFieldType
            {
                Name = "reportAdded",
                Type = typeof(EngagmentReportAddedGraphType),
                Resolver = new FuncFieldResolver<EngagmentReportAdded>(c => c.Source as EngagmentReportAdded),
                Subscriber = new EventStreamResolver<EngagmentReportAdded>(c => messageService.GetMessages())
            });
        }
    }
}