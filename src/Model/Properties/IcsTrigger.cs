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
    /// Represents an iCalendar Trigger property
    /// </summary>
    public class IcsTrigger : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTrigger"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsTrigger(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTrigger"/> class.
        /// </summary>
        public IcsTrigger()
            : base(IcsPropertyNames.Trigger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTrigger"/> class.
        /// </summary>
        /// <param name="value">A date-time value</param>
        public IcsTrigger(DateTime value)
            : base(IcsPropertyNames.Trigger)
        {
            ValueAsDateTime = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTrigger"/> class.
        /// </summary>
        /// <param name="value">A time span value</param>
        public IcsTrigger(TimeSpan value)
            : base(IcsPropertyNames.Trigger)
        {
            ValueAsTimeSpan = value;
        }

        /// <summary>
        /// Specify the relationship of the alarm trigger
        /// </summary>
        public IcsTriggerRelationship? Relationship
        {
            get
            {
                return IcsConverter.ToRelationshipValue(ContentLine.GetParameter(IcsParameterNames.Relationship));
            }
            set
            {
                ContentLine.SetParameter(IcsParameterNames.Relationship, IcsConverter.FromRelationshipValue(value));
            }
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
        /// A duration value
        /// </summary>
        public TimeSpan? ValueAsTimeSpan
        {
            get 
            { 
                return IcsConverter.ToTimeSpanOrDefault(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromTimeSpan(value);
                ContentLine.SetParameter(IcsParameterNames.Value, "DURATION");
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
        /// Is value type date-time?
        /// </summary>
        /// <returns>TRUE, if value type is date-time</returns>
        public bool IsDateTime()
        {
            return ContentLine.GetParameter(IcsParameterNames.Value) == "DATE-TIME";
        }

        /// <summary>
        /// Is value type duration?
        /// </summary>
        /// <returns>TRUE, if value type is duration</returns>
        public bool IsTimeSpan()
        {
            return ContentLine.GetParameter(IcsParameterNames.Value) == "DURATION";
        }
    }
}
