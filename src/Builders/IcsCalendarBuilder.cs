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

namespace Enbrea.Ics
{
    internal class IcsCalendarBuilder : IcsComponentBuilder
    {
        private IcsComponentBuilder _currentSubBuilder = null;

        public IcsCalendarBuilder()
        {
            Calendar = IcsCalendar.CreateWithoutDefaults();
        }

        public IcsCalendar Calendar { get; }

        public override void Consume(IcsContentLine contentLine)
        {
            if (_currentSubBuilder == null)
            {
                if (contentLine.Name == IcsCoreNames.Begin)
                {
                    if (contentLine.Value == IcsComponentNames.Event)
                    {
                        _currentSubBuilder = new IcsEventBuilder(Calendar.EventList);
                    }
                    else if (contentLine.Value == IcsComponentNames.Todo)
                    {
                        _currentSubBuilder = new IcsTodoBuilder(Calendar.TodoList);
                    }
                    else if (contentLine.Value == IcsComponentNames.Journal)
                    {
                        _currentSubBuilder = new IcsJournalBuilder(Calendar.JournalList);
                    }
                    else if (contentLine.Value == IcsComponentNames.FreeBusy)
                    {
                        _currentSubBuilder = new IcsFreeBusyBuilder(Calendar.FreeBusyList);
                    }
                    else if (contentLine.Value == IcsComponentNames.TimeZone)
                    {
                        _currentSubBuilder = new IcsTimeZoneBuilder(Calendar.TimeZoneList);
                    }
                    else
                    {
                        throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.Calendar, contentLine);
                    }
                }
                else
                {
                    ConsumeProperty(contentLine);
                }
            }
            else 
            {
                if (contentLine.Name == IcsCoreNames.End)
                {
                    if (((contentLine.Value == IcsComponentNames.Event) && (_currentSubBuilder is IcsEventBuilder)) ||
                        ((contentLine.Value == IcsComponentNames.Todo) && (_currentSubBuilder is IcsTodoBuilder)) ||
                        ((contentLine.Value == IcsComponentNames.Journal) && (_currentSubBuilder is IcsJournalBuilder)) ||
                        ((contentLine.Value == IcsComponentNames.FreeBusy) && (_currentSubBuilder is IcsFreeBusyBuilder)) ||
                        ((contentLine.Value == IcsComponentNames.TimeZone) && (_currentSubBuilder is IcsTimeZoneBuilder)))
                    {
                        _currentSubBuilder.Consume(contentLine);
                        _currentSubBuilder = null;
                    }
                    else
                    {
                        _currentSubBuilder.Consume(contentLine);
                    }
                }
                else
                {
                    _currentSubBuilder.Consume(contentLine);
                }
            }
        }

        private void ConsumeProperty(IcsContentLine contentLine)
        {
            switch (contentLine.Name)
            {
                case IcsPropertyNames.Method:
                    Calendar.Method = new IcsMethod(contentLine);
                    break;
                case IcsPropertyNames.ProductId:
                    Calendar.ProductId = new IcsProductId(contentLine);
                    break;
                case IcsPropertyNames.Scale:
                    Calendar.Scale = new IcsScale(contentLine);
                    break;
                case IcsPropertyNames.Version:
                    Calendar.Version = new IcsVersion(contentLine);
                    break;
                default:
                    Calendar.CustomProperties.Add(contentLine);
                    break;
            }
        }
    }
}
