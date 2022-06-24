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
    /// Represents an abstract string value based iCalendar property
    /// </summary>
    public abstract class IcsString : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsString"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsString(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsString"/> class.
        /// </summary>
        /// <param name="name">A property name</param>
        public IcsString(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsString"/> class.
        /// </summary>
        /// <param name="name">A property name</param>
        /// <param name="value">A string value</param>
        public IcsString(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// The string value
        /// </summary>
        public string Value
        {
            get 
            { 
                return ContentLine.Value; 
            }
            set 
            { 
                ContentLine.Value = value; 
            }
        }
    }
}
