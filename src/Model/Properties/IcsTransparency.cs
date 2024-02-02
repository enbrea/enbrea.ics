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
    /// Represents an iCalendar Time Transparency property
    /// </summary>
    public class IcsTransparency : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTransparency"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsTransparency(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTransparency"/> class.
        /// </summary>
        public IcsTransparency()
            : base(IcsPropertyNames.Transparency)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTransparency"/> class.
        /// </summary>
        /// <param name="value">The transparency value</param>
        public IcsTransparency(IcsTransparencyType value)
            : base(IcsPropertyNames.Transparency)
        {
            Value = value;
        }

        /// <summary>
        /// The type value
        /// </summary>
        public IcsTransparencyType Value
        {
            get 
            { 
                return IcsConverter.ToTransparencyValue(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromTransparencyValue(value); 
            }
        }
    }
}
