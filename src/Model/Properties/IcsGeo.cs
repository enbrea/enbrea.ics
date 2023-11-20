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
    /// Represents an iCalendar Geographic Position property
    /// </summary>
    public class IcsGeo : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsGeo"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsGeo(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsGeo"/> class.
        /// </summary>
        public IcsGeo()
            : base(IcsPropertyNames.Geo)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsGeo"/> class.
        /// </summary>
        /// <param name="value">A geo location</param>
        public IcsGeo(IcsGeoPosition value)
            : base(IcsPropertyNames.Geo)
        {
            Value = value;
        }

        /// <summary>
        /// The geo position
        /// </summary>
        public IcsGeoPosition? Value
        {
            get 
            { 
                return IcsConverter.ToGeoPosition(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromGeoPosition(value); 
            }
        }
    }
}
