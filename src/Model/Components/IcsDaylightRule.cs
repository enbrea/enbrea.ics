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
    /// Represents an iCalendar Daylight Time Zone Sub Component
    /// </summary>
    public class IcsDaylightRule : IcsTimeZoneRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsDaylightRule"/> class.
        /// </summary>
        public IcsDaylightRule()
            : base(IcsComponentNames.Daylight)
        {
        }
    }
}
