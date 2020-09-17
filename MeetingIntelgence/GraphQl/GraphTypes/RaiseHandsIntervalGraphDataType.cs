
namespace MeetingIntelgence.GraphQl.GraphTypes
{
    using GraphQL.Types;
    using MeetingIntelgence.Data.Entities;
    public class RaiseHandsIntervalGraphDataType: ObjectGraphType<RaiseHandsInterval>
    {
        public RaiseHandsIntervalGraphDataType()
        {
            Field(raiseHandsInterval => raiseHandsInterval.StartTimeUTC);
            Field(raiseHandsInterval => raiseHandsInterval.EndTimeUTC);
        }
    }
}
