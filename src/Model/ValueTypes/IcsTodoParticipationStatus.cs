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
    /// Represents possible values for an iCalendar to-do participation status.
    /// </summary>
    public enum IcsTodoParticipationStatus
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown,

        /// <summary>
        /// To-do needs action
        /// </summary>
        NeedsAction,

        /// <summary>
        /// To-do accepted
        /// </summary>
        Accepted,

        /// <summary>
        /// To-do declined
        /// </summary>
        Declined,

        /// <summary>
        /// To-do tentatively accepted
        /// </summary>
        Tentative,

        /// <summary>
        /// To-do delegated
        /// </summary>
        Delegated,

        /// <summary>
        /// To-do completed
        /// </summary>
        Completed,

        /// <summary>
        /// To-do in process of being completed
        /// </summary>
        InProcess
    }
}
