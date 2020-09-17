using GraphQL.Instrumentation;
using GraphQL.Types;
using MeetingIntelgence.Data.Entities;

namespace MeetingIntelgence.GraphQl.GraphTypes
{
    public class MeetingDataGraphType: ObjectGraphType<MeetingData>
    {
        public MeetingDataGraphType()
        {
            Field(t => t.CallId);
            Field(t => t.OrganizerId);
            Field("StartTimeUTC",t => t.StartTimeUTC.ToLongTimeString());
            Field("EndTimeUTC",t => t.EndTImeUTC.ToLongTimeString());
        }

    }
}