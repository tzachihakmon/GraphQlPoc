using System;

namespace MeetingIntelgence.Data.Entities
{
    public class MeetingData
    {
        public string CallId { get; set; }
        public string OrganizerId { get; set; }
        public DateTime StartTimeUTC { get; set; }
        public DateTime EndTImeUTC { get; set; }
        // Possible values: Adhoc/Scheduled/Recurring/Broadcast/MeetNow
        // public string MeetingType { get; set; }

    }
}