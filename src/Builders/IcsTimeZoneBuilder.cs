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
    internal class IcsTimeZoneBuilder : IcsComponentBuilder
    {
        private readonly IList<IcsTimeZone> _timeZoneList;
        private IcsComponentBuilder _currentSubBuilder = null;
        private IcsTimeZone _timeZone;

        public IcsTimeZoneBuilder(IList<IcsTimeZone> timeZoneList)
        {
            _timeZone = new IcsTimeZone();
            _timeZoneList = timeZoneList;
        }

        public override void Consume(IcsContentLine contentLine)
        {
            if (_currentSubBuilder is IcsStandardRuleBuilder)
            {
                if (contentLine.Name == IcsCoreNames.End)
                {
                    if (contentLine.Value == IcsComponentNames.Standard)
                    {
                        _currentSubBuilder.Consume(contentLine);
                        _currentSubBuilder = null;
                    }
                    else
                    {
                        throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.Standard, contentLine);
                    }
                }
                else
                {
                    _currentSubBuilder.Consume(contentLine);
                }
            }
            else if (_currentSubBuilder is IcsDaylightRuleBuilder)
            {
                if (contentLine.Name == IcsCoreNames.End)
                {
                    if (contentLine.Value == IcsComponentNames.Daylight)
                    {
                        _currentSubBuilder.Consume(contentLine);
                        _currentSubBuilder = null;
                    }
                    else
                    {
                        throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.Daylight, contentLine);
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
                    if (contentLine.Value == IcsComponentNames.TimeZone)
                    {
                        _timeZoneList.Add(_timeZone);
                        _timeZone = null;
                    }
                    else
                    {
                        throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.TimeZone, contentLine);
                    }
                }
                else if (contentLine.Name == IcsCoreNames.Begin)
                {
                    if (contentLine.Value == IcsComponentNames.Standard)
                    {
                        if (_currentSubBuilder == null)
                        {
                            _currentSubBuilder = new IcsStandardRuleBuilder(_timeZone.StandardRuleList);
                        }
                        else
                        {
                            throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.Standard, contentLine);
                        }
                    }
                }
                else if (contentLine.Name == IcsCoreNames.Begin)
                {
                    if (contentLine.Value == IcsComponentNames.Daylight)
                    {
                        if (_currentSubBuilder == null)
                        {
                            _currentSubBuilder = new IcsDaylightRuleBuilder(_timeZone.DaylightRuleList);
                        }
                        else
                        {
                            throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.Daylight, contentLine);
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
                case IcsPropertyNames.TimeZoneId:
                    _timeZone.Id = new IcsTimeZoneId(contentLine);
                    break;
                case IcsPropertyNames.TimeZoneUrl:
                    _timeZone.Url = new IcsTimeZoneUrl(contentLine);
                    break;
                case IcsPropertyNames.LastModified:
                    _timeZone.LastModified = new IcsLastModified(contentLine);
                    break;
                default:
                    _timeZone.CustomProperties.Add(contentLine);
                    break;
            }
        }
    }
}