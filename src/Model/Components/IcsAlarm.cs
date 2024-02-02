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

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalendar Alarm Component
    /// </summary>
    public class IcsAlarm : IcsComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsAlarm"/> class.
        /// </summary>
        public IcsAlarm()
            : base(IcsComponentNames.Alarm)
        {
            AttachmentList = new List<IcsAttachment>();
            AttendeeList = new List<IcsAttendee>();
        }

        /// <summary>
        /// Defines the action to be invoked when the alarm is triggered.
        /// </summary>
        public IcsAction Action { get; set; }

        /// <summary>
        /// A list of attachments. For an Audio action, only one attachment is allowed.
        /// </summary>
        public IList<IcsAttachment> AttachmentList { get; set; }

        /// <summary>
        /// A list of attendees
        /// </summary>
        public IList<IcsAttendee> AttendeeList { get; set; }

        /// <summary>
        /// Provides a more complete description of the alarm than that provided by the 
        /// <see cref="Summary"/> property.
        /// </summary>
        public IcsDescription Description { get; set; }

        /// <summary>
        /// Specifies the delay period, after which the alarm will repeat.
        /// </summary>
        public IcsDuration Duration { get; set; }

        /// <summary>
        /// Specifies the number of additional repetitions that the alarm will be 
        /// triggered.
        /// </summary>
        public IcsRepeatCount Repeat { get; set; }

        /// <summary>
        /// Defines a short summary or subject for the alarm.
        /// </summary>
        public IcsSummary Summary { get; set; }

        /// <summary>
        /// Specifies when the alarm will be triggered
        /// </summary>
        public IcsTrigger Trigger { get; set; }

        /// <summary>
        /// Adds a new attachment property to the alarm
        /// </summary>
        /// <returns>Gives back the newly created attachment property</returns>
        public IcsAttachment AddAttachment()
        {
            var o = new IcsAttachment();
            AttachmentList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new attachment property to the alarm
        /// </summary>
        /// <param name="value">An url value</param>
        /// <returns>Gives back the newly created attachment property</returns>
        public IcsAttachment AddAttachment(Uri value)
        {
            var o = new IcsAttachment(value);
            AttachmentList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new attachment property to the alarm
        /// </summary>
        /// <param name="value">An inline binary encoded value</param>
        /// <returns>Gives back the newly created attachment property</returns>
        public IcsAttachment AddAttachment(byte[] value)
        {
            var o = new IcsAttachment(value);
            AttachmentList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new attendee property to the alarm
        /// </summary>
        /// <returns>Gives back the newly created attendee property</returns>
        public IcsAttendee AddAttendee()
        {
            var o = new IcsAttendee();
            AttendeeList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new attendee property to the alarm
        /// </summary>
        /// <param name="value">A string value</param>
        /// <returns>Gives back the newly created attendee property</returns>
        public IcsAttendee AddAttendee(string value)
        {
            var o = new IcsAttendee(value);
            AttendeeList.Add(o);
            return o;
        }

        /// <summary>
        /// Serializes the complete component to a text writer
        /// </summary>
        /// <param name="textWriter">Text writer</param>
        public override void WriteContent(TextWriter textWriter)
        {
            textWriter.Write(IcsCoreNames.Begin, IcsComponentNames.Alarm);

            textWriter.WriteProperty(Action);
            textWriter.WritePropertyList(AttachmentList);
            textWriter.WritePropertyList(AttendeeList);
            textWriter.WriteProperty(Description);
            textWriter.WriteProperty(Duration);
            textWriter.WriteProperty(Repeat);
            textWriter.WriteProperty(Summary);
            textWriter.WriteProperty(Trigger);

            base.WriteContent(textWriter);

            textWriter.Write(IcsCoreNames.End, IcsComponentNames.Alarm);
        }

        /// <summary>
        /// Serializes the complete component to a text writer
        /// </summary>
        /// <param name="textWriter">Text writer</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public override async Task WriteContentAsync(TextWriter textWriter)
        {
            await textWriter.WriteContentAsync(IcsCoreNames.Begin, IcsComponentNames.Alarm);

            await textWriter.WritePropertyAsync(Action);
            await textWriter.WritePropertyListAsync(AttachmentList);
            await textWriter.WritePropertyListAsync(AttendeeList);
            await textWriter.WritePropertyAsync(Description);
            await textWriter.WritePropertyAsync(Duration);
            await textWriter.WritePropertyAsync(Repeat);
            await textWriter.WritePropertyAsync(Summary);
            await textWriter.WritePropertyAsync(Trigger);

            await base.WriteContentAsync(textWriter);

            await textWriter.WriteContentAsync(IcsCoreNames.End, IcsComponentNames.Alarm);
        }
    }
}
