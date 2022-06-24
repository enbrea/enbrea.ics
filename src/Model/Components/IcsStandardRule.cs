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
    /// Represents an iCalendar Daylight Time Zone Rule Component
    /// </summary>
    public class IcsStandardRule : IcsTimeZoneRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsStandardRule"/> class.
        /// </summary>
        public IcsStandardRule()
            : base(IcsComponentNames.Standard)
        {
        }
    }
}
