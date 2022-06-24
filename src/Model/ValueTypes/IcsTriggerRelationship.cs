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
    /// Relationship of an alarm trigger with respect to the start or 
    /// end of the calendar component.
    /// </summary>
    public enum IcsTriggerRelationship
    {
        /// <summary>
        /// Trigger off of start
        /// </summary>
        Start,

        /// <summary>
        /// Trigger off of end
        /// </summary>
        End
    }
}