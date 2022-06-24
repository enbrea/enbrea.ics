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
    /// Represents possible values for an iCalendar participation role for a user.
    /// </summary>
    public enum IcsParticipationRole
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates chair of a calendar entity
        /// </summary>
        Chair,

        /// <summary>
        /// Indicates a participant whose participation is required.
        /// </summary>
        Required,

        /// <summary>
        /// Indicates a participant whose participation is optional
        /// </summary>
        Optional,

        /// <summary>
        /// Indicates a participant who is copied for information
        /// purposes only
        /// </summary>
        None
    }
}