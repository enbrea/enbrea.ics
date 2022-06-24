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
    /// Represents an iCalendar Priority property
    /// </summary>
    public class IcsPriority : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsPriority"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsPriority(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsPriority"/> class.
        /// </summary>
        public IcsPriority()
            : base(IcsPropertyNames.Priority)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsPriority"/> class.
        /// </summary>
        /// <param name="value">A priority value</param>
        public IcsPriority(byte value)
            : base(IcsPropertyNames.Priority)
        {
            Value = value;
        }

        /// <summary>
        /// The priority value
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
