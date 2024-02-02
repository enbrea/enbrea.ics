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
    /// Represents an iCalendar Description property
    /// </summary>
    public class IcsDescription : IcsText
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsDescription"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsDescription(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsDescription"/> class.
        /// </summary>
        public IcsDescription()
            : base(IcsPropertyNames.Description)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsDescription"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsDescription(string value)
            : base(IcsPropertyNames.Description, value)
        {
        }
    }
}
