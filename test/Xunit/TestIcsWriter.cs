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
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Enbrea.Ics.Tests
{
    /// <summary>
    /// Unit tests for <see cref="IcsWriter"/>.
    /// </summary>
    public class TestIcsWriter
    {
        [Fact]
        public async Task Support_authenticity_call_event_Example()
        {
            using var strWriter = new StringWriter();
            var icsWriter = new IcsWriter(strWriter);

            Assert.NotNull(icsWriter);

            // A new calendar object
            var icsCalendar = IcsCalendar.CreateWithoutDefaults();

            // Calendar properties
            icsCalendar.Version = new IcsVersion("2.0");
            icsCalendar.Method = new IcsMethod("PUBLISH");
            icsCalendar.ProductId = new IcsProductId("-//Notando//NONSGML DoReserve//EN");
            icsCalendar.Scale = new IcsScale("GREGORIAN");

            // Number of events
            var icsEvent = icsCalendar.AddEvent();

            // Event properties
            icsEvent.Uid = new IcsUid("sc123450@simplybook.me");
            icsEvent.Classification = new IcsClassification(IcsClassificationValue.Public);
            icsEvent.DateTimeStamp = new IcsDateTimeStamp(new DateTime(2018, 5, 20, 2, 40, 36));
            icsEvent.Start = new IcsDateTimeStart(new DateTime(2018, 5, 24, 10, 0, 0));
            icsEvent.End = new IcsDateTimeEnd(new DateTime(2018, 5, 24, 10, 30, 0));
            icsEvent.Summary = new IcsSummary("Authenticity Call");
            icsEvent.Description = new IcsDescription("You were appointed to Authenticity Call event with DigiCert, Inc. provider.");
            icsEvent.Organizer = new IcsOrganizer("MAILTO:xyz@digicert.com");
            icsEvent.Organizer.CommonName = "DigiCert, Inc.: DigiCert, Inc.";

            // Custom property
            icsCalendar.AddCustomProperty("X-MS-OLK-FORCEINSPECTOROPEN", "TRUE");

            // Write calendar object to string
            await icsWriter.WriteAsync(icsCalendar);

            // Convert string to array of strings
            using var strReader = new StringReader(strWriter.ToString());
            var strList = new List<string>();
            
            while (strReader.Peek() != -1)
            {
                strList.Add(await strReader.ReadLineAsync());
            }

            // Check
            Assert.Equal("BEGIN:VCALENDAR", strList[0]);
            Assert.Equal("VERSION:2.0", strList[1]);
            Assert.Equal("PRODID:-//Notando//NONSGML DoReserve//EN", strList[2]);
            Assert.Equal("CALSCALE:GREGORIAN", strList[3]);
            Assert.Equal("METHOD:PUBLISH", strList[4]);
            Assert.Equal("BEGIN:VEVENT", strList[5]);
            Assert.Equal("UID:sc123450@simplybook.me", strList[6]);
            Assert.Equal("DTSTAMP:20180520T024036", strList[7]);
            Assert.Equal("DTSTART;VALUE=DATE-TIME:20180524T100000", strList[8]);
            Assert.Equal("DTEND;VALUE=DATE-TIME:20180524T103000", strList[9]);
            Assert.Equal("SUMMARY:Authenticity Call", strList[10]);
            Assert.Equal("DESCRIPTION:You were appointed to Authenticity Call event with DigiCert\\, I", strList[11]);
            Assert.Equal(" nc. provider.", strList[12]);
            Assert.Equal("ORGANIZER;CN=\"DigiCert\\, Inc.: DigiCert\\, Inc.\":MAILTO:xyz@digicert.com", strList[13]);
            Assert.Equal("CLASS:PUBLIC", strList[14]);
            Assert.Equal("END:VEVENT", strList[15]);
            Assert.Equal("X-MS-OLK-FORCEINSPECTOROPEN:TRUE", strList[16]);
            Assert.Equal("END:VCALENDAR", strList[17]);
        }
    }
}
