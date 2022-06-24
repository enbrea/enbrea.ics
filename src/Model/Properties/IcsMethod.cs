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
    /// Represents an iCalendar Method property
    /// </summary>
    public class IcsMethod : IcsString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsMethod"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsMethod(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsMethod"/> class.
        /// </summary>
        public IcsMethod()
            : base(IcsPropertyNames.Method)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsMethod"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsMethod(string value)
            : base(IcsPropertyNames.Method, value)
        {
        }
    }
}
