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

using System;

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an error that occurs during iCalendar parsing inside a <see cref="IcsContentLineParser"/> 
    /// instance.
    /// </summary>
    [Serializable]
    public class IcsContentLineParserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsContentLineParserException"/> class.
        /// </summary>
        /// <param name="lineNo">The line number in the input where the parsing error occurred.</param>
        /// <param name="message">The error message that describes the parsing issue.</param>
        public IcsContentLineParserException(int lineNo, string message)
            : base($"Line {lineNo}: {message}")
        { }
    }
}

