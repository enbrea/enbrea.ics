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

using System;

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalendar Time Zone URL property
    /// </summary>
    public class IcsTimeZoneUrl : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZoneUrl"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsTimeZoneUrl(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZoneUrl"/> class.
        /// </summary>
        public IcsTimeZoneUrl()
            : base(IcsPropertyNames.TimeZoneUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZoneUrl"/> class.
        /// </summary>
        /// <param name="value">An url value</param>
        public IcsTimeZoneUrl(Uri value)
            : base(IcsPropertyNames.TimeZoneUrl)
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
