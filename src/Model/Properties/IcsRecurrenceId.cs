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

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalendar Recurrence ID property
    /// </summary>
    public class IcsRecurrenceId : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRecurrenceId"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsRecurrenceId(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRecurrenceId"/> class.
        /// </summary>
        public IcsRecurrenceId()
            : base(IcsPropertyNames.RecurrenceId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRecurrenceId"/> class.
        /// </summary>
        /// <param name="value">A date value</param>
        public IcsRecurrenceId(DateOnly value)
            : base(IcsPropertyNames.RecurrenceId)
        {
            ValueAsDate = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRecurrenceId"/> class.
        /// </summary>
        /// <param name="value">A date-time value</param>
        public IcsRecurrenceId(DateTime value)
            : base(IcsPropertyNames.RecurrenceId)
        {
            ValueAsDateTime = value;
        }

        /// <summary>
        /// An identifier for the time zone definition
        /// </summary>
        public string TimeZoneId
        {
            get
            {
                return ContentLine.GetParameter(IcsParameterNames.TimeZoneId);
            }
            set
            {
                ContentLine.SetParameter(IcsParameterNames.TimeZoneId, value);
            }
        }

        /// <summary>
        /// A date value
        /// </summary>
        public DateOnly? ValueAsDate
        {
            get 
            { 
                return IcsConverter.ToDateOnlyOrDefault(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromDateOnly(value);
                ContentLine.SetParameter(IcsParameterNames.Value, "DATE");
            }
        }

        /// <summary>
        /// A date-time value
        /// </summary>
        public DateTime? ValueAsDateTime
        {
            get 
            { 
                return IcsConverter.ToDateTimeOrDefault(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromDateTime(value);
                ContentLine.SetParameter(IcsParameterNames.Value, "DATE-TIME");
            }
        }

        /// <summary>
        /// Has time zone parameter?
        /// </summary>
        /// <returns>TRUE, if time zone parameter exists</returns>
        public bool HasTimeZoneId()
        {
            return ContentLine.GetParameter(IcsParameterNames.TimeZoneId) != null;
        }

        /// <summary>
        /// Is value type date?
        /// </summary>
        /// <returns>TRUE, if value type is date</returns>
        public bool IsDate()
        {
            return !IsDateTime();
        }

        /// <summary>
        /// Is value type date-time?
        /// </summary>
        /// <returns>TRUE, if value type is date-time</returns>
        public bool IsDateTime()
        {
            return ContentLine.Value.Contains('T');
        }
    }
}
