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
    /// Represents possible values for an iCalnedar classification.
    /// </summary>
    public enum IcsClassificationValue
    {
        /// <summary>
        /// Unknown value.
        /// </summary>
        Unknown,

        /// <summary>
        /// Public value.
        /// </summary>
        Public,

        /// <summary>
        /// Private value.
        /// </summary>
        Private,

        /// <summary>
        /// Confidential value.
        /// </summary>
        Confidential
    }
}