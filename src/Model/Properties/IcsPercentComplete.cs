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
    /// Represents an iCalendar Percent Complete property
    /// </summary>
    public class IcsPercentComplete : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsPercentComplete"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsPercentComplete(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsPercentComplete"/> class.
        /// </summary>
        public IcsPercentComplete()
            : base(IcsPropertyNames.PercentComplete)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsPercentComplete"/> class.
        /// </summary>
        /// <param name="value">A percentage figure</param>
        public IcsPercentComplete(byte value)
            : base(IcsPropertyNames.PercentComplete)
        {
            Value = value;
        }

        /// <summary>
        /// The percentage figure
        /// </summary>
        public byte Value
        {
            get 
            { 
                return IcsConverter.ToByte(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromByte(value); 
            }
        }
    }
}
