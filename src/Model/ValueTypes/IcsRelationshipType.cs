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
    /// Represents possible values for an iCalendar type of hierarchical relationship associated with 
    /// a calendar.
    /// </summary>
    public enum IcsRelationshipType
    {
        /// <summary>
        /// Unknown value.
        /// </summary>
        Unknown,

        /// <summary>
        /// Parent relationship
        /// </summary>
        Parent,

        /// <summary>
        /// Child relationship
        /// </summary>
        Child,

        /// <summary>
        /// Sibling relationship
        /// </summary>
        Sibling
    }
}