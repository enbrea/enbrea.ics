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
    /// Represents possible values for an iCalendar to-do status or confirmation.
    /// </summary>
    public enum IcsTodoStatusValue
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates to-do needs action.
        /// </summary>
        NeedsAction,

        /// <summary>
        /// Indicates to-do completed
        /// </summary>
        Completed,

        /// <summary>
        /// Indicates to-do in process of.
        /// </summary>
        InProcess,

        /// <summary>
        /// Indicates to-do was cancelled.
        /// </summary>
        Cancelled
    }
}