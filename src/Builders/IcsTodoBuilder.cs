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

namespace Enbrea.Ics
{
    internal class IcsTodoBuilder : IcsComponentBuilder
    {
        private IcsComponentBuilder _currentSubBuilder = null;
        private readonly IList<IcsTodo> _todoList;
        private IcsTodo _todo;

        public IcsTodoBuilder(IList<IcsTodo> todoList)
        {
            _todoList = todoList;
            _todo = new IcsTodo();
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
                    if (contentLine.Value == IcsComponentNames.Todo)
                    {
                        _todoList.Add(_todo);
                        _todo = null;
                    }
                    else
                    {
                        throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.Todo, contentLine);
                    }
                }
                if (contentLine.Name == IcsCoreNames.Begin)
                {
                    if (contentLine.Name == IcsComponentNames.Alarm)
                    {
                        if (_currentSubBuilder == null)
                        {
                            _currentSubBuilder = new IcsAlarmBuilder(_todo.AlarmList);
                        }
                        else
                        {
                            throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.Todo, contentLine);
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
                    _todo.AttachmentList.Add(new IcsAttachment(contentLine));
                    break;
                case IcsPropertyNames.Attendee:
                    _todo.AttendeeList.Add(new IcsTodoAttendee(contentLine));
                    break;
                case IcsPropertyNames.Categories:
                    _todo.CategoriesList.Add(new IcsCategories(contentLine));
                    break;
                case IcsPropertyNames.Comment:
                    _todo.CommentList.Add(new IcsComment(contentLine));
                    break;
                case IcsPropertyNames.Completed:
                    _todo.Completed = new IcsCompleted(contentLine);
                    break;
                case IcsPropertyNames.Contact:
                    _todo.ContactList.Add(new IcsContact(contentLine));
                    break;
                case IcsPropertyNames.Created:
                    _todo.Created = new IcsCreated(contentLine);
                    break;
                case IcsPropertyNames.DateTimeStamp:
                    _todo.DateTimeStamp = new IcsDateTimeStamp(contentLine);
                    break;
                case IcsPropertyNames.Description:
                    _todo.Description = new IcsDescription(contentLine);
                    break;
                case IcsPropertyNames.Due:
                    _todo.Due = new IcsDue(contentLine);
                    break;
                case IcsPropertyNames.Duration:
                    _todo.Duration = new IcsDuration(contentLine);
                    break;
                case IcsPropertyNames.ExceptionDateTimes:
                    _todo.ExceptionDateTimesList.Add(new IcsExceptionDateTimes(contentLine));
                    break;
                case IcsPropertyNames.Geo:
                    _todo.Geo = new IcsGeo(contentLine);
                    break;
                case IcsPropertyNames.LastModified:
                    _todo.LastModified = new IcsLastModified(contentLine);
                    break;
                case IcsPropertyNames.Organizer:
                    _todo.Organizer = new IcsOrganizer(contentLine);
                    break;
                case IcsPropertyNames.PercentComplete:
                    _todo.PercentComplete = new IcsPercentComplete(contentLine);
                    break;
                case IcsPropertyNames.Priority:
                    _todo.Priority = new IcsPriority(contentLine);
                    break;
                case IcsPropertyNames.RecurrenceDateTimes:
                    _todo.RecurrenceDateTimesList.Add(new IcsRecurrenceDateTimes(contentLine));
                    break;
                case IcsPropertyNames.RecurrenceId:
                    _todo.RecurrenceId = new IcsRecurrenceId(contentLine);
                    break;
                case IcsPropertyNames.RecurrenceRule:
                    _todo.RecurrenceRuleList.Add(new IcsRecurrenceRule(contentLine));
                    break;
                case IcsPropertyNames.RelatedTo:
                    _todo.RelatedToList.Add(new IcsRelatedTo(contentLine));
                    break;
                case IcsPropertyNames.RequestStatus:
                    _todo.RequestStatusList.Add(new IcsRequestStatus(contentLine));
                    break;
                case IcsPropertyNames.Resources:
                    _todo.ResourcesList.Add(new IcsResources(contentLine));
                    break;
                case IcsPropertyNames.Sequence:
                    _todo.Sequence = new IcsSequence(contentLine);
                    break;
                case IcsPropertyNames.DateTimeStart:
                    _todo.Start = new IcsDateTimeStart(contentLine);
                    break;
                case IcsPropertyNames.Status:
                    _todo.Status = new IcsTodoStatus(contentLine);
                    break;
                case IcsPropertyNames.Summary:
                    _todo.Summary = new IcsSummary(contentLine);
                    break;
                case IcsPropertyNames.Uid:
                    _todo.Uid = new IcsUid(contentLine);
                    break;
                case IcsPropertyNames.Url:
                    _todo.Url = new IcsUrl(contentLine);
                    break;
                default:
                    _todo.CustomProperties.Add(contentLine);
                    break;
            }
        }
    }
}
