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
    /// Represents an iCalendar Unique Identifier property
    /// </summary>
    public class IcsUid : IcsString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsUid"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsUid(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsUid"/> class.
        /// </summary>
        public IcsUid()
            : base(IcsPropertyNames.Uid)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsUid"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsUid(string value)
            : base(IcsPropertyNames.Uid, value)
        {
        }
    }
}
