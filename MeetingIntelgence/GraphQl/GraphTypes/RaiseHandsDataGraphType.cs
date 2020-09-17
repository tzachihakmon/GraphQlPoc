

namespace MeetingIntelgence.GraphQl.GraphTypes
{
    using GraphQL.Types;
    using MeetingIntelgence.Data.Entities;
    using System.Linq;

    public class RaiseHandsDataGraphType:ObjectGraphType<RaiseHandsData>
    {
        public RaiseHandsDataGraphType()
        {
            Field<ListGraphType<RaiseHandsIntervalGraphDataType>>(
                "raiseHandsIntervals",
                resolve: raiseHandsData => raiseHandsData.Source.RaiseHandsIntervals.ToList());

            Field(raiseHandsData => raiseHandsData.TotalCount);
        }
    }
}
