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
    internal class IcsFreeBusyBuilder : IcsComponentBuilder
    {
        private readonly IList<IcsFreeBusy> _freeBusyList;
        private IcsFreeBusy _freeBusy;

        public IcsFreeBusyBuilder(IList<IcsFreeBusy> freeBusyList)
        {
            _freeBusy = new IcsFreeBusy();
            _freeBusyList = freeBusyList;
        }

        public override void Consume(IcsContentLine contentLine)
        {
            if (contentLine.Name == IcsCoreNames.End)
            {
                if (contentLine.Value == IcsComponentNames.FreeBusy)
                {
                    _freeBusyList.Add(_freeBusy);
                    _freeBusy = null;
                }
                else
                {
                    throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.FreeBusy, contentLine);
                }
            }
            else if (contentLine.Name == IcsCoreNames.Begin)
            {
                throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.FreeBusy, contentLine);
            }
            else
            {
                ConsumeProperty(contentLine);
            }
        }

        private void ConsumeProperty(IcsContentLine contentLine)
        {
            switch (contentLine.Name)
            {
                case IcsPropertyNames.Attendee:
                    _freeBusy.AttendeeList.Add(new IcsAttendee(contentLine));
                    break;
                case IcsPropertyNames.Comment:
                    _freeBusy.CommentList.Add(new IcsComment(contentLine));
                    break;
                case IcsPropertyNames.Contact:
                    _freeBusy.Contact = new IcsContact(contentLine);
                    break;
                case IcsPropertyNames.DateTimeStamp:
                    _freeBusy.DateTimeStamp = new IcsDateTimeStamp(contentLine);
                    break;
                case IcsPropertyNames.End:
                    _freeBusy.End = new IcsDateTimeEnd(contentLine);
                    break;
                case IcsPropertyNames.FreeBusy:
                    _freeBusy.FreeBusyTimeList.Add(new IcsFreeBusyTime(contentLine));
                    break;
                case IcsPropertyNames.Organizer:
                    _freeBusy.Organizer = new IcsOrganizer(contentLine);
                    break;
                case IcsPropertyNames.RequestStatus:
                    _freeBusy.RequestStatusList.Add(new IcsRequestStatus(contentLine));
                    break;
                case IcsPropertyNames.DateTimeStart:
                    _freeBusy.Start = new IcsDateTimeStart(contentLine);
                    break;
                case IcsPropertyNames.Uid:
                    _freeBusy.Uid = new IcsUid(contentLine);
                    break;
                case IcsPropertyNames.Url:
                    _freeBusy.Url = new IcsUrl(contentLine);
                    break;
                default:
                    _freeBusy.CustomProperties.Add(contentLine);
                    break;
            }
        }
    }
}