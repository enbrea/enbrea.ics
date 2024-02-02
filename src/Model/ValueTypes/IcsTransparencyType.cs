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
    /// Defines whether or not an event is transparent to busy time searches.
    /// </summary>
    public enum IcsTransparencyType
    {
        /// <summary>
        /// Unknown value.
        /// </summary>
        Unknown,

        /// <summary>
        /// Blocks or opaque on busy time searches.
        /// </summary>
        Opaque,

        /// <summary>
        /// Transparent on busy time searches
        /// </summary>
        Transparent
    }
}