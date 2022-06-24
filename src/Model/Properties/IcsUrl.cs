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

using System;

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalendar Uniform Resource Locator property
    /// </summary>
    public class IcsUrl : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsUrl"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsUrl(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsUrl"/> class.
        /// </summary>
        public IcsUrl()
            : base(IcsPropertyNames.Url)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsUrl"/> class.
        /// </summary>
        /// <param name="value">An url value</param>
        public IcsUrl(Uri value)
            : base(IcsPropertyNames.Url)
        {
            Value = value;
        }

        /// <summary>
        /// The url value
        /// </summary>
        public Uri Value
        {
            get 
            { 
                return IcsConverter.ToUri(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromUri(value); 
            }
        }
    }
}
