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
    /// Represents an iCalendar To-Do Status property
    /// </summary>
    public class IcsTodoStatus : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTodoStatus"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsTodoStatus(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTodoStatus"/> class.
        /// </summary>
        public IcsTodoStatus()
            : base(IcsPropertyNames.Status)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTodoStatus"/> class.
        /// </summary>
        /// <param name="value">The status value</param>
        public IcsTodoStatus(IcsTodoStatusValue value)
            : base(IcsPropertyNames.Status)
        {
            Value = value;
        }

        /// <summary>
        /// The status value
        /// </summary>
        public IcsTodoStatusValue Value
        {
            get 
            { 
                return IcsConverter.ToTodoStatusValue(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromTodoStatusValue(value); 
            }
        }
    }
}
