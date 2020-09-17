using GraphQL.Types;
using GraphQL;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingIntelgence.GraphQl
{
    public class EngagmentReportSchema:Schema
    {
        /*
        public EngagmentReportSchema(IServiceProvider provider): base(provider)
        {
            Query = provider.GetRequiredService<EngagmentReportQuery>();
        }
        */


        public EngagmentReportSchema(IDependencyResolver resolver) : base(resolver)
        {

            Query = resolver.Resolve<EngagmentReportQuery>();
            Mutation = resolver.Resolve<EngagmentReportMutation>();
            Subscription = resolver.Resolve<EngagmentReportSubscription>();
        }
    }
}
