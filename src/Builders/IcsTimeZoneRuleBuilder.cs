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
    internal abstract class IcsTimeZoneRuleBuilder<T> : IcsComponentBuilder where T: IcsTimeZoneRule
    {
        private readonly IList<T> _timeZoneRuleList;
        private T _timeZoneRule;
        private readonly string _componentName;

        public IcsTimeZoneRuleBuilder(string componentName, IList<T> timeZoneRuleList)
        {
            _componentName = componentName;
            _timeZoneRule = Activator.CreateInstance<T>(); 
            _timeZoneRuleList = timeZoneRuleList;
        }

        public override void Consume(IcsContentLine contentLine)
        {
            if (contentLine.Name == IcsCoreNames.End)
            {
                if (contentLine.Value == _componentName)
                {
                    _timeZoneRuleList.Add(_timeZoneRule);
                    _timeZoneRule = null;
                }
                else
                {
                    throw IcsExceptions.ThrowInvalidLine(_componentName, contentLine);
                }
            }
            else if (contentLine.Name == IcsCoreNames.Begin)
            {
                throw IcsExceptions.ThrowInvalidLine(_componentName, contentLine);
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
                case IcsPropertyNames.Comment:
                    _timeZoneRule.CommentList.Add(new IcsComment(contentLine));
                    break;
                case IcsPropertyNames.TimeZoneOffsetFrom:
                    _timeZoneRule.OffsetFrom = new IcsTimeZoneOffsetFrom(contentLine);
                    break;
                case IcsPropertyNames.TimeZoneOffsetTo:
                    _timeZoneRule.OffsetTo = new IcsTimeZoneOffsetTo(contentLine);
                    break;
                case IcsPropertyNames.RecurrenceDateTimes:
                    _timeZoneRule.RecurrenceDateTimesList.Add(new IcsRecurrenceDateTimes(contentLine));
                    break;
                case IcsPropertyNames.RecurrenceRule:
                    _timeZoneRule.RecurrenceRule = new IcsRecurrenceRule(contentLine);
                    break;
                case IcsPropertyNames.DateTimeStart:
                    _timeZoneRule.Start = new IcsDateTimeStart(contentLine);
                    break;
                case IcsPropertyNames.TimeZoneName:
                    _timeZoneRule.NameList.Add(new IcsTimeZoneName(contentLine));
                    break;
                default:
                    _timeZoneRule.CustomProperties.Add(contentLine);
                    break;
            }
        }
    }
}