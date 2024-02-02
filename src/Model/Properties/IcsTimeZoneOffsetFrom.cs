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
    /// <summary>
    /// Represents an iCalendar Time Zone Offset From property
    /// </summary>
    public class IcsTimeZoneOffsetFrom : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZoneOffsetFrom"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsTimeZoneOffsetFrom(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZoneOffsetFrom"/> class.
        /// </summary>
        public IcsTimeZoneOffsetFrom()
            : base(IcsPropertyNames.TimeZoneOffsetFrom)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZoneOffsetFrom"/> class.
        /// </summary>
        /// <param name="value">An utc offset value</param>
        public IcsTimeZoneOffsetFrom(IcsUtcOffset value)
            : base(IcsPropertyNames.TimeZoneOffsetFrom)
        {
            Value = value;
        }

        /// <summary>
        /// The utc offset value
        /// </summary>
        public IcsUtcOffset Value
        {
            get 
            { 
                return IcsConverter.ToUtcOffset(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromUtcOffset(value); 
            }
        }
    }
}
