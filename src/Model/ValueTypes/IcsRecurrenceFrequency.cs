#region ENBREA.ICS Copyright (C) 2022 STÜBER SYSTEMS GmbH
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
    /// The type of recurrence rule
    /// </summary>
    public enum IcsRecurrenceFrequency
    {
        /// <summary>
        /// Specifies repeating events based on an interval of a second or more.
        /// </summary>
        Secondly,

        /// <summary>
        /// Specifies repeating events based on an interval of a minute or more.
        /// </summary>
        Minutely,

        /// <summary>
        /// Specifies repeating events based on an interval of an hour or more.
        /// </summary>
        Hourly,

        /// <summary>
        /// Specifies repeating events based on an interval of a day or more.
        /// </summary>
        Daily,

        /// <summary>
        /// Specifies repeating events based on an interval of a week or more.
        /// </summary>
        Weekly,

        /// <summary>
        /// Specifies repeating events based on an interval of a month or more.
        /// </summary>
        Monthly,

        /// <summary>
        /// Specifies repeating events based on an interval of a year or more.
        /// </summary>
        Yearly
    }
}