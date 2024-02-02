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
    /// Represents possible values for an iCalendar alarm action.
    /// </summary>
    public enum IcsActionValue
    {
        /// <summary>
        /// Unknown action.
        /// </summary>
        Unknown,

        /// <summary>
        /// Alarm via sound resource.
        /// </summary>
        Audio,

        /// <summary>
        /// Alarm via text display.
        /// </summary>
        Display,

        /// <summary>
        /// Alarm via email message.
        /// </summary>
        Email
    }
}