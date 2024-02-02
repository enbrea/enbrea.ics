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
    /// Represents possible values for an iCalendar free or busy time type.
    /// </summary>
    public enum IcsFreeBusyType
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates that the time interval is busy because one or more events 
        /// have been scheduled for that interval.
        /// </summary>
        Busy,

        /// <summary>
        /// Indicates that the time interval is free for scheduling.
        /// </summary>
        Free,

        /// <summary>
        /// Indicates that the time interval is busy because one or more events have 
        /// been tentatively scheduled for that interval.
        /// </summary>
        BusyTentative,

        /// <summary>
        /// Indicates that the time interval is busy and that the 
        /// interval can not be scheduled.
        /// </summary>
        BusyUnavailable
    }
}