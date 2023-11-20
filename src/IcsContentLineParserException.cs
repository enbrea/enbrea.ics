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
    /// Represents an error that occurs during iCalendar parsing inside a
    /// <see cref="IcsContentLineParser"/> instance.
    /// </summary>
    [Serializable]
    public class IcsContentLineParserException : Exception
    {
        public IcsContentLineParserException(int lineNo, string message)
            : base($"Line {lineNo}: {message}")
        { }
    }
}

