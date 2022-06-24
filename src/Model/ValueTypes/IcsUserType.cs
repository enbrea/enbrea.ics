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
    /// Represents a free or busy time type.
    /// </summary>
    public enum IcsUserType
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown,

        /// <summary>
        /// An individual
        /// </summary>
        Individual,

        /// <summary>
        /// A group of individuals
        /// </summary>
        Group,

        /// <summary>
        /// A physical resource
        /// </summary>
        Resource,

        /// <summary>
        /// A room resource
        /// </summary>
        Room
    }
}