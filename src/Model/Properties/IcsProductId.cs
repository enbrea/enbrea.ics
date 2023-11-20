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
    /// Represents an iCalendar Product Identifier property
    /// </summary>
    public class IcsProductId : IcsString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsProductId"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsProductId(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsProductId"/> class.
        /// </summary>
        public IcsProductId()
            : base(IcsPropertyNames.ProductId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsProductId"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsProductId(string value)
            : base(IcsPropertyNames.ProductId, value)
        {
        }
    }
}
