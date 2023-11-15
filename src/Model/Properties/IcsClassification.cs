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
    /// Represents an iCalendar Classification property
    /// </summary>
    public class IcsClassification : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsClassification"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsClassification(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsClassification"/> class.
        /// </summary>
        public IcsClassification()
            : base(IcsPropertyNames.Classification)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsClassification"/> class.
        /// </summary>
        /// <param name="value">A classification value</param>
        public IcsClassification(IcsClassificationValue value)
            : base(IcsPropertyNames.Classification)
        {
            Value = value;
        }

        /// <summary>
        /// The classification value
        /// </summary>
        public IcsClassificationValue? Value
        {
            get 
            { 
                return IcsConverter.ToClassificationValue(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromClassificationValue(value); 
            }
        }
    }
}
