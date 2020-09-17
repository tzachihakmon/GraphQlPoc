using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingIntelgence.Data.Entities
{
    public class EngagementReport
    {
        public MeetingData MeetingData { get; set; }

        public ParticpantsData[] ParticpantsData { get; set; }

    }
}
