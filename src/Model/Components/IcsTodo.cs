#region ENBREA.ICS - Copyright (C) 2023 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA.ICS 
 *    
 *    Copyright (C) 2023 STÜBER SYSTEMS GmbH
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
    /// Represents an iCalendar To-Do Component
    /// </summary>
    public class IcsTodo : IcsComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTodo"/> class.
        /// </summary>
        public IcsTodo()
            : base(IcsComponentNames.Todo)
        {
            AlarmList = new List<IcsAlarm>();
            AttachmentList = new List<IcsAttachment>();
            AttendeeList = new List<IcsTodoAttendee>();
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
        public IList<IcsTodoAttendee> AttendeeList { get; set; }

        /// <summary>
        /// A list of catagories
        /// </summary>
        public IList<IcsCategories> CategoriesList { get; set; }

        /// <summary>
        /// A list of comments
        /// </summary>
        public IList<IcsComment> CommentList { get; set; }

        /// <summary>
        /// Defines the date and time that a to-do was actually completed.
        /// </summary>
        public IcsCompleted Completed { get; set; }

        /// <summary>
        /// A list of contacts
        /// </summary>
        public IList<IcsContact> ContactList { get; set; }

        /// <summary>
        /// Specifies the date and time that the to-do was created.
        /// </summary>
        public IcsCreated Created { get; set; }

        /// <summary>
        /// Specifies the date and time that the information associated with the to-do was 
        /// last revised.
        /// </summary>
        public IcsDateTimeStamp DateTimeStamp { get; set; }

        /// <summary>
        /// Provides a more complete description of the to-do than that provided by the 
        /// <see cref="Summary"/> property.
        /// </summary>
        public IcsDescription Description { get; set; }

        /// <summary>
        /// Specifies the date and time that the to-do ends.
        /// </summary>
        public IcsDue Due { get; set; }

        /// <summary>
        /// Specifies a positive duration of time. It may be used to specify a duration of the event, 
        /// instead of an explicit <see cref="End"/> value.
        /// </summary>
        public IcsDuration Duration { get; set; }

        /// <summary>
        /// A list of DATE-TIME exceptions for recurring to-dos.
        /// </summary>
        public IList<IcsExceptionDateTimes> ExceptionDateTimesList { get; set; }

        /// <summary>
        /// Specifies information related to the global position for the activity specified 
        /// by the to-do.
        /// </summary>
        public IcsGeo Geo { get; set; }

        /// <summary>
        /// Specifies the date and time that the information associated with the to-do was last revised.
        /// </summary>
        public IcsLastModified LastModified { get; set; }

        /// <summary>
        /// Defines the organizer for the to-do.
        /// </summary>
        public IcsOrganizer Organizer { get; set; }

        /// <summary>
        /// Is used by an assignee or delegatee of a to-do to convey the percent completion of a to-do to the
        /// "Organizer".
        /// </summary>
        public IcsPercentComplete PercentComplete { get; set; }

        /// <summary>
        /// Defines the relative priority for the to-do. Must be in the range [0..9].
        /// </summary>
        public IcsPriority Priority { get; set; }

        /// <summary>
        /// A list of DATE-TIME values for recurring to-dos.
        /// </summary>
        public IList<IcsRecurrenceDateTimes> RecurrenceDateTimesList { get; set; }

        /// <summary>
        /// Is used in conjunction with the <see cref="Uid"/> and <see cref="Sequence"/> properties to identify a 
        /// specific instance of an to-do.
        /// </summary>
        public IcsRecurrenceId RecurrenceId { get; set; }

        /// <summary>
        /// A list of recurrence rules.
        /// </summary>
        public IList<IcsRecurrenceRule> RecurrenceRuleList { get; set; }

        /// <summary>
        /// List of relationships or references between this to-do and other calendar components.
        /// </summary>
        public IList<IcsRelatedTo> RelatedToList { get; set; }

        /// <summary>
        /// List of status codes returned for a scheduling request.
        /// </summary>
        public IList<IcsRequestStatus> RequestStatusList { get; set; }

        /// <summary>
        /// List of Uniform Resource Locators (URL) associated with the to-do.
        /// </summary>
        public IList<IcsResources> ResourcesList { get; set; }

        /// <summary>
        /// Defines the revision sequence number of the to-do within a sequence of revisions.
        /// </summary>
        public IcsSequence Sequence { get; set; }

        /// <summary>
        /// Specifies when the to-do begins.
        /// </summary>
        public IcsDateTimeStart Start { get; set; }

        /// <summary>
        /// Defines the overall status or confirmation for the to-do.
        /// </summary>
        public IcsTodoStatus Status { get; set; }

        /// <summary>
        /// Defines a short summary or subject for the to-do.
        /// </summary>
        public IcsSummary Summary { get; set; }

        /// <summary>
        /// Persistent, globally unique identifier for the to-do.
        /// </summary>
        public IcsUid Uid { get; set; }

        /// <summary>
        /// Defines a Uniform Resource Locator (URL) associated with the to-do.
        /// </summary>
        public IcsUrl Url { get; set; }

        /// <summary>
        /// Adds a new alarm sub component to the to-do
        /// </summary>
        /// <returns>Gives back the newly created alarm sub component</returns>
        public IcsAlarm AddAlarm()
        {
            var o = new IcsAlarm();
            AlarmList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new attachment property to the to-do
        /// </summary>
        /// <returns>Gives back the newly created attachment property</returns>
        public IcsAttachment AddAttachment()
        {
            var o = new IcsAttachment();
            AttachmentList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new attachment property to the to-do
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
        /// Adds a new attachment property to the to-do
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
        /// Adds a new attendee property to the to-do
        /// </summary>
        /// <returns>Gives back the newly created attendee property</returns>
        public IcsTodoAttendee AddAttendee()
        {
            var o = new IcsTodoAttendee();
            AttendeeList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new attendee property to the to-do
        /// </summary>
        /// <param name="value">A string value</param>
        /// <returns>Gives back the newly created attendee property</returns>
        public IcsTodoAttendee AddAttendee(string value)
        {
            var o = new IcsTodoAttendee(value);
            AttendeeList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new custom property to the to-do
        /// </summary>
        /// <returns>Gives back the newly created custom property</returns>
        public IcsCategories AddCategories()
        {
            var o = new IcsCategories();
            CategoriesList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new categories property to the to-do
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
        /// Adds a new comment property to the to-do
        /// </summary>
        /// <returns>Gives back the newly created comment property</returns>
        public IcsComment AddComment()
        {
            var o = new IcsComment();
            CommentList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new comment property to the to-do
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
        /// Adds a new custom property to the to-do
        /// </summary>
        /// <returns>Gives back the newly created custom property</returns>
        public IcsContact AddContact()
        {
            var o = new IcsContact();
            ContactList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new contact property to the to-do
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
        /// Adds a new custom property to the to-do
        /// </summary>
        /// <returns>Gives back the newly created custom property</returns>
        public IcsExceptionDateTimes AddExceptionDateTimes()
        {
            var o = new IcsExceptionDateTimes();
            ExceptionDateTimesList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new exception date-times property to the to-do
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
        /// Adds a new exception date-times property to the to-do
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
        /// Adds a new custom property to the to-do
        /// </summary>
        /// <returns>Gives back the newly created custom property</returns>
        public IcsRecurrenceDateTimes AddRecurrenceDateTimes()
        {
            var o = new IcsRecurrenceDateTimes();
            RecurrenceDateTimesList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new recurrence date-times property to the to-do
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
        /// Adds a new recurrence date-times property to the to-do
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
        /// Adds a new recurrence date-times property to the to-do
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
        /// Adds a new custom property to the to-do
        /// </summary>
        /// <returns>Gives back the newly created custom property</returns>
        public IcsRecurrenceRule AddRecurrenceRule()
        {
            var o = new IcsRecurrenceRule();
            RecurrenceRuleList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new recurrence rule property to the to-do
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
        /// Adds a new custom property to the to-do
        /// </summary>
        /// <returns>Gives back the newly created custom property</returns>
        public IcsRelatedTo AddRelatedTo()
        {
            var o = new IcsRelatedTo();
            RelatedToList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new related to property to the to-do
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
        /// Adds a new custom property to the to-do
        /// </summary>
        /// <returns>Gives back the newly created custom property</returns>
        public IcsRequestStatus AddRequestStatus()
        {
            var o = new IcsRequestStatus();
            RequestStatusList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new request status property to the to-do
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
        /// Adds a new resources property to the to-do
        /// </summary>
        /// <returns>Gives back the newly created resources property</returns>
        public IcsResources AddResources()
        {
            var o = new IcsResources();
            ResourcesList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new resources property to the to-do
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
            textWriter.Write(IcsCoreNames.Begin, Name);

            textWriter.WriteComponentList(AlarmList);
            textWriter.WritePropertyList(AttachmentList);
            textWriter.WritePropertyList(AttendeeList);
            textWriter.WritePropertyList(CategoriesList);
            textWriter.WritePropertyList(CommentList);
            textWriter.WriteProperty(Completed);
            textWriter.WritePropertyList(ContactList);
            textWriter.WriteProperty(Created);
            textWriter.WriteProperty(DateTimeStamp);
            textWriter.WriteProperty(Description);
            textWriter.WriteProperty(Due);
            textWriter.WriteProperty(Duration);
            textWriter.WritePropertyList(ExceptionDateTimesList);
            textWriter.WriteProperty(Geo);
            textWriter.WriteProperty(LastModified);
            textWriter.WriteProperty(Organizer);
            textWriter.WriteProperty(PercentComplete);
            textWriter.WriteProperty(Priority);
            textWriter.WritePropertyList(RecurrenceDateTimesList);
            textWriter.WriteProperty(RecurrenceId);
            textWriter.WritePropertyList(RecurrenceRuleList);
            textWriter.WritePropertyList(RelatedToList);
            textWriter.WritePropertyList(RequestStatusList);
            textWriter.WritePropertyList(ResourcesList);
            textWriter.WriteProperty(Sequence);
            textWriter.WriteProperty(Start);
            textWriter.WriteProperty(Status);
            textWriter.WriteProperty(Summary);
            textWriter.WriteProperty(Uid);
            textWriter.WriteProperty(Url);

            base.WriteContent(textWriter);

            textWriter.Write(IcsCoreNames.End, Name);
        }

        /// <summary>
        /// Serializes the complete component to a stream
        /// </summary>
        /// <param name="textWriter">Text writer</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public override async Task WriteContentAsync(TextWriter textWriter)
        {
            await textWriter.WriteContentAsync(IcsCoreNames.Begin, Name);

            await textWriter.WriteComponentListAsync(AlarmList);
            await textWriter.WritePropertyListAsync(AttachmentList);
            await textWriter.WritePropertyListAsync(AttendeeList);
            await textWriter.WritePropertyListAsync(CategoriesList);
            await textWriter.WritePropertyListAsync(CommentList);
            await textWriter.WritePropertyAsync(Completed);
            await textWriter.WritePropertyListAsync(ContactList);
            await textWriter.WritePropertyAsync(Created);
            await textWriter.WritePropertyAsync(DateTimeStamp);
            await textWriter.WritePropertyAsync(Description);
            await textWriter.WritePropertyAsync(Due);
            await textWriter.WritePropertyAsync(Duration);
            await textWriter.WritePropertyListAsync(ExceptionDateTimesList);
            await textWriter.WritePropertyAsync(Geo);
            await textWriter.WritePropertyAsync(LastModified);
            await textWriter.WritePropertyAsync(Organizer);
            await textWriter.WritePropertyAsync(PercentComplete);
            await textWriter.WritePropertyAsync(Priority);
            await textWriter.WritePropertyListAsync(RecurrenceDateTimesList);
            await textWriter.WritePropertyAsync(RecurrenceId);
            await textWriter.WritePropertyListAsync(RecurrenceRuleList);
            await textWriter.WritePropertyListAsync(RelatedToList);
            await textWriter.WritePropertyListAsync(RequestStatusList);
            await textWriter.WritePropertyListAsync(ResourcesList);
            await textWriter.WritePropertyAsync(Sequence);
            await textWriter.WritePropertyAsync(Start);
            await textWriter.WritePropertyAsync(Status);
            await textWriter.WritePropertyAsync(Summary);
            await textWriter.WritePropertyAsync(Uid);
            await textWriter.WritePropertyAsync(Url);

            await base.WriteContentAsync(textWriter);

            await textWriter.WriteContentAsync(IcsCoreNames.End, Name);
        }
    }
}
