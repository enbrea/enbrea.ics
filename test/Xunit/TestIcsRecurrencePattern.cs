#region ENBREA.ICS - Copyright (C) STÜBER SYSTEMS GmbH
/*    
 *    ENBREA.ICS
 *    
 *    Copyright (C) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using System;
using Xunit;

namespace Enbrea.Ics.Tests
{
    /// <summary>
    /// Unit tests for <see cref="IcsRecurrencePattern"/>.
    /// </summary>
    public class TestIcsRecurrencePattern
    {
        [Fact]
        public void SupportDaily_1()
        {
            var textLine = "FREQ=DAILY;COUNT=10";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Daily, rule.Frequency);
            Assert.Equal(10, rule.Count);
            Assert.Equal(textLine, rule.ToString());
        }

        [Fact]
        public void SupportDaily_2()
        {
            var textLine = "FREQ=DAILY;UNTIL=19971224T000000Z";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Daily, rule.Frequency);
            Assert.Equal(new DateTime(1997, 12, 24, 0, 0, 0), rule.UntilAsDateTime);
            Assert.Equal(DateTimeKind.Utc, rule.UntilAsDateTime?.Kind);
            Assert.True(rule.IsDateTime());
            Assert.False(rule.IsDate());
            Assert.Equal(textLine, rule.ToString());
        }

        [Fact]
        public void SupportDaily_3()
        {
            var textLine = "FREQ=DAILY;INTERVAL=2";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Daily, rule.Frequency);
            Assert.Equal(2, rule.Interval);
            Assert.Equal(textLine, rule.ToString());
        }

        [Fact]
        public void SupportDaily_4()
        {
            var textLine = "FREQ=DAILY;INTERVAL=10;COUNT=5";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Daily, rule.Frequency);
            Assert.Equal(10, rule.Interval);
            Assert.Equal(5, rule.Count);
            Assert.Equal(textLine, rule.ToString());
        }

        [Fact]
        public void SupportHourly_1()
        {
            var textLine = "FREQ=HOURLY;INTERVAL=3;UNTIL=19970902T170000Z";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Hourly, rule.Frequency);
            Assert.Equal(3, rule.Interval);
            Assert.Equal(new DateTime(1997, 09, 02, 17, 0, 0), rule.UntilAsDateTime);
            Assert.Equal(DateTimeKind.Utc, rule.UntilAsDateTime?.Kind);
            Assert.True(rule.IsDateTime());
            Assert.False(rule.IsDate());
            Assert.Equal(textLine, rule.ToString());
        }

        [Fact]
        public void SupportMinutely_1()
        {
            var textLine = "FREQ=MINUTELY;INTERVAL=90;COUNT=4";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Minutely, rule.Frequency);
            Assert.Equal(90, rule.Interval);
            Assert.Equal(4, rule.Count);
            Assert.Equal(textLine, rule.ToString());
        }

        [Fact]
        public void SupportMinutely_2()
        {
            var textLine = "FREQ=MINUTELY;INTERVAL=90;UNTIL=19970902";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Minutely, rule.Frequency);
            Assert.Equal(90, rule.Interval);
            Assert.Equal(new DateOnly(1997, 09, 02), rule.UntilAsDate);
            Assert.False(rule.IsDateTime());
            Assert.True(rule.IsDate());
            Assert.Equal(textLine, rule.ToString());
        }

        [Fact]
        public void SupportMonthly_1()
        {
            var textLine = "FREQ=MONTHLY;UNTIL=19971224T000000Z;BYDAY=1FR";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Monthly, rule.Frequency);
            Assert.Equal(new DateTime(1997, 12, 24, 0, 0, 0), rule.UntilAsDateTime);
            Assert.Equal(DateTimeKind.Utc, rule.UntilAsDateTime?.Kind);
            Assert.True(rule.IsDateTime());
            Assert.False(rule.IsDate());
            Assert.Equal(DayOfWeek.Friday, rule.ByDay[0].DayOfWeek);
            Assert.Equal((sbyte)1, rule.ByDay[0].Occurrence);
            Assert.Equal(textLine, rule.ToString());
        }

        [Fact]
        public void SupportMonthly_2()
        {
            var textLine = "FREQ=MONTHLY;INTERVAL=2;COUNT=10;BYDAY=1SU,-1SU";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Monthly, rule.Frequency);
            Assert.Equal(2, rule.Interval);
            Assert.Equal(10, rule.Count);
            Assert.Equal(DayOfWeek.Sunday, rule.ByDay[0].DayOfWeek);
            Assert.Equal((sbyte)+1, rule.ByDay[0].Occurrence);
            Assert.Equal(DayOfWeek.Sunday, rule.ByDay[1].DayOfWeek);
            Assert.Equal((sbyte)-1, rule.ByDay[1].Occurrence);
            Assert.Equal(textLine, rule.ToString());
        }

        [Fact]
        public void SupportMonthly_3()
        {
            var textLine = "FREQ=MONTHLY;COUNT=10;BYMONTHDAY=1,-1";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Monthly, rule.Frequency);
            Assert.Equal(10, rule.Count);
            Assert.Equal(+1, rule.ByMonthDay[0]);
            Assert.Equal(-1, rule.ByMonthDay[1]);
            Assert.Equal(textLine, rule.ToString());
        }

        [Fact]
        public void SupportMonthly_4()
        {
            var textLine = "FREQ=MONTHLY;INTERVAL=18;COUNT=10;BYMONTHDAY=10,11,12,13,14,15";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Monthly, rule.Frequency);
            Assert.Equal(18, rule.Interval);
            Assert.Equal(10, rule.Count);
            Assert.Equal(10, rule.ByMonthDay[0]);
            Assert.Equal(11, rule.ByMonthDay[1]);
            Assert.Equal(12, rule.ByMonthDay[2]);
            Assert.Equal(13, rule.ByMonthDay[3]);
            Assert.Equal(14, rule.ByMonthDay[4]);
            Assert.Equal(15, rule.ByMonthDay[5]);
            Assert.Equal(textLine, rule.ToString());
        }

        [Fact]
        public void SupportWeekly_1()
        {
            var textLine = "FREQ=WEEKLY;COUNT=10";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Weekly, rule.Frequency);
            Assert.Equal(10, rule.Count);
            Assert.Equal(textLine, rule.ToString());
        }

        [Fact]
        public void SupportWeekly_2()
        {
            var textLine = "FREQ=WEEKLY;INTERVAL=2;WKST=SU";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Weekly, rule.Frequency);
            Assert.Equal(2, rule.Interval);
            Assert.Equal(DayOfWeek.Sunday, rule.WeekStart);
            Assert.Equal(textLine, rule.ToString());
        }

        [Fact]
        public void SupportWeekly_3()
        {
            var textLine = "FREQ=WEEKLY;UNTIL=19971007T000000Z;WKST=SU;BYDAY=TU,TH";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Weekly, rule.Frequency);
            Assert.Equal(new DateTime(1997, 10, 07, 0, 0, 0), rule.UntilAsDateTime);
            Assert.Equal(DateTimeKind.Utc, rule.UntilAsDateTime?.Kind);
            Assert.True(rule.IsDateTime());
            Assert.False(rule.IsDate());
            Assert.Equal(DayOfWeek.Sunday, rule.WeekStart);
            Assert.Equal(DayOfWeek.Tuesday, rule.ByDay[0].DayOfWeek);
            Assert.Equal(DayOfWeek.Thursday, rule.ByDay[1].DayOfWeek);
            Assert.Equal(textLine, rule.ToString());
        }

        [Fact]
        public void SupportYearly_1()
        {
            var textLine = "FREQ=YEARLY;UNTIL=20000131T140000Z;BYMONTH=1;BYDAY=SU,MO,TU,WE,TH,FR,SA";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Yearly, rule.Frequency);
            Assert.Equal(new DateTime(2000, 01, 31, 14, 0, 0), rule.UntilAsDateTime);
            Assert.Equal(DateTimeKind.Utc, rule.UntilAsDateTime?.Kind);
            Assert.True(rule.IsDateTime());
            Assert.False(rule.IsDate());
            Assert.Equal(1, rule.ByMonth[0]);
            Assert.Equal(DayOfWeek.Sunday, rule.ByDay[0].DayOfWeek);
            Assert.Equal(DayOfWeek.Monday, rule.ByDay[1].DayOfWeek);
            Assert.Equal(DayOfWeek.Tuesday, rule.ByDay[2].DayOfWeek);
            Assert.Equal(DayOfWeek.Wednesday, rule.ByDay[3].DayOfWeek);
            Assert.Equal(DayOfWeek.Thursday, rule.ByDay[4].DayOfWeek);
            Assert.Equal(DayOfWeek.Friday, rule.ByDay[5].DayOfWeek);
            Assert.Equal(DayOfWeek.Saturday, rule.ByDay[6].DayOfWeek);
            Assert.Equal(textLine, rule.ToString());
        }

        [Fact]
        public void SupportYearly_2()
        {
            var textLine = "FREQ=YEARLY;INTERVAL=2;COUNT=10;BYMONTH=1,2,3";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Yearly, rule.Frequency);
            Assert.Equal(2, rule.Interval);
            Assert.Equal(10, rule.Count);
            Assert.Equal(1, rule.ByMonth[0]);
            Assert.Equal(2, rule.ByMonth[1]);
            Assert.Equal(3, rule.ByMonth[2]);
            Assert.Equal(textLine, rule.ToString());
        }

        [Fact]
        public void SupportYearly_3()
        {
            var textLine = "FREQ=YEARLY;INTERVAL=3;COUNT=10;BYYEARDAY=1,100,200";

            var rule = IcsRecurrencePattern.Parse(textLine);

            Assert.Equal(IcsRecurrenceFrequency.Yearly, rule.Frequency);
            Assert.Equal(3, rule.Interval);
            Assert.Equal(10, rule.Count);
            Assert.Equal(1, rule.ByYearDay[0]);
            Assert.Equal(100, rule.ByYearDay[1]);
            Assert.Equal(200, rule.ByYearDay[2]);
            Assert.Equal(textLine, rule.ToString());
        }
    }
}
