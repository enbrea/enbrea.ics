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

namespace Enbrea.Ics
{
    internal class IcsEventBuilder : IcsComponentBuilder
    {
        private readonly IList<IcsEvent> _eventList;
        private IcsComponentBuilder _currentSubBuilder = null;
        private IcsEvent _event;

        public IcsEventBuilder(IList<IcsEvent> eventList)
        {
            _eventList = eventList;
            _event = new IcsEvent();
        }

        public override void Consume(IcsContentLine contentLine)
        {
            if (_currentSubBuilder is IcsAlarmBuilder)
            {
                if (contentLine.Name == IcsCoreNames.End)
                {
                    if (contentLine.Value == IcsComponentNames.Alarm)
                    {
                        _currentSubBuilder.Consume(contentLine);
                        _currentSubBuilder = null;
                    }
                    else
                    {
                        throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.Alarm, contentLine);
                    }
                }
                else
                {
                    _currentSubBuilder.Consume(contentLine);
                }
            }
            else
            {
                if (contentLine.Name == IcsCoreNames.End)
                {
                    if (contentLine.Value == IcsComponentNames.Event)
                    {
                        _eventList.Add(_event);
                        _event = null;
                    }
                    else
                    {
                        throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.Event, contentLine);
                    }
                }
                else if (contentLine.Name == IcsCoreNames.Begin)
                {
                    if (contentLine.Value == IcsComponentNames.Alarm)
                    {
                        if (_currentSubBuilder == null)
                        {
                            _currentSubBuilder = new IcsAlarmBuilder(_event.AlarmList);
                        }
                        else
                        {
                            throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.Event, contentLine);
                        }
                    }
                }
                else
                {
                    ConsumeProperty(contentLine);
                }
            }
        }
        
        private void ConsumeProperty(IcsContentLine contentLine)
        {
            switch (contentLine.Name)
            {
                case IcsPropertyNames.Attachment:
                    _event.AttachmentList.Add(new IcsAttachment(contentLine));
                    break;
                case IcsPropertyNames.Attendee:
                    _event.AttendeeList.Add(new IcsEventAttendee(contentLine));
                    break;
                case IcsPropertyNames.Categories:
                    _event.CategoriesList.Add(new IcsCategories(contentLine));
                    break;
                case IcsPropertyNames.Classification:
                    _event.Classification = new IcsClassification(contentLine);
                    break;
                case IcsPropertyNames.Comment:
                    _event.CommentList.Add(new IcsComment(contentLine));
                    break;
                case IcsPropertyNames.Contact:
                    _event.ContactList.Add(new IcsContact(contentLine));
                    break;
                case IcsPropertyNames.Created:
                    _event.Created = new IcsCreated(contentLine);
                    break;
                case IcsPropertyNames.DateTimeStamp:
                    _event.DateTimeStamp = new IcsDateTimeStamp(contentLine);
                    break;
                case IcsPropertyNames.Description:
                    _event.Description = new IcsDescription(contentLine);
                    break;
                case IcsPropertyNames.Duration:
                    _event.Duration = new IcsDuration(contentLine);
                    break;
                case IcsPropertyNames.DateTimeEnd:
                    _event.End = new IcsDateTimeEnd(contentLine);
                    break;
                case IcsPropertyNames.ExceptionDateTimes:
                    _event.ExceptionDateTimesList.Add(new IcsExceptionDateTimes(contentLine));
                    break;
                case IcsPropertyNames.Geo:
                    _event.Geo = new IcsGeo(contentLine);
                    break;
                case IcsPropertyNames.LastModified:
                    _event.LastModified = new IcsLastModified(contentLine);
                    break;
                case IcsPropertyNames.Location:
                    _event.Location = new IcsLocation(contentLine);
                    break;
                case IcsPropertyNames.Organizer:
                    _event.Organizer = new IcsOrganizer(contentLine);
                    break;
                case IcsPropertyNames.Priority:
                    _event.Priority = new IcsPriority(contentLine);
                    break;
                case IcsPropertyNames.RecurrenceDateTimes:
                    _event.RecurrenceDateTimesList.Add(new IcsRecurrenceDateTimes(contentLine));
                    break;
                case IcsPropertyNames.RecurrenceId:
                    _event.RecurrenceId = new IcsRecurrenceId(contentLine);
                    break;
                case IcsPropertyNames.RecurrenceRule:
                    _event.RecurrenceRuleList.Add(new IcsRecurrenceRule(contentLine));
                    break;
                case IcsPropertyNames.RelatedTo:
                    _event.RelatedToList.Add(new IcsRelatedTo(contentLine));
                    break;
                case IcsPropertyNames.RequestStatus:
                    _event.RequestStatusList.Add(new IcsRequestStatus(contentLine));
                    break;
                case IcsPropertyNames.Resources:
                    _event.ResourcesList.Add(new IcsResources(contentLine));
                    break;
                case IcsPropertyNames.Sequence:
                    _event.Sequence = new IcsSequence(contentLine);
                    break;
                case IcsPropertyNames.DateTimeStart:
                    _event.Start = new IcsDateTimeStart(contentLine);
                    break;
                case IcsPropertyNames.Status:
                    _event.Status = new IcsEventStatus(contentLine);
                    break;
                case IcsPropertyNames.Summary:
                    _event.Summary = new IcsSummary(contentLine);
                    break;
                case IcsPropertyNames.Transparency:
                    _event.Transparency = new IcsTransparency(contentLine);
                    break;
                case IcsPropertyNames.Uid:
                    _event.Uid = new IcsUid(contentLine);
                    break;
                case IcsPropertyNames.Url:
                    _event.Url = new IcsUrl(contentLine);
                    break;
                default:
                    _event.CustomProperties.Add(contentLine);
                    break;
            }
        }
    }
}
