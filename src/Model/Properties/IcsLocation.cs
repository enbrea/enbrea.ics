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
    /// Represents an iCalendar Location property
    /// </summary>
    public class IcsLocation : IcsText
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsLocation"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsLocation(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsLocation"/> class.
        /// </summary>
        public IcsLocation()
            : base(IcsPropertyNames.Location)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsLocation"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsLocation(string value)
            : base(IcsPropertyNames.Location, value)
        {
        }
    }
}
