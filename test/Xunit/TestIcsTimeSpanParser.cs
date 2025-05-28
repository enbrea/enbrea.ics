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
    /// Unit tests for <see cref="TestIcsTimeSpanParser"/>.
    /// </summary>
    public class TestIcsTimeSpanParser
    {
        [Theory]
        [InlineData("P15DT5H0M20S", 15, 5, 0, 20)]
        [InlineData("P15DT5H4M", 15, 5, 4, 0)]
        [InlineData("+P15DT5H", 15, 5, 0, 0)]
        [InlineData("-P15DT5H0M20S", -15, -5, 0, -20)]
        [InlineData("-PT5M", 0, 0, -5, 0)]
        [InlineData("-P7W", -49, 0, 0, 0)]
        [InlineData("P7W", 49, 0, 0, 0)]
        [InlineData("P0D", 0, 0, 0, 0)]
        [InlineData("P0W", 0, 0, 0, 0)]
        public void SupportCommonCases(string input, int expectedDays, int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            var duration = IcsTimeSpanParser.Parse(input);

            Assert.Equal(new TimeSpan(expectedDays, expectedHours, expectedMinutes, expectedSeconds), duration);
        }

        [Theory]
        [InlineData("PT4.5S", 0, 0, 0, 4, 500)]
        [InlineData("+PT4.25S", 0, 0, 0, 4, 250)]
        [InlineData("-PT2.75S", 0, 0, 0, -2, -750)]
        public void SupportFractionalSeconds(string input, int expectedDays, int expectedHours, int expectedMinutes, int expectedSeconds, int expectedMilliseconds)
        {
            var duration = IcsTimeSpanParser.Parse(input);

            Assert.Equal(new TimeSpan(expectedDays, expectedHours, expectedMinutes, expectedSeconds, expectedMilliseconds), duration);
        }
    }
}
