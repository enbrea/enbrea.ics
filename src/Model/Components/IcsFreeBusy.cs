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

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalendar FreeBusy Component
    /// </summary>
    public class IcsFreeBusy : IcsComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsFreeBusy"/> class.
        /// </summary>
        public IcsFreeBusy()
            : base(IcsComponentNames.FreeBusy)
        {
            AttendeeList = [];
            CommentList = [];
            FreeBusyTimeList = [];
            RequestStatusList = [];
        }

        /// <summary>
        /// A list of attendees
        /// </summary>
        public IList<IcsAttendee> AttendeeList { get; set; }

        /// <summary>
        /// A list of comments
        /// </summary>
        public IList<IcsComment> CommentList { get; set; }

        /// <summary>
        /// Is used to represent contact information or alternately a reference to contact 
        /// information associated with this component.
        /// </summary>
        public IcsContact Contact { get; set; }

        /// <summary>
        /// Specifies the DATE-TIME that component was created.
        /// </summary>
        public IcsDateTimeStamp DateTimeStamp { get; set; }

        /// <summary>
        /// Specifies the end of an inclusive time window that surrounds the busy time 
        /// information.
        /// </summary>
        public IcsDateTimeEnd End { get; set; }

        /// <summary>
        /// Defines one or more free or busy time intervals.
        /// </summary>
        public IList<IcsFreeBusyTime> FreeBusyTimeList { get; set; }

        /// <summary>
        /// Specifies the calendar user requesting the free or busy time.
        /// </summary>
        public IcsOrganizer Organizer { get; set; }

        /// <summary>
        /// List of status codes returned for a scheduling request.
        /// </summary>
        public IList<IcsRequestStatus> RequestStatusList { get; set; }

        /// <summary>
        /// Specifies the start of an inclusive time window that surrounds the busy time 
        /// information.
        /// </summary>
        public IcsDateTimeStart Start { get; set; }

        /// <summary>
        /// Persistent, globally unique identifier for the freebusy component.
        /// </summary>
        public IcsUid Uid { get; set; }

        /// <summary>
        /// Defines a Uniform Resource Locator (URL) associated with the freebusy 
        /// component.
        /// </summary>
        public IcsUrl Url { get; set; }

        /// <summary>
        /// Adds a new attendee property to the freebusy
        /// </summary>
        /// <returns>Gives back the newly created attendee property</returns>
        public IcsAttendee AddAttendee()
        {
            var o = new IcsAttendee();
            AttendeeList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new attendee property to the freebusy
        /// </summary>
        /// <param name="value">A string value</param>
        /// <returns>Gives back the newly created attendee property</returns>
        public IcsEventAttendee AddAttendee(string value)
        {
            var o = new IcsEventAttendee(value);
            AttendeeList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new comment property to the freebusy
        /// </summary>
        /// <returns>Gives back the newly created comment property</returns>
        public IcsComment AddComment()
        {
            var o = new IcsComment();
            CommentList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new comment property to the freebusy
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
        /// Adds a new freebusy time property to the freebusy
        /// </summary>
        /// <returns>Gives back the newly created freebusy time property</returns>
        public IcsFreeBusyTime AddFreeBusyTime()
        {
            var o = new IcsFreeBusyTime();
            FreeBusyTimeList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new freebusy time property to the freebusy
        /// </summary>
        /// <param name="values">An array of periods of time</param>
        /// <returns>Gives back the newly created freebusy time property</returns>
        public IcsFreeBusyTime AddFreeBusyTime(IcsPeriod[] values)
        {
            var o = new IcsFreeBusyTime();
            FreeBusyTimeList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new request status property to the freebusy
        /// </summary>
        /// <returns>Gives back the newly created request status property</returns>
        public IcsRequestStatus AddRequestStatus()
        {
            var o = new IcsRequestStatus();
            RequestStatusList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new request status property to the freebusy
        /// </summary>
        /// <param name="value">A status value</param>
        /// <returns>Gives back the newly created request status property</returns>
        public IcsRequestStatus AddRequestStatus(IcsRequestStatusValue value)
        {
            var o = new IcsRequestStatus(value);
            RequestStatusList.Add(o);
            return o;
        }

        /// <summary>
        /// Serializes the complete component to a stream
        /// </summary>
        /// <param name="textWriter">Text writer</param>
        public override void WriteContent(TextWriter textWriter)
        {
            textWriter.WriteContent(IcsCoreNames.Begin, IcsComponentNames.FreeBusy);

            textWriter.WritePropertyList(AttendeeList);
            textWriter.WritePropertyList(CommentList);
            textWriter.WriteProperty(Contact);
            textWriter.WriteProperty(DateTimeStamp);
            textWriter.WriteProperty(End);
            textWriter.WritePropertyList(FreeBusyTimeList);
            textWriter.WriteProperty(Organizer);
            textWriter.WritePropertyList(RequestStatusList);
            textWriter.WriteProperty(Start);
            textWriter.WriteProperty(Uid);
            textWriter.WriteProperty(Url);

            base.WriteContent(textWriter);

            textWriter.WriteContent(IcsCoreNames.End, IcsComponentNames.FreeBusy);
        }

        /// <summary>
        /// Serializes the complete component to a stream
        /// </summary>
        /// <param name="textWriter">Text writer</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public override async Task WriteContentAsync(TextWriter textWriter, CancellationToken cancellationToken = default)
        {
            await textWriter.WriteContentAsync(IcsCoreNames.Begin, IcsComponentNames.FreeBusy, cancellationToken).ConfigureAwait(false);

            await textWriter.WritePropertyListAsync(AttendeeList, cancellationToken).ConfigureAwait(false);
            await textWriter.WritePropertyListAsync(CommentList, cancellationToken).ConfigureAwait(false);
            await textWriter.WritePropertyAsync(Contact, cancellationToken).ConfigureAwait(false);
            await textWriter.WritePropertyAsync(DateTimeStamp, cancellationToken).ConfigureAwait(false);
            await textWriter.WritePropertyAsync(End, cancellationToken).ConfigureAwait(false);
            await textWriter.WritePropertyListAsync(FreeBusyTimeList, cancellationToken).ConfigureAwait(false);
            await textWriter.WritePropertyAsync(Organizer, cancellationToken).ConfigureAwait(false);
            await textWriter.WritePropertyListAsync(RequestStatusList, cancellationToken).ConfigureAwait(false);
            await textWriter.WritePropertyAsync(Start, cancellationToken).ConfigureAwait(false);
            await textWriter.WritePropertyAsync(Uid, cancellationToken).ConfigureAwait(false);
            await textWriter.WritePropertyAsync(Url, cancellationToken).ConfigureAwait(false);

            await base.WriteContentAsync(textWriter, cancellationToken).ConfigureAwait(false);

            await textWriter.WriteContentAsync(IcsCoreNames.End, IcsComponentNames.FreeBusy, cancellationToken).ConfigureAwait(false);
        }

    }
}
