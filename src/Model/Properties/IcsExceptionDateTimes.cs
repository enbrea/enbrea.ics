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

using System;

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalendar Exception Date-Times property
    /// </summary>
    public class IcsExceptionDateTimes : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsExceptionDateTimes"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsExceptionDateTimes(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsExceptionDateTimes"/> class.
        /// </summary>
        public IcsExceptionDateTimes()
            : base(IcsPropertyNames.ExceptionDateTimes)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsExceptionDateTimes"/> class.
        /// </summary>
        /// <param name="value">An array of date values</param>
        public IcsExceptionDateTimes(DateOnly[] values)
            : base(IcsPropertyNames.ExceptionDateTimes)
        {
            ValuesAsDate = values;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsExceptionDateTimes"/> class.
        /// </summary>
        /// <param name="value">An array of date-time values</param>
        public IcsExceptionDateTimes(DateTime[] values)
            : base(IcsPropertyNames.ExceptionDateTimes)
        {
            ValuesAsDateTime = values;
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
        /// List of date values
        /// </summary>
        public DateOnly[] ValuesAsDate
        {
            get 
            { 
                return IcsConverter.ToDateOnlyArrayOrDefault(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromDateOnlyArray(value);
                ContentLine.SetParameter(IcsParameterNames.Value, "DATE");
            }
        }

        /// <summary>
        /// List of date-time values
        /// </summary>
        public DateTime[] ValuesAsDateTime
        {
            get 
            { 
                return IcsConverter.ToDateTimeArrayOrDefault(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromDateTimeArray(value);
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
        /// Is type of values date?
        /// </summary>
        /// <returns>TRUE, if type of values is date</returns>
        public bool IsDate()
        {
            return ContentLine.GetParameter(IcsParameterNames.Value) == "DATE";
        }

        /// <summary>
        /// Is type of values date-time?
        /// </summary>
        /// <returns>TRUE, if type of values is date-time</returns>
        public bool IsDateTime()
        {
            return !IsDate();
        }
    }
}
