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

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalendar Time Zone Identifier property
    /// </summary>
    public class IcsTimeZoneId : IcsString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZoneId"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsTimeZoneId(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZoneId"/> class.
        /// </summary>
        public IcsTimeZoneId()
            : base(IcsPropertyNames.TimeZoneId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZoneId"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsTimeZoneId(string value)
            : base(IcsPropertyNames.TimeZoneId, value)
        {
        }
    }
}
