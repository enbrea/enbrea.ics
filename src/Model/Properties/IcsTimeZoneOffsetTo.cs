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

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalendar Time Zone Offset To property
    /// </summary>
    public class IcsTimeZoneOffsetTo : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZoneOffsetTo"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsTimeZoneOffsetTo(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZoneOffsetTo"/> class.
        /// </summary>
        public IcsTimeZoneOffsetTo()
            : base(IcsPropertyNames.TimeZoneOffsetTo)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZoneOffsetTo"/> class.
        /// </summary>
        /// <param name="value">An utc offset value</param>
        public IcsTimeZoneOffsetTo(IcsUtcOffset value)
            : base(IcsPropertyNames.TimeZoneOffsetTo)
        {
            Value = value;
        }

        /// <summary>
        /// The utc offset value
        /// </summary>
        public IcsUtcOffset? Value
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
