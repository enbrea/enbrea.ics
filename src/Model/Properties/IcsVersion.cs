#region ENBREA.ICS - Copyright (C) 2022 STÜBER SYSTEMS GmbH
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
    /// Represents an iCalendar Version property
    /// </summary>
    public class IcsVersion : IcsString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsVersion"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsVersion(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsVersion"/> class.
        /// </summary>
        public IcsVersion()
            : base(IcsPropertyNames.Version)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsVersion"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsVersion(string value)
            : base(IcsPropertyNames.Version, value)
        {
        }
    }
}
