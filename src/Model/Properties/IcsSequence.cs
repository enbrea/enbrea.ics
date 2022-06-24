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
    /// Represents an iCalendar Sequence property
    /// </summary>
    public class IcsSequence : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsSequence"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsSequence(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsSequence"/> class.
        /// </summary>
        public IcsSequence()
            : base(IcsPropertyNames.Sequence)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsSequence"/> class.
        /// </summary>
        /// <param name="value">An sequence value</param>
        public IcsSequence(int value)
            : base(IcsPropertyNames.Sequence)
        {
            Value = value;
        }

        /// <summary>
        /// The sequence value
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
