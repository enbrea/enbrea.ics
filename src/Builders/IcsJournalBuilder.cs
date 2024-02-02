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
    internal class IcsJournalBuilder : IcsComponentBuilder
    {
        private IcsComponentBuilder _currentSubBuilder = null;
        private readonly IList<IcsJournal> _journalList;
        private IcsJournal _journal;

        public IcsJournalBuilder(IList<IcsJournal> journalList)
        {
            _journalList = journalList;
            _journal = new IcsJournal();
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
                    if (contentLine.Value == IcsComponentNames.Journal)
                    {
                        _journalList.Add(_journal);
                        _journal = null;
                    }
                    else
                    {
                        throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.Journal, contentLine);
                    }
                }
                if (contentLine.Name == IcsCoreNames.Begin)
                {
                    if (contentLine.Value == IcsComponentNames.Alarm)
                    {
                        if (_currentSubBuilder == null)
                        {
                            _currentSubBuilder = new IcsAlarmBuilder(_journal.AlarmList);
                        }
                        else
                        {
                            throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.Journal, contentLine);
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
                    _journal.AttachmentList.Add(new IcsAttachment(contentLine));
                    break;
                case IcsPropertyNames.Attendee:
                    _journal.AttendeeList.Add(new IcsJournalAttendee(contentLine));
                    break;
                case IcsPropertyNames.Categories:
                    _journal.CategoriesList.Add(new IcsCategories(contentLine));
                    break;
                case IcsPropertyNames.Comment:
                    _journal.CommentList.Add(new IcsComment(contentLine));
                    break;
                case IcsPropertyNames.Contact:
                    _journal.ContactList.Add(new IcsContact(contentLine));
                    break;
                case IcsPropertyNames.Created:
                    _journal.Created = new IcsCreated(contentLine);
                    break;
                case IcsPropertyNames.DateTimeStamp:
                    _journal.DateTimeStamp = new IcsDateTimeStamp(contentLine);
                    break;
                case IcsPropertyNames.Description:
                    _journal.Description = new IcsDescription(contentLine);
                    break;
                case IcsPropertyNames.ExceptionDateTimes:
                    _journal.ExceptionDateTimesList.Add(new IcsExceptionDateTimes(contentLine));
                    break;
                case IcsPropertyNames.LastModified:
                    _journal.LastModified = new IcsLastModified(contentLine);
                    break;
                case IcsPropertyNames.Organizer:
                    _journal.Organizer = new IcsOrganizer(contentLine);
                    break;
                case IcsPropertyNames.RecurrenceDateTimes:
                    _journal.RecurrenceDateTimesList.Add(new IcsRecurrenceDateTimes(contentLine));
                    break;
                case IcsPropertyNames.RecurrenceId:
                    _journal.RecurrenceId = new IcsRecurrenceId(contentLine);
                    break;
                case IcsPropertyNames.RecurrenceRule:
                    _journal.RecurrenceRuleList.Add(new IcsRecurrenceRule(contentLine));
                    break;
                case IcsPropertyNames.RelatedTo:
                    _journal.RelatedToList.Add(new IcsRelatedTo(contentLine));
                    break;
                case IcsPropertyNames.RequestStatus:
                    _journal.RequestStatusList.Add(new IcsRequestStatus(contentLine));
                    break;
                case IcsPropertyNames.Sequence:
                    _journal.Sequence = new IcsSequence(contentLine);
                    break;
                case IcsPropertyNames.DateTimeStart:
                    _journal.Start = new IcsDateTimeStart(contentLine);
                    break;
                case IcsPropertyNames.Status:
                    _journal.Status = new IcsJournalStatus(contentLine);
                    break;
                case IcsPropertyNames.Summary:
                    _journal.Summary = new IcsSummary(contentLine);
                    break;
                case IcsPropertyNames.Uid:
                    _journal.Uid = new IcsUid(contentLine);
                    break;
                case IcsPropertyNames.Url:
                    _journal.Url = new IcsUrl(contentLine);
                    break;
                default:
                    _journal.CustomProperties.Add(contentLine);
                    break;
            }
        }
    }
}
