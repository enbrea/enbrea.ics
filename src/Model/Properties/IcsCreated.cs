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
    /// Represents an iCalendar DATE-TIME Created property
    /// </summary>
    public class IcsCreated : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsCreated"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsCreated(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsCreated"/> class.
        /// </summary>
        public IcsCreated()
            : base(IcsPropertyNames.Created)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsCreated"/> class.
        /// </summary>
        /// <param name="value">A date-time value</param>
        public IcsCreated(DateTime value)
            : base(IcsPropertyNames.Created)
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
