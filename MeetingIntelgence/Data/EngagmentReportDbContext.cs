namespace MeetingIntelgence
{
    using Microsoft.EntityFrameworkCore;
    using MeetingIntelgence.Data.Entities;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using MeetingIntelgence.Data;

    public class EngagmentReportDbContext : IEngagmentReportDbContext
    {
        private Random random = new Random();
        private IList<string> RegistertedUsersAad;
        private IList<string> UnregisteredUseresMriIds;
        private int meetingCounter = -1;
        public HashSet<EngagementReport> EngagmentReports;
        private int numOfUsers =100;
        private double chanceToRaiseHands = 0.05;


        public EngagmentReportDbContext()
        {
            RegistertedUsersAad = this.InitUsersIds("Aad");
            UnregisteredUseresMriIds = this.InitUsersIds("Mri");
            EngagmentReports = this.InitMockedEngagmentReportsSet();
        }

        public HashSet<EngagementReport> GetEngagmentReports()
        {
            return EngagmentReports;
        }


        private string[] InitUsersIds(string Idtype)
        {
            IList<string> userIds = new List<string>();
            for (int i = 0; i< numOfUsers; i++)
            {
                userIds.Add(Idtype + i.ToString());
            }
            return userIds.ToArray();
        }

        public EngagementReport AddEngamentReport()
        {
            var meetingData = InitMeetingData();
            var engamentReport = new EngagementReport
            {
                MeetingData = meetingData,
                ParticpantsData = InitParticpantsData(meetingData.StartTimeUTC, meetingData.EndTImeUTC),
            };
            this.EngagmentReports.Add(engamentReport);
            return engamentReport;
        }

        private HashSet<EngagementReport> InitMockedEngagmentReportsSet()
        {
            var meetingData0 = InitMeetingData();
            var meetingData1 = InitMeetingData();
            var meetingData2 = InitMeetingData();

            return new HashSet<EngagementReport>
            {
                new EngagementReport
                {
                    MeetingData = meetingData0,
                    ParticpantsData = InitParticpantsData(meetingData0.StartTimeUTC,meetingData0.EndTImeUTC),
                },
                new EngagementReport
                {
                    MeetingData = meetingData1,
                    ParticpantsData = InitParticpantsData(meetingData1.StartTimeUTC,meetingData1.EndTImeUTC),
                },
                new EngagementReport
                {
                    MeetingData = meetingData2,
                    ParticpantsData = InitParticpantsData(meetingData2.StartTimeUTC,meetingData2.EndTImeUTC),
                }
            };
        }
        
        private ParticpantsData[] InitParticpantsData(DateTime meetingStartTime, DateTime meetingEndTime)
        {
            int numOfRegistered = random.Next(0, numOfUsers);
            int numOfUnregistered = random.Next(0, numOfUsers);
            this.Shuffle(RegistertedUsersAad);
            this.Shuffle(UnregisteredUseresMriIds);

            ParticpantsData[] particpantsData =
                RegistertedUsersAad.
                    Take(numOfRegistered).
                    Select(aadId => new ParticpantsData
                    {
                        ObjectId = aadId,
                    }
                    ).
                Union(UnregisteredUseresMriIds.
                    Take(numOfUnregistered).
                    Select(mriId => new ParticpantsData
                    {
                        Mri = mriId,
                    })
                ).ToArray();

            foreach (ParticpantsData particpant in particpantsData)
            {
                this.FillAttendanceData(particpant, meetingStartTime, meetingEndTime);
                this.FillRaiseHandsData(particpant);
            }

            return particpantsData;
        }

        private void FillRaiseHandsData(ParticpantsData particpant)
        {
            DateTime joinTimeUTC = particpant.AttendanceData.MeetingAttendanceIntervals[0].JoinTimeUTC;
            DateTime leaveTimeUTC = particpant.AttendanceData.MeetingAttendanceIntervals[0].LeaveTimeUTC;
            var prevTime = joinTimeUTC;
            var curTime = prevTime.AddMinutes(5)< leaveTimeUTC ? prevTime.AddMinutes(10) :  leaveTimeUTC;

            var curiousUser = random.NextDouble();
            var extraCuriousity = curiousUser>0.7 ? 0.1 :0;

            List<RaiseHandsInterval> raisedHandsIntervals = new List<RaiseHandsInterval>();
            while (curTime < leaveTimeUTC)
            {
                var rand = random.NextDouble();

                if (rand < chanceToRaiseHands+ extraCuriousity) // 10% prob
                {
                    var raisedHandIntervalStartTime = curTime.AddMinutes((curTime - prevTime).TotalMinutes * random.NextDouble());
                    raisedHandsIntervals.Add(new RaiseHandsInterval
                    {
                        StartTimeUTC = raisedHandIntervalStartTime,
                        EndTimeUTC = raisedHandIntervalStartTime.AddMinutes((curTime - raisedHandIntervalStartTime).TotalMinutes * random.NextDouble())
                    });
                }

                prevTime = curTime;
                curTime=curTime.AddMinutes(5);
            }

            particpant.RaiseHandsData = new RaiseHandsData
            {
                TotalCount = raisedHandsIntervals.Count,
                RaiseHandsIntervals = raisedHandsIntervals.ToArray(),
            };

        }

        private ParticpantsData FillAttendanceData(ParticpantsData particpant, DateTime meetingStartTime, DateTime meetingEndTime)
        {
            double randLateJoin = random.NextDouble();
            double randEarlyLeaving= random.NextDouble();

            DateTime joinTime = randLateJoin < 0.8 ?
                                                meetingStartTime.AddMinutes(random.Next(0, 5) + random.NextDouble()):
                                                meetingStartTime.AddMinutes(random.Next(0, (int)(meetingEndTime - meetingStartTime).TotalMinutes));
            DateTime leftTime = randEarlyLeaving < 0.8 ?
                                                meetingEndTime.AddMinutes(-1 * (random.Next(0, 5)) + random.NextDouble()) :    //sub
                                                meetingEndTime.AddMinutes(-1 * random.Next(0, (int)(meetingEndTime - meetingStartTime).TotalMinutes));

            if (leftTime< joinTime)
            {
                leftTime = joinTime;
            }

            particpant.AttendanceData = new AttendanceData
            {
                MeetingAttendanceIntervals = new MeetingAttendanceInterval[]
                {
                    new MeetingAttendanceInterval
                    {
                        JoinTimeUTC = joinTime,

                        LeaveTimeUTC = leftTime,

                        DurationInSeconds = (leftTime-joinTime).TotalSeconds,
                    }
                },
                TotalMeetingDurationInSeconds = (leftTime - joinTime).TotalSeconds,

            };

            return particpant;
        }

        private ParticpantsData[] GenerateRandomParticpants(DateTime meetingStartTime, DateTime meetingEndTime)
        {
            throw new NotImplementedException();
        }

        private MeetingData InitMeetingData()
        {
            int randomMonth = random.Next(1, 13);
            int randomDay= random.Next(1, 29);
            int randomHour = random.Next(8, 20);
            int randomMinute = random.Next(0, 60);
            int randomSecond = random.Next(0, 60);
            DateTime startTime = new DateTime(2020, randomMonth, randomDay, randomHour, randomMinute, randomSecond);
            meetingCounter += 1;
            return new MeetingData
            {
                CallId = meetingCounter.ToString(),
                OrganizerId = random.Next(0, numOfUsers).ToString(),
                StartTimeUTC = startTime,
                EndTImeUTC = startTime.AddMinutes(random.Next(10, 180)),
            };
        }

        private void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
        
}