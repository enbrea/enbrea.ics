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
    /// Represents possible values for an iCalendar journal participation status.
    /// </summary>
    public enum IcsJournalParticipationStatus
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown,

        /// <summary>
        /// Journal needs action
        /// </summary>
        NeedsAction,

        /// <summary>
        /// Journal accepted
        /// </summary>
        Accepted,

        /// <summary>
        /// Journal declined
        /// </summary>
        Declined
    }
}