#region ENBREA.ICS Copyright (C) 2023 STÜBER SYSTEMS GmbH
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
    /// Represents possible values for an iCalendar journal status or confirmation.
    /// </summary>
    public enum IcsJournalStatusValue
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates journal is draft.
        /// </summary>
        Draft,

        /// <summary>
        /// Indicates journal is final.
        /// </summary>
        Final,

        /// <summary>
        /// Indicates journal is removed.
        /// </summary>
        Cancelled
    }
}