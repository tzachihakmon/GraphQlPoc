using System;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MeetingIntelgence.GraphQl.Messaging
{
    public class EngagmentReportService
    {
        private readonly ISubject<EngagmentReportAdded> _messageStream = new ReplaySubject<EngagmentReportAdded>(1);

        public EngagmentReportAdded AddReportAddedMessage(string meetingId)
        {
            var message = new EngagmentReportAdded
            {
                MeetingId = meetingId
            };
            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<EngagmentReportAdded> GetMessages()
        {
            return _messageStream.AsObservable();
        }
    }
}


