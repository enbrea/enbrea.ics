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
    /// Represents an iCalendar Comment property
    /// </summary>
    public class IcsComment : IcsText
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsComment"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsComment(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsComment"/> class.
        /// </summary>
        public IcsComment()
            : base(IcsPropertyNames.Comment)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsComment"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsComment(string value)
            : base(IcsPropertyNames.Comment, value)
        {
        }
    }
}
