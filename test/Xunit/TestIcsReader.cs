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
using System.Threading.Tasks;
using Xunit;

namespace Enbrea.Ics.Tests
{
    /// <summary>
    /// Unit tests for <see cref="IcsReader"/>.
    /// </summary>
    /// <remarks>
    /// Some iCal test files are taken from https://github.com/jens-maus/node-ical
    /// </remarks>
    public class TestIcsReader
    {
        [Fact]
        public async Task Support_meetup_Example()
        {
            using var strReader = File.OpenText(Path.Combine(GetOutputFolder(), "Assets", "meetup.ics"));
            var icsReader = new IcsReader(strReader);

            Assert.NotNull(icsReader);

            IAsyncEnumerator<IcsCalendar> enumerator = icsReader.ReadAsync().GetAsyncEnumerator();

            // Get calendar object
            Assert.True(await enumerator.MoveNextAsync());

            // Calendar properties
            Assert.Equal("2.0", enumerator.Current.Version.Value);
            Assert.Equal("PUBLISH", enumerator.Current.Method.Value);
            Assert.Equal("GREGORIAN", enumerator.Current.Scale.Value);
            Assert.Equal("-//Meetup//RemoteApi//EN", enumerator.Current.ProductId.Value);
            Assert.Equal("X-ORIGINAL-URL", enumerator.Current.CustomProperties[0].Name);
            Assert.Equal("http://www.meetup.com/events/ical/8333638/dfdba2e4692160753404f737feace78d526ff0ce/going", enumerator.Current.CustomProperties[0].Value);

            // Number of events
            Assert.Single(enumerator.Current.EventList);

            // Event properties
            Assert.NotNull(enumerator.Current.EventList[0].Uid);
            Assert.Equal("event_nsmxnyppbfc@meetup.com", enumerator.Current.EventList[0].Uid.Value);
            Assert.Equal(new IcsGeoPosition(33.56, -111.90), enumerator.Current.EventList[0].Geo.Value);
            Assert.Equal("Open Source Project Tempe (1415 E University Dr. #103A, Tempe, AZ 85281)", enumerator.Current.EventList[0].Location.Value);
            Assert.Equal(new Uri("http://www.meetup.com/Phoenix-Drupal-User-Group/events/33627272/"), enumerator.Current.EventList[0].Url.Value);
            Assert.Equal(
                "Phoenix Drupal User Group" + Environment.NewLine +
                "Wednesday, November 9 at 7:00 PM" + Environment.NewLine + Environment.NewLine +
                "Customizing node display with template pages in Drupal 6" + Environment.NewLine + Environment.NewLine +
                " Jon Sheehan and Matthew Berry of the Office of Knowledge Enterprise Development (OKED) Knowledge..." + Environment.NewLine + Environment.NewLine + 
                "Details: http://www.meetup.com/Phoenix-Drupal-User-Group/events/33627272/", enumerator.Current.EventList[0].Description.Value);

            // Number of timezones
            Assert.Single(enumerator.Current.TimeZoneList);
            Assert.Single(enumerator.Current.TimeZoneList[0].StandardRuleList);

            // timezone properties
            Assert.Equal("America/Phoenix", enumerator.Current.TimeZoneList[0].Id.Value);
            Assert.Equal(new Uri("http://tzurl.org/zoneinfo-outlook/America/Phoenix"), enumerator.Current.TimeZoneList[0].Url.Value);
            Assert.Equal("MST", enumerator.Current.TimeZoneList[0].StandardRuleList[0].NameList[0].Value);
            Assert.Equal(new IcsUtcOffset(new TimeSpan(0, -7, 0)), enumerator.Current.TimeZoneList[0].StandardRuleList[0].OffsetFrom.Value);
            Assert.Equal(new IcsUtcOffset(new TimeSpan(0, -7, 0)), enumerator.Current.TimeZoneList[0].StandardRuleList[0].OffsetTo.Value);
        }

        [Fact]
        public async Task Support_authenticity_call_event_Example()
        {
            using var strReader = File.OpenText(Path.Combine(GetOutputFolder(), "Assets", "authenticity_call_event.ics"));
            var icsReader = new IcsReader(strReader);

            Assert.NotNull(icsReader);

            IAsyncEnumerator<IcsCalendar> enumerator = icsReader.ReadAsync().GetAsyncEnumerator();

            // Get calendar object
            Assert.True(await enumerator.MoveNextAsync());

            // Calendar properties
            Assert.Equal("2.0", enumerator.Current.Version.Value);
            Assert.Equal("PUBLISH", enumerator.Current.Method.Value);
            Assert.Equal("-//Notando//NONSGML DoReserve//EN", enumerator.Current.ProductId.Value);

            // Number of events
            Assert.Single(enumerator.Current.EventList);

            // Event properties
            Assert.NotNull(enumerator.Current.EventList[0].Uid);
            Assert.Equal("sc123450@simplybook.me", enumerator.Current.EventList[0].Uid.Value);
            Assert.NotNull(enumerator.Current.EventList[0].Classification);
            Assert.Equal(IcsClassificationValue.Public, enumerator.Current.EventList[0].Classification.Value);
            Assert.Equal(new DateTime(2018, 5, 20, 2, 40, 36), enumerator.Current.EventList[0].DateTimeStamp.Value);
            Assert.Equal(new DateTime(2018, 5, 24, 10, 0, 0), enumerator.Current.EventList[0].Start.ValueAsDateTime);
            Assert.Equal(new DateTime(2018, 5, 24, 10, 30, 0), enumerator.Current.EventList[0].End.ValueAsDateTime);
            Assert.Equal("Authenticity Call", enumerator.Current.EventList[0].Summary.Value);
            Assert.Equal("You were appointed to Authenticity Call event with DigiCert, Inc. provider.", enumerator.Current.EventList[0].Description.Value);
            Assert.Equal("MAILTO:xyz@digicert.com", enumerator.Current.EventList[0].Organizer.Value);
            Assert.Equal("DigiCert, Inc.: DigiCert, Inc.", enumerator.Current.EventList[0].Organizer.CommonName);

            // Custom property
            Assert.Equal("X-MS-OLK-FORCEINSPECTOROPEN", enumerator.Current.CustomProperties[0].Name);
            Assert.Equal("TRUE", enumerator.Current.CustomProperties[0].Value);
        }

        [Fact]
        public async Task Support_event_with_alarm_Example()
        {
            using var strReader = File.OpenText(Path.Combine(GetOutputFolder(), "Assets", "event_with_alarm.ics"));
            var icsReader = new IcsReader(strReader);

            Assert.NotNull(icsReader);

            IAsyncEnumerator<IcsCalendar> enumerator = icsReader.ReadAsync().GetAsyncEnumerator();

            // Get calendar object
            Assert.True(await enumerator.MoveNextAsync());

            // Calendar properties

            // Number of events
            Assert.Single(enumerator.Current.EventList);

            // 1. event 
            Assert.Equal("eb9e1bd2-ceba-499f-be77-f02773954c72", enumerator.Current.EventList[0].Uid.Value);
            Assert.Equal("Event with an alarm", enumerator.Current.EventList[0].Summary.Value);
            Assert.Equal("This is an event with an alarm.", enumerator.Current.EventList[0].Description.Value);
            Assert.Equal("mailto:stomlinson@mozilla.com", enumerator.Current.EventList[0].Organizer.Value);

            // Alarm
            Assert.Single(enumerator.Current.EventList[0].AlarmList);
            Assert.Equal(IcsActionValue.Display, enumerator.Current.EventList[0].AlarmList[0].Action.Value);
            Assert.Equal(new TimeSpan(0, -5, 0), enumerator.Current.EventList[0].AlarmList[0].Trigger.ValueAsTimeSpan);
            Assert.Equal(IcsTriggerRelationship.Start, enumerator.Current.EventList[0].AlarmList[0].Trigger.Relationship);
            Assert.Equal("Reminder", enumerator.Current.EventList[0].AlarmList[0].Description.Value);
        }

        [Fact]
        public async Task Support_holidays_Example()
        {
            using var strReader = File.OpenText(Path.Combine(GetOutputFolder(), "Assets", "holidays.ics"));
            var icsReader = new IcsReader(strReader);

            Assert.NotNull(icsReader);

            IAsyncEnumerator<IcsCalendar> enumerator = icsReader.ReadAsync().GetAsyncEnumerator();

            // Get calendar object
            Assert.True(await enumerator.MoveNextAsync());

            // Calendar properties
            Assert.Equal("2.0", enumerator.Current.Version.Value);
            Assert.Equal("PUBLISH", enumerator.Current.Method.Value);
            Assert.Equal("-//beispiel.de//iCal//DE", enumerator.Current.ProductId.Value);

            // Number of events
            Assert.Equal(8, enumerator.Current.EventList.Count);

            // 1. event 
            Assert.NotNull(enumerator.Current.EventList[0].Uid);
            Assert.Equal("Winterferien 2022 Berlin", enumerator.Current.EventList[0].Summary.Value);
            Assert.Single(enumerator.Current.EventList[0].CategoriesList);
            Assert.Equal(2, enumerator.Current.EventList[0].CategoriesList[0].Values.Length);
            Assert.Equal("Ferien", enumerator.Current.EventList[0].CategoriesList[0].Values[0]);
            Assert.Equal("Berlin", enumerator.Current.EventList[0].CategoriesList[0].Values[1]);
            Assert.Equal(new DateTime(2022, 5, 26, 2, 30, 30), enumerator.Current.EventList[0].Created.Value);
            Assert.Equal(new DateTime(2022, 5, 26, 2, 30, 30), enumerator.Current.EventList[0].LastModified.Value);
            Assert.Equal(new DateTime(2022, 5, 26, 2, 30, 30), enumerator.Current.EventList[0].DateTimeStamp.Value);
            Assert.Equal(new DateOnly(2022, 1, 29), enumerator.Current.EventList[0].Start.ValueAsDate);
            Assert.Equal(new DateOnly(2022, 2, 6), enumerator.Current.EventList[0].End.ValueAsDate);
            Assert.Equal(new Uri("http://www.beispiel.de"), enumerator.Current.EventList[0].Url.Value);
            Assert.Equal(IcsTransparencyType.Transparent, enumerator.Current.EventList[0].Transparency.Value);
            Assert.Equal("1001@beispiel.de", enumerator.Current.EventList[0].Uid.Value);

            // 2. event 
            Assert.NotNull(enumerator.Current.EventList[1].Uid);
            Assert.Equal("Osterferien 2022 Berlin", enumerator.Current.EventList[1].Summary.Value);
            Assert.Single(enumerator.Current.EventList[1].CategoriesList);
            Assert.Equal(2, enumerator.Current.EventList[1].CategoriesList[0].Values.Length);
            Assert.Equal("Ferien", enumerator.Current.EventList[1].CategoriesList[0].Values[0]);
            Assert.Equal("Berlin", enumerator.Current.EventList[1].CategoriesList[0].Values[1]);
            Assert.Equal(new DateTime(2022, 5, 26, 2, 30, 30), enumerator.Current.EventList[1].Created.Value);
            Assert.Equal(new DateTime(2022, 5, 26, 2, 30, 30), enumerator.Current.EventList[1].LastModified.Value);
            Assert.Equal(new DateTime(2022, 5, 26, 2, 30, 30), enumerator.Current.EventList[1].DateTimeStamp.Value);
            Assert.Equal(new DateOnly(2022, 4, 11), enumerator.Current.EventList[1].Start.ValueAsDate);
            Assert.Equal(new DateOnly(2022, 4, 24), enumerator.Current.EventList[1].End.ValueAsDate);
            Assert.Equal(new Uri("http://www.beispiel.de"), enumerator.Current.EventList[1].Url.Value);
            Assert.Equal(IcsTransparencyType.Transparent, enumerator.Current.EventList[1].Transparency.Value);
            Assert.Equal("1002@beispiel.de", enumerator.Current.EventList[1].Uid.Value);

            // Last event 
            Assert.NotNull(enumerator.Current.EventList[7].Uid);
            Assert.Equal("Weihnachtsferien 2022 Berlin", enumerator.Current.EventList[7].Summary.Value);
            Assert.Single(enumerator.Current.EventList[7].CategoriesList);
            Assert.Equal(2, enumerator.Current.EventList[7].CategoriesList[0].Values.Length);
            Assert.Equal("Ferien", enumerator.Current.EventList[7].CategoriesList[0].Values[0]);
            Assert.Equal("Berlin", enumerator.Current.EventList[7].CategoriesList[0].Values[1]);
            Assert.Equal(new DateTime(2022, 5, 26, 2, 30, 30), enumerator.Current.EventList[7].Created.Value);
            Assert.Equal(new DateTime(2022, 5, 26, 2, 30, 30), enumerator.Current.EventList[7].LastModified.Value);
            Assert.Equal(new DateTime(2022, 5, 26, 2, 30, 30), enumerator.Current.EventList[7].DateTimeStamp.Value);
            Assert.Equal(new DateOnly(2022, 12, 22), enumerator.Current.EventList[7].Start.ValueAsDate);
            Assert.Equal(new DateOnly(2023, 1, 3), enumerator.Current.EventList[7].End.ValueAsDate);
            Assert.Equal(new Uri("http://www.beispiel.de"), enumerator.Current.EventList[7].Url.Value);
            Assert.Equal(IcsTransparencyType.Transparent, enumerator.Current.EventList[7].Transparency.Value);
            Assert.Equal("1008@beispiel.de", enumerator.Current.EventList[7].Uid.Value);
        }

        [Fact]
        public async Task Support_office_2012_owa_Example()
        {
            using var strReader = File.OpenText(Path.Combine(GetOutputFolder(), "Assets", "office_2012_owa.ics"));
            var icsReader = new IcsReader(strReader);

            Assert.NotNull(icsReader);

            IAsyncEnumerator<IcsCalendar> enumerator = icsReader.ReadAsync().GetAsyncEnumerator();

            // Get calendar object
            Assert.True(await enumerator.MoveNextAsync());

            // Calendar properties
            Assert.Equal("2.0", enumerator.Current.Version.Value);
            Assert.Equal("PUBLISH", enumerator.Current.Method.Value);
            Assert.Equal("Microsoft Exchange Server 2010", enumerator.Current.ProductId.Value);
            Assert.Equal("X-WR-CALNAME", enumerator.Current.CustomProperties[0].Name);
            Assert.Equal("Fake Calendar", enumerator.Current.CustomProperties[0].Value);

            // Number of events
            Assert.Equal(4, enumerator.Current.EventList.Count);

            // 1. event 
            Assert.Null(enumerator.Current.EventList[0].Uid);
            Assert.Equal(" TEST Syd", enumerator.Current.EventList[0].Summary.Value);
            Assert.Equal(new DateTime(2020, 10, 28, 13, 30, 0), enumerator.Current.EventList[0].Start.ValueAsDateTime);
            Assert.Equal("(GMT+10:00) Canberra, Melbourne, Sydney", enumerator.Current.EventList[0].Start.TimeZoneId);
            Assert.Equal(new DateTime(2020, 10, 28, 15, 0, 0), enumerator.Current.EventList[0].End.ValueAsDateTime);
            Assert.Equal("(GMT+10:00) Canberra, Melbourne, Sydney", enumerator.Current.EventList[0].End.TimeZoneId);
            Assert.Equal(5, enumerator.Current.EventList[0].Priority.Value);
            Assert.Equal(IcsTransparencyType.Opaque, enumerator.Current.EventList[0].Transparency.Value);
            Assert.Equal(IcsEventStatusValue.Confirmed, enumerator.Current.EventList[0].Status.Value);
            Assert.Equal(0, enumerator.Current.EventList[0].Sequence.Value);
            Assert.Equal("X-MICROSOFT-CDO-APPT-SEQUENCE", enumerator.Current.EventList[0].CustomProperties[0].Name);
            Assert.Equal("0", enumerator.Current.EventList[0].CustomProperties[0].Value);

            //// 2. event 
            Assert.Null(enumerator.Current.EventList[1].Uid);
            Assert.Equal(" TEST", enumerator.Current.EventList[1].Summary.Value);
            Assert.Equal(new DateTime(2020, 10, 28, 13, 30, 0), enumerator.Current.EventList[1].Start.ValueAsDateTime);
            Assert.Equal("(UTC-05:00) Eastern Time (US & Canada)", enumerator.Current.EventList[1].Start.TimeZoneId);
            Assert.Equal(new DateTime(2020, 10, 28, 15, 0, 0), enumerator.Current.EventList[1].End.ValueAsDateTime);
            Assert.Equal("(UTC-05:00) Eastern Time (US & Canada)", enumerator.Current.EventList[1].End.TimeZoneId);
            Assert.Equal(5, enumerator.Current.EventList[1].Priority.Value);
            Assert.Equal(IcsTransparencyType.Opaque, enumerator.Current.EventList[1].Transparency.Value);
            Assert.Equal(IcsEventStatusValue.Confirmed, enumerator.Current.EventList[1].Status.Value);
            Assert.Equal(0, enumerator.Current.EventList[1].Sequence.Value);
            Assert.Equal("X-MICROSOFT-CDO-APPT-SEQUENCE", enumerator.Current.EventList[1].CustomProperties[0].Name);
            Assert.Equal("0", enumerator.Current.EventList[1].CustomProperties[0].Value);
        }

        private static string GetOutputFolder()
        {
            // Get the full location of the assembly
            string assemblyPath = System.Reflection.Assembly.GetAssembly(typeof(TestIcsReader)).Location;

            // Get the folder that's in
            return Path.GetDirectoryName(assemblyPath);
        }
    }
}

