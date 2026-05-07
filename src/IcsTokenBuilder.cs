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

using System.Text;

namespace Enbrea.Ics
{
    /// <summary>
    /// Provides a builder for constructing iCalendar (ICS) tokens by accumulating characters and 
    /// specifying the token type.
    /// </summary>
    public class IcsTokenBuilder
    {
        private readonly StringBuilder _value;
        private IcsTokenType _type;

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTokenBuilder"/> class.
        /// </summary>
        /// <param name="type">The type of the token to build.</param>
        public IcsTokenBuilder(IcsTokenType type)
        {
            _type = type;
            _value = new StringBuilder();
        }

        /// <summary>
        /// Gets the type of the ICS token represented by this instance.
        /// </summary>
        public IcsTokenType Type
        {
            get { return _type; }
        }

        /// <summary>
        /// Appends the specified character to the end of the current value.
        /// </summary>
        /// <param name="c">The character to append.</param>
        public void Append(char c)
        {
            _value.Append(c);
        }

        /// <summary>
        /// Resets the token to the specified type and clears its current value.
        /// </summary>
        /// <param name="newType">The new token type to assign to the token.</param>
        public void Reset(IcsTokenType newType)
        {
            _type = newType;
            _value.Clear();
        }

        /// <summary>
        /// Converts the current instance to an equivalent <see cref="IcsToken"/> object.
        /// </summary>
        /// <returns>An <see cref="IcsToken"/> that represents the current instance.</returns>
        public IcsToken ToToken()
        {
            return new IcsToken(_type, _value.ToString());
        }
    }
}