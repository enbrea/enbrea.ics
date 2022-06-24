#region ENBREA.ICS - Copyright (C) 2022 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA.ICS 
 *    
 *    Copyright (C) 2022 STÜBER SYSTEMS GmbH
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
    /// Unit tests for <see cref="TestIcsTimeSpanParser"/>.
    /// </summary>
    public class TestIcsTimeSpanParser
    {
        [Fact]
        public void SupportDateAndTime_1()
        {
            var textLine = "P15DT5H0M20S";

            var ts = IcsTimeSpanParser.Parse(textLine);

            Assert.Equal(new TimeSpan(15, 5, 0, 20), ts);
        }

        [Fact]
        public void SupportDateAndTime_2()
        {
            var textLine = "P15DT5H4M";

            var ts = IcsTimeSpanParser.Parse(textLine);

            Assert.Equal(new TimeSpan(15, 5, 4, 0), ts);
        }

        [Fact]
        public void SupportDateAndTime_3()
        {
            var textLine = "+P15DT5H";

            var ts = IcsTimeSpanParser.Parse(textLine);

            Assert.Equal(new TimeSpan(15, 5, 0, 0), ts);
        }

        [Fact]
        public void SupportNegatedDateAndTime()
        {
            var textLine = "-P15DT5H0M20S";

            var ts = IcsTimeSpanParser.Parse(textLine);

            Assert.Equal(new TimeSpan(-15, -5, 0, -20), ts);
        }

        [Fact]
        public void SupportNegatedHours()
        {
            var textLine = "-PT5M";

            var ts = IcsTimeSpanParser.Parse(textLine);

            Assert.Equal(new TimeSpan(0, -5, 0), ts);
        }

        [Fact]
        public void SupportNegatedWeek()
        {
            var textLine = "-P7W";

            var ts = IcsTimeSpanParser.Parse(textLine);

            Assert.Equal(new TimeSpan(-49, 0, 0, 0), ts);
        }

        [Fact]
        public void SupportWeek()
        {
            var textLine = "P7W";

            var ts = IcsTimeSpanParser.Parse(textLine);

            Assert.Equal(new TimeSpan(49, 0, 0, 0), ts);
        }

        [Fact]
        public void SupportZero_1()
        {
            var textLine = "P0D";

            var ts = IcsTimeSpanParser.Parse(textLine);

            Assert.Equal(new TimeSpan(0), ts);
        }

        [Fact]
        public void SupportZero_2()
        {
            var textLine = "P0W";

            var ts = IcsTimeSpanParser.Parse(textLine);

            Assert.Equal(new TimeSpan(0), ts);
        }
    }
}
