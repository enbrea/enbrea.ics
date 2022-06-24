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
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an abstract iCalendar Time Zone Rule Component
    /// </summary>
    public abstract class IcsTimeZoneRule : IcsComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZoneRule"/> class.
        /// </summary>
        /// <param name="name">The name of the component</param>
        public IcsTimeZoneRule(string name)
            : base(name)
        {
            CommentList = new List<IcsComment>();
            RecurrenceDateTimesList = new List<IcsRecurrenceDateTimes>();
            NameList = new List<IcsTimeZoneName>();
        }

        /// <summary>
        /// A list of comments
        /// </summary>
        public IList<IcsComment> CommentList { get; set; }

        /// <summary>
        /// Specifies the offset that is in use prior to this time zone observance.
        /// </summary>
        public IcsTimeZoneOffsetFrom OffsetFrom { get; set; }

        /// <summary>
        /// Specifies the offset that is in use in this time zone observance.
        /// </summary>
        public IcsTimeZoneOffsetTo OffsetTo { get; set; }

        /// <summary>
        /// A list of DATE-TIME values for the onset DATE-TIME values for the 
        /// observance.
        /// </summary>
        public IList<IcsRecurrenceDateTimes> RecurrenceDateTimesList { get; set; }

        /// <summary>
        /// Specifies the recurrence rule of the onset DATE-TIME values for the 
        /// observance.
        /// </summary>
        public IcsRecurrenceRule RecurrenceRule { get; set; }

        /// <summary>
        /// Specifies the start of the onset DATE-TIME values for the observance. 
        /// </summary>
        public IcsDateTimeStart Start { get; set; }

        /// <summary>
        /// A list of time zone names
        /// </summary>
        public IList<IcsTimeZoneName> NameList { get; set; }

        /// <summary>
        /// Adds a new comment property to the time zone rule 
        /// </summary>
        /// <returns>Gives back the newly created comment property</returns>
        public IcsComment AddComment()
        {
            var o = new IcsComment();
            CommentList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new comment property to the time zone rule 
        /// </summary>
        /// <param name="value">A string value</param>
        /// <returns>Gives back the newly created comment property</returns>
        public IcsComment AddComment(string value)
        {
            var o = new IcsComment(value);
            CommentList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new recurrence date times property to the time zone rule 
        /// </summary>
        /// <returns>Gives back the newly created recurrence date times property</returns>
        public IcsRecurrenceDateTimes AddRecurrenceDateTimes()
        {
            var o = new IcsRecurrenceDateTimes();
            RecurrenceDateTimesList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new recurrence date-times property to the time zone rule 
        /// </summary>
        /// <param name="value">An array of date values</param>
        /// <returns>Gives back the newly created recurrence date-times property</returns>
        public IcsRecurrenceDateTimes AddRecurrenceDateTimes(DateOnly[] values)
        {
            var o = new IcsRecurrenceDateTimes(values);
            RecurrenceDateTimesList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new recurrence date-times property to the time zone rule 
        /// </summary>
        /// <param name="value">An array of date-time values</param>
        /// <returns>Gives back the newly created recurrence date-times property</returns>
        public IcsRecurrenceDateTimes AddRecurrenceDateTimes(DateTime[] values)
        {
            var o = new IcsRecurrenceDateTimes(values);
            RecurrenceDateTimesList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new recurrence date-times property to the time zone rule 
        /// </summary>
        /// <param name="value">An array of periods of time</param>
        /// <returns>Gives back the newly created recurrence date-times property</returns>
        public IcsRecurrenceDateTimes AddRecurrenceDateTimes(IcsPeriod[] values)
        {
            var o = new IcsRecurrenceDateTimes(values);
            RecurrenceDateTimesList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new time zone name property to the time zone rule 
        /// </summary>
        /// <returns>Gives back the newly created time zone name property</returns>
        public IcsTimeZoneName AddTimeZoneName()
        {
            var o = new IcsTimeZoneName();
            NameList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new time zone name property to the time zone rule 
        /// </summary>
        /// <param name="value">A string value</param>
        /// <returns>Gives back the newly created time zone name property</returns>
        public IcsTimeZoneName AddTimeZoneName(string value)
        {
            var o = new IcsTimeZoneName();
            NameList.Add(o);
            return o;
        }

        /// <summary>
        /// Serializes the complete sub component to a stream
        /// </summary>
        /// <param name="textWriter">Text writer</param>
        public override void WriteContent(TextWriter textWriter)
        {
            textWriter.Write(IcsCoreNames.Begin, Name);

            textWriter.WritePropertyList(CommentList);
            textWriter.WriteProperty(OffsetFrom);
            textWriter.WriteProperty(OffsetTo);
            textWriter.WritePropertyList(RecurrenceDateTimesList);
            textWriter.WriteProperty(RecurrenceRule);
            textWriter.WriteProperty(Start);
            textWriter.WritePropertyList(NameList);

            base.WriteContent(textWriter);

            textWriter.Write(IcsCoreNames.End, Name);
        }

        /// <summary>
        /// Serializes the complete sub component to a stream
        /// </summary>
        /// <param name="textWriter">Text writer</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public override async Task WriteContentAsync(TextWriter textWriter)
        {
            await textWriter.WriteContentAsync(IcsCoreNames.Begin, Name);

            await textWriter.WritePropertyListAsync(CommentList);
            await textWriter.WritePropertyAsync(OffsetFrom);
            await textWriter.WritePropertyAsync(OffsetTo);
            await textWriter.WritePropertyListAsync(RecurrenceDateTimesList);
            await textWriter.WritePropertyAsync(RecurrenceRule);
            await textWriter.WritePropertyAsync(Start);
            await textWriter.WritePropertyListAsync(NameList);

            await base.WriteContentAsync(textWriter);

            await textWriter.WriteContentAsync(IcsCoreNames.End, Name);
        }
    }
}
