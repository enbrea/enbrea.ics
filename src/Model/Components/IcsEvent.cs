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
    /// Represents an iCalendar Event Component
    /// </summary>
    public class IcsEvent : IcsComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsEvent"/> class.
        /// </summary>
        public IcsEvent()
            : base(IcsComponentNames.Event)
        {
            AlarmList = new List<IcsAlarm>();
            AttachmentList = new List<IcsAttachment>();
            AttendeeList = new List<IcsEventAttendee>();
            CategoriesList = new List<IcsCategories>();
            CommentList = new List<IcsComment>();
            ContactList = new List<IcsContact>();
            ExceptionDateTimesList = new List<IcsExceptionDateTimes>();
            RecurrenceDateTimesList = new List<IcsRecurrenceDateTimes>();
            RecurrenceRuleList = new List<IcsRecurrenceRule>();
            RelatedToList = new List<IcsRelatedTo>();
            RequestStatusList = new List<IcsRequestStatus>();
            ResourcesList = new List<IcsResources>();
        }

        /// <summary>
        /// A list of alarms
        /// </summary>
        public IList<IcsAlarm> AlarmList { get; set; }

        /// <summary>
        /// A list of attachments
        /// </summary>
        public IList<IcsAttachment> AttachmentList { get; set; }

        /// <summary>
        /// A list of attendees
        /// </summary>
        public IList<IcsEventAttendee> AttendeeList { get; set; }

        /// <summary>
        /// A list of catagories
        /// </summary>
        public IList<IcsCategories> CategoriesList { get; set; }

        /// <summary>
        /// Defines the access classification for the event. 
        /// </summary>
        public IcsClassification Classification { get; set; }

        /// <summary>
        /// A list of comments
        /// </summary>
        public IList<IcsComment> CommentList { get; set; }

        /// <summary>
        /// A list of contacts
        /// </summary>
        public IList<IcsContact> ContactList { get; set; }

        /// <summary>
        /// Specifies the date and time that the event was created.
        /// </summary>
        public IcsCreated Created { get; set; }

        /// <summary>
        /// Specifies the date and time that the information associated with the event was 
        /// last revised.
        /// </summary>
        public IcsDateTimeStamp DateTimeStamp { get; set; }

        /// <summary>
        /// Provides a more complete description of the event than that provided by the 
        /// <see cref="Summary"/> property.
        /// </summary>
        public IcsDescription Description { get; set; }

        /// <summary>
        /// Specifies a positive duration of time. It may be used to specify a duration of the event, 
        /// instead of an explicit <see cref="End"/> value.
        /// </summary>
        public IcsDuration Duration { get; set; }

        /// <summary>
        /// Specifies the date and time that the event ends.
        /// </summary>
        public IcsDateTimeEnd End { get; set; }

        /// <summary>
        /// A list of DATE-TIME exceptions for recurring events.
        /// </summary>
        public IList<IcsExceptionDateTimes> ExceptionDateTimesList { get; set; }

        /// <summary>
        /// Specifies information related to the global position for the activity specified 
        /// by the event.
        /// </summary>
        public IcsGeo Geo { get; set; }

        /// <summary>
        /// Specifies the date and time that the information associated with the event was last revised.
        /// </summary>
        public IcsLastModified LastModified { get; set; }

        /// <summary>
        /// Defines the intended venue for the activity defined by the event.
        /// </summary>
        public IcsLocation Location { get; set; }

        /// <summary>
        /// Defines the organizer for the event.
        /// </summary>
        public IcsOrganizer Organizer { get; set; }

        /// <summary>
        /// Defines the relative priority for the event. Must be in the range [0..9].
        /// </summary>
        public IcsPriority Priority { get; set; }

        /// <summary>
        /// A list of DATE-TIME values for recurring events.
        /// </summary>
        public IList<IcsRecurrenceDateTimes> RecurrenceDateTimesList { get; set; }

        /// <summary>
        /// Is used in conjunction with the <see cref="Uid"/> and <see cref="Sequence"/> properties to identify a 
        /// specific instance of an event.
        /// </summary>
        public IcsRecurrenceId RecurrenceId { get; set; }

        /// <summary>
        /// A list of recurrence rules.
        /// </summary>
        public IList<IcsRecurrenceRule> RecurrenceRuleList { get; set; }

        /// <summary>
        /// List of relationships or references between this event and other calendar components.
        /// </summary>
        public IList<IcsRelatedTo> RelatedToList { get; set; }

        /// <summary>
        /// List of status codes returned for a scheduling request.
        /// </summary>
        public IList<IcsRequestStatus> RequestStatusList { get; set; }

        /// <summary>
        /// List of Uniform Resource Locators (URL) associated with the event.
        /// </summary>
        public IList<IcsResources> ResourcesList { get; set; }

        /// <summary>
        /// Defines the revision sequence number of the event within a sequence of revisions.
        /// </summary>
        public IcsSequence Sequence { get; set; }

        /// <summary>
        /// Specifies when the event begins.
        /// </summary>
        public IcsDateTimeStart Start { get; set; }

        /// <summary>
        /// Defines the overall status or confirmation for the event.
        /// </summary>
        public IcsEventStatus Status { get; set; }

        /// <summary>
        /// Defines a short summary or subject for the event.
        /// </summary>
        public IcsSummary Summary { get; set; }

        /// <summary>
        /// Defines whether or not the event is transparent to busy time searches.
        /// </summary>
        public IcsTransparency Transparency { get; set; }

        /// <summary>
        /// Persistent, globally unique identifier for the event.
        /// </summary>
        public IcsUid Uid { get; set; }

        /// <summary>
        /// Defines a Uniform Resource Locator (URL) associated with the event.
        /// </summary>
        public IcsUrl Url { get; set; }

        /// <summary>
        /// Adds a new alarm sub component to the event
        /// </summary>
        /// <returns>Gives back the newly created alarm sub component</returns>
        public IcsAlarm AddAlarm()
        {
            var o = new IcsAlarm();
            AlarmList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new attachment property to the event
        /// </summary>
        /// <returns>Gives back the newly created attachment property</returns>
        public IcsAttachment AddAttachment()
        {
            var o = new IcsAttachment();
            AttachmentList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new attachment property to the event
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
        /// Adds a new attachment property to the event
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
        /// Adds a new attendee property to the event
        /// </summary>
        /// <returns>Gives back the newly created attendee property</returns>
        public IcsEventAttendee AddAttendee()
        {
            var o = new IcsEventAttendee();
            AttendeeList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new attendee property to the event
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
        /// Adds a new categories property to the event
        /// </summary>
        /// <returns>Gives back the newly created categories property</returns>
        public IcsCategories AddCategories()
        {
            var o = new IcsCategories();
            CategoriesList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new categories property to the event
        /// </summary>
        /// <param name="values">An array of category names</param>
        /// <returns>Gives back the newly created categories property</returns>
        public IcsCategories AddCategories(string[] values)
        {
            var o = new IcsCategories(values);
            CategoriesList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new comment property to the event
        /// </summary>
        /// <returns>Gives back the newly created comment property</returns>
        public IcsComment AddComment()
        {
            var o = new IcsComment();
            CommentList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new comment property to the event
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
        /// Adds a new contact property to the event
        /// </summary>
        /// <returns>Gives back the newly created contact property</returns>
        public IcsContact AddContact()
        {
            var o = new IcsContact();
            ContactList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new contact property to the event
        /// </summary>
        /// <param name="value">A string value</param>
        /// <returns>Gives back the newly created contact property</returns>
        public IcsContact AddContact(string value)
        {
            var o = new IcsContact(value);
            ContactList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new exception date-times property to the event
        /// </summary>
        /// <returns>Gives back the newly created exception date-times property</returns>
        public IcsExceptionDateTimes AddExceptionDateTimes()
        {
            var o = new IcsExceptionDateTimes();
            ExceptionDateTimesList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new exception date-times property to the event
        /// </summary>
        /// <param name="value">An array of date values</param>
        /// <returns>Gives back the newly created exception date-times property</returns>
        public IcsExceptionDateTimes AddExceptionDateTimes(DateOnly[] values)
        {
            var o = new IcsExceptionDateTimes(values);
            ExceptionDateTimesList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new exception date-times property to the event
        /// </summary>
        /// <param name="value">An array of date-time values</param>
        /// <returns>Gives back the newly created exception date-times property</returns>
        public IcsExceptionDateTimes AddExceptionDateTimes(DateTime[] values)
        {
            var o = new IcsExceptionDateTimes(values);
            ExceptionDateTimesList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new recurrence date-times property to the event
        /// </summary>
        /// <returns>Gives back the newly created recurrence date-times property</returns>
        public IcsRecurrenceDateTimes AddRecurrenceDateTimes()
        {
            var o = new IcsRecurrenceDateTimes();
            RecurrenceDateTimesList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new recurrence date-times property to the event
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
        /// Adds a new recurrence date-times property to the event
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
        /// Adds a new recurrence date-times property to the event
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
        /// Adds a new recurrence rule property to the event
        /// </summary>
        /// <returns>Gives back the newly created recurrence rule property</returns>
        public IcsRecurrenceRule AddRecurrenceRule()
        {
            var o = new IcsRecurrenceRule();
            RecurrenceRuleList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new recurrence rule property to the event
        /// </summary>
        /// <param name="value">A recurrence rule pattern</param>
        /// <returns>Gives back the newly created recurrence rule property</returns>
        public IcsRecurrenceRule AddRecurrenceRule(IcsRecurrencePattern value)
        {
            var o = new IcsRecurrenceRule(value);
            RecurrenceRuleList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new related to property to the event
        /// </summary>
        /// <returns>Gives back the newly created related to property</returns>
        public IcsRelatedTo AddRelatedTo()
        {
            var o = new IcsRelatedTo();
            RelatedToList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new related to property to the event
        /// </summary>
        /// <param name="value">A string value</param>
        /// <returns>Gives back the newly created related to property</returns>
        public IcsRelatedTo AddRelatedTo(string value)
        {
            var o = new IcsRelatedTo(value);
            RelatedToList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new request status property to the event
        /// </summary>
        /// <returns>Gives back the newly created request status property</returns>
        public IcsRequestStatus AddRequestStatus()
        {
            var o = new IcsRequestStatus();
            RequestStatusList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new request status property to the event
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
        /// Adds a new resources property to the event
        /// </summary>
        /// <returns>Gives back the newly created resources property</returns>
        public IcsResources AddResources()
        {
            var o = new IcsResources();
            ResourcesList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new resources property to the event
        /// </summary>
        /// <param name="values">An array of resource names</param>
        /// <returns>Gives back the newly created resources property</returns>
        public IcsResources AddResources(string[] values)
        {
            var o = new IcsResources(values);
            ResourcesList.Add(o);
            return o;
        }

        /// <summary>
        /// Serializes the complete component to a stream
        /// </summary>
        /// <param name="textWriter">Text writer</param>
        public override void WriteContent(TextWriter textWriter)
        {
            textWriter.Write(IcsCoreNames.Begin, IcsComponentNames.Event);

            textWriter.WriteProperty(Uid);
            textWriter.WriteProperty(Created);
            textWriter.WriteProperty(LastModified);
            textWriter.WriteProperty(DateTimeStamp);
            textWriter.WriteProperty(Start);
            textWriter.WriteProperty(End);
            textWriter.WriteProperty(Duration);
            textWriter.WriteProperty(Summary);
            textWriter.WriteProperty(Description);
            textWriter.WriteProperty(Organizer);
            textWriter.WriteProperty(Sequence);
            textWriter.WriteProperty(Classification);
            textWriter.WriteProperty(Transparency);
            textWriter.WriteProperty(Status);
            textWriter.WriteProperty(Priority);
            textWriter.WriteProperty(Url);
            textWriter.WriteProperty(Location);
            textWriter.WriteProperty(Geo);
            textWriter.WriteProperty(RecurrenceId);

            textWriter.WriteComponentList(AlarmList);
            textWriter.WritePropertyList(AttachmentList);
            textWriter.WritePropertyList(AttendeeList);
            textWriter.WritePropertyList(CategoriesList);
            textWriter.WritePropertyList(CommentList);
            textWriter.WritePropertyList(ContactList);
            textWriter.WritePropertyList(ExceptionDateTimesList);
            textWriter.WritePropertyList(RecurrenceDateTimesList);
            textWriter.WritePropertyList(RecurrenceRuleList);
            textWriter.WritePropertyList(RelatedToList);
            textWriter.WritePropertyList(RequestStatusList);
            textWriter.WritePropertyList(ResourcesList);

            base.WriteContent(textWriter);

            textWriter.Write(IcsCoreNames.End, IcsComponentNames.Event);
        }

        /// <summary>
        /// Serializes the complete component to a stream
        /// </summary>
        /// <param name="textWriter">Text writer</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public override async Task WriteContentAsync(TextWriter textWriter)
        {
            await textWriter.WriteContentAsync(IcsCoreNames.Begin, IcsComponentNames.Event);

            await textWriter.WritePropertyAsync(Uid);
            await textWriter.WritePropertyAsync(Created);
            await textWriter.WritePropertyAsync(LastModified);
            await textWriter.WritePropertyAsync(DateTimeStamp);
            await textWriter.WritePropertyAsync(Start);
            await textWriter.WritePropertyAsync(End);
            await textWriter.WritePropertyAsync(Duration);
            await textWriter.WritePropertyAsync(Summary);
            await textWriter.WritePropertyAsync(Description);
            await textWriter.WritePropertyAsync(Organizer);
            await textWriter.WritePropertyAsync(Sequence);
            await textWriter.WritePropertyAsync(Classification);
            await textWriter.WritePropertyAsync(Transparency);
            await textWriter.WritePropertyAsync(Status);
            await textWriter.WritePropertyAsync(Priority);
            await textWriter.WritePropertyAsync(Url);
            await textWriter.WritePropertyAsync(Location);
            await textWriter.WritePropertyAsync(Geo);
            await textWriter.WritePropertyAsync(RecurrenceId);

            await textWriter.WriteComponentListAsync(AlarmList);
            await textWriter.WritePropertyListAsync(AttachmentList);
            await textWriter.WritePropertyListAsync(AttendeeList);
            await textWriter.WritePropertyListAsync(CategoriesList);
            await textWriter.WritePropertyListAsync(CommentList);
            await textWriter.WritePropertyListAsync(ContactList);
            await textWriter.WritePropertyListAsync(ExceptionDateTimesList);
            await textWriter.WritePropertyListAsync(RecurrenceDateTimesList); 
            await textWriter.WritePropertyListAsync(RecurrenceRuleList);
            await textWriter.WritePropertyListAsync(RelatedToList);
            await textWriter.WritePropertyListAsync(RequestStatusList);
            await textWriter.WritePropertyListAsync(ResourcesList);

            await base.WriteContentAsync(textWriter);

            await textWriter.WriteContentAsync(IcsCoreNames.End, IcsComponentNames.Event);
        }

    }
}
