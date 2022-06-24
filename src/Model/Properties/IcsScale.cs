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
    /// Represents an iCalendar Scale property
    /// </summary>
    public class IcsScale : IcsString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsScale"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsScale(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsScale"/> class.
        /// </summary>
        public IcsScale()
            : base(IcsPropertyNames.Scale)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsScale"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsScale(string value)
            : base(IcsPropertyNames.Scale, value)
        {
        }
    }
}
