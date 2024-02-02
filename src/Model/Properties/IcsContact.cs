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
    /// Represents an iCalendar Contact property
    /// </summary>
    public class IcsContact : IcsText
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsContact"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsContact(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsContact"/> class.
        /// </summary>
        public IcsContact()
            : base(IcsPropertyNames.Contact)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsContact"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsContact(string value)
            : base(IcsPropertyNames.Contact, value)
        {
        }
    }
}
