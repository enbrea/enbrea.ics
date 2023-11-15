#region ENBREA.ICS - Copyright (C) 2023 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA.ICS 
 *    
 *    Copyright (C) 2023 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalendar Summary property
    /// </summary>
    public class IcsSummary : IcsText
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsSummary"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsSummary(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsSummary"/> class.
        /// </summary>
        public IcsSummary()
            : base(IcsPropertyNames.Summary)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsSummary"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsSummary(string value)
            : base(IcsPropertyNames.Summary, value)
        {
        }
    }
}
