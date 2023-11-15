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
    /// Represents an iCalendar Repeat Count property
    /// </summary>
    public class IcsRepeatCount : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRepeatCount"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsRepeatCount(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRepeatCount"/> class.
        /// </summary>
        public IcsRepeatCount()
            : base(IcsPropertyNames.RepeatCount)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRepeatCount"/> class.
        /// </summary>
        /// <param name="value">A integer value</param>
        public IcsRepeatCount(int value)
            : base(IcsPropertyNames.RepeatCount)
        {
            Value = value;
        }

        /// <summary>
        /// The repeat count value
        /// </summary>
        public int? Value
        {
            get 
            { 
                return IcsConverter.ToIntegerOrDefault(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromInteger(value); 
            }
        }
    }
}
