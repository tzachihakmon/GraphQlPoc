using MeetingIntelgence.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingIntelgence.Data
{
    public interface IEngagmentReportDbContext
    {
        HashSet<EngagementReport> GetEngagmentReports();
    }
}
