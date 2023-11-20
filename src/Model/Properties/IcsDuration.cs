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

using System;

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalendar Duration property
    /// </summary>
    public class IcsDuration : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsDuration"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsDuration(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsDuration"/> class.
        /// </summary>
        public IcsDuration()
            : base(IcsPropertyNames.Duration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsDuration"/> class.
        /// </summary>
        /// <param name="value">A duration value</param>
        public IcsDuration(TimeSpan value)
            : base(IcsPropertyNames.Duration)
        {
            Value = value;
        }

        /// <summary>
        /// The duration value
        /// </summary>
        public TimeSpan Value
        {
            get 
            { 
                return IcsConverter.ToTimeSpan(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromTimeSpan(value); 
            }
        }
    }
}

