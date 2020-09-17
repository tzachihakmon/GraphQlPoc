using MeetingIntelgence.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingIntelgence.Managers
{
    public class EngagmentReportManager
    {
        private EngagmentReportDbContext engagmentReportDbContext;

        public EngagmentReportManager(EngagmentReportDbContext dbContext)
        {
            engagmentReportDbContext = dbContext;
        }

        public List<EngagementReport> GetReport(string meetingId = null)
        {
            return engagmentReportDbContext.EngagmentReports.
                Where(report => meetingId == null ? true : meetingId.Equals(report.MeetingData.CallId,StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public EngagementReport AddReport()
        {
            return engagmentReportDbContext.AddEngamentReport();
        }
    }
}
