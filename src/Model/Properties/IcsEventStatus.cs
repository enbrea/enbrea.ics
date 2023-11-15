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
    /// Represents an iCalendar Event Status property
    /// </summary>
    public class IcsEventStatus : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsEventStatus"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsEventStatus(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsEventStatus"/> class.
        /// </summary>
        public IcsEventStatus()
            : base(IcsPropertyNames.Status)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsEventStatus"/> class.
        /// </summary>
        /// <param name="value">A status value</param>
        public IcsEventStatus(IcsEventStatusValue value)
            : base(IcsPropertyNames.Status)
        {
            Value = value;
        }

        /// <summary>
        /// The status value
        /// </summary>
        public IcsEventStatusValue Value
        {
            get 
            { 
                return IcsConverter.ToEventStatusValue(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromEventStatusValue(value); 
            }
        }
    }
}
