namespace MeetingIntelgence.Data.Entities
{
    public class ParticpantsData
    {
        public string Mri { get; set; }
        public string ObjectId { get; set; }
        public AttendanceData AttendanceData { get; set; }
        public RaiseHandsData RaiseHandsData { get; set; }

        /*
        public string RegistrationId { get; set; }
        public string TenantId { get; set; }
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string ParticipantType { get; set; }
        public string MeetingRole { get; set; }
        public string ParticipantId { get; set; }
        public string EndpointType { get; set; }
        */

        /*
        public ChatData ChatData { get; set; }
        public PollData PollData { get; set; }
        */
    }
}