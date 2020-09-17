
namespace MeetingIntelgence.GraphQl.GraphTypes
{
    using GraphQL.Types;
    using MeetingIntelgence.Data.Entities;
    using System.Linq;
    public class EngagmentReportGraphType: ObjectGraphType<EngagementReport>
    {
        public EngagmentReportGraphType()
        {
            Name = "Engagment Report";

            Field(engagementReport => engagementReport.MeetingData.CallId).Name("idd").Description("the Id of ...)");

            Field<MeetingDataGraphType>(
                "meetingData",
                resolve: engagementReport => engagementReport.Source.MeetingData);
            
            //Field(engagementReport => engagementReport.MeetingData).Description("meta data on the meeting").Name("meetingData");

            Field<ListGraphType<ParticpantDataType>>(
                "particpantsData",
                resolve: engagementReportType => engagementReportType.Source.ParticpantsData.ToList());
        }

        /*            Field<ListGraphType<ParticpantDataType>>(
                "particpantsData",
                arguments:new QueryArguments(
                    new QueryArgument<IGraphType>
                    {
                        Name = "topRaisedHands"
                    }
                ),
                resolve: engagementReportType =>
                {
                    int topK = engagementReportType.GetArgument<int>(topRaisedHands)
                    engagementReportType.Source.ParticpantsData.ToList());
                }
        */
    }
}
