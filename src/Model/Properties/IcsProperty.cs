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
    /// Represents an abstract iCalendar property
    /// </summary>
    public abstract class IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsProperty"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsProperty(IcsContentLine contentLine)
        {
            ContentLine = contentLine;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsProperty"/> class.
        /// </summary>
        /// <param name="name">A property name</param>
        public IcsProperty(string name)
            : this(new IcsContentLine(name))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsProperty"/> class.
        /// </summary>
        /// <param name="name">A property name</param>
        /// <param name="value">A property value</param>
        public IcsProperty(string name, string value)
            : this(new IcsContentLine(name, value))
        {
        }

        /// <summary>
        /// The raw content line of the property.
        /// </summary>
        public IcsContentLine ContentLine { get; }
    }
}
