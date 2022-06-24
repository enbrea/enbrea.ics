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

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalendar Date-Time Stamp property
    /// </summary>
    public class IcsDateTimeStamp : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsDateTimeStamp"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsDateTimeStamp(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsDateTimeStamp"/> class.
        /// </summary>
        public IcsDateTimeStamp()
            : base(IcsPropertyNames.DateTimeStamp)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsDateTimeStamp"/> class.
        /// </summary>
        /// <param name="value">A date-time value</param>
        public IcsDateTimeStamp(DateTime value)
            : base(IcsPropertyNames.DateTimeStamp)
        {
            Value = value;
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
        /// The date-time value
        /// </summary>
        public DateTime? Value
        {
            get
            {
                return IcsConverter.ToDateTimeOrDefault(ContentLine.Value);
            }
            set
            {
                ContentLine.Value = IcsConverter.FromDateTime(value);
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
    }
}
