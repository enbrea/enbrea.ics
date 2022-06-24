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
    /// Represents possible values for an iCalendar event participation status.
    /// </summary>
    public enum IcsEventParticipationStatus
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown,

        /// <summary>
        /// Event needs action
        /// </summary>
        NeedsAction,

        /// <summary>
        /// Event accepted
        /// </summary>
        Accepted,

        /// <summary>
        /// Event tentatively accepted
        /// </summary>
        Tentative,

        /// <summary>
        /// Event delegated
        /// </summary>
        Delegated
    }
}
