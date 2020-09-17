using GraphQL.Types;
using MeetingIntelgence.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingIntelgence.GraphQl.GraphTypes
{
    public class ParticpantDataType: ObjectGraphType<ParticpantsData>
    {
        public ParticpantDataType()
        {
            Field(particpantsData => particpantsData.Mri).Description("Id of unregeistered user.");
            Field(particpantsData => particpantsData.ObjectId).Description("Id of regeistered user");
            Field<AttendanceDataGraphType>(
                "attendanceData",
                resolve: particpantData => particpantData.Source.AttendanceData);
            Field<RaiseHandsDataGraphType>(
                "raiseHandsData",
                resolve: particpantData => particpantData.Source.RaiseHandsData);

        }
    }
}
