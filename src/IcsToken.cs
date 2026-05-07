#region ENBREA.ICS - Copyright (C) STÜBER SYSTEMS GmbH
/*    
 *    ENBREA.ICS 
 *    
 *    Copyright (C) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents a token in an iCalendar (ICS) data stream, encapsulating its type and value.
    /// </summary>
    public class IcsToken
    {
        private readonly IcsTokenType _type;
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsToken"/> class.
        /// </summary>
        /// <param name="type">The type of the token to create. Specifies the kind of ICS token represented.</param>
        /// <param name="value">The string value associated with the token. This value represents the token's content.</param>
        public IcsToken(IcsTokenType type, string value)
        {
            _type = type;
            _value = value;
        }

        /// <summary>
        /// Gets the type of the ICS token represented by this instance.
        /// </summary>
        public IcsTokenType Type
        {
            get { return _type; }
        }

        /// <summary>
        /// Gets the string value represented by this instance.
        /// </summary>
        public string Value
        {
            get { return _value; }
        }
    }
}