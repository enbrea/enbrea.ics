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
    /// Represents possible values for an iCalendar event status or confirmation.
    /// </summary>
    public enum IcsEventStatusValue
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates event is tentative.
        /// </summary>
        Tentative,

        /// <summary>
        /// Indicates event is definite
        /// </summary>
        Confirmed,

        /// <summary>
        /// Indicates event was cancelled
        /// </summary>
        Cancelled
    }
}