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

namespace Enbrea.Ics
{
    internal class IcsAlarmBuilder : IcsComponentBuilder
    {
        private readonly IList<IcsAlarm> _alarmList;
        private IcsAlarm _alarm;

        public IcsAlarmBuilder(IList<IcsAlarm> alarmList)
        {
            _alarm = new IcsAlarm();
            _alarmList = alarmList;
        }

        public override void Consume(IcsContentLine contentLine)
        {
            if (contentLine.Name == IcsCoreNames.End)
            {
                if (contentLine.Value == IcsComponentNames.Alarm)
                {
                    _alarmList.Add(_alarm);
                    _alarm = null;
                }
                else
                {
                    throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.Alarm, contentLine);
                }
            }
            else if (contentLine.Name == IcsCoreNames.Begin)
            {
                throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.Alarm, contentLine);
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
                case IcsPropertyNames.Action:
                    _alarm.Action = new IcsAction(contentLine);
                    break;
                case IcsPropertyNames.Attachment:
                    _alarm.AttachmentList.Add(new IcsAttachment(contentLine));
                    break;
                case IcsPropertyNames.Attendee:
                    _alarm.AttendeeList.Add(new IcsAttendee(contentLine));
                    break;
                case IcsPropertyNames.Description:
                    _alarm.Description = new IcsDescription(contentLine);
                    break;
                case IcsPropertyNames.Duration:
                    _alarm.Duration = new IcsDuration(contentLine);
                    break;
                case IcsPropertyNames.RepeatCount:
                    _alarm.Repeat = new IcsRepeatCount(contentLine);
                    break;
                case IcsPropertyNames.Summary:
                    _alarm.Summary = new IcsSummary(contentLine);
                    break;
                case IcsPropertyNames.Trigger:
                    _alarm.Trigger = new IcsTrigger(contentLine);
                    break;
                default:
                    _alarm.CustomProperties.Add(contentLine);
                    break;
            }
        }
    }
}