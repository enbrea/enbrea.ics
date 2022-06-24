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

using System;

namespace Enbrea.Ics
{
    /// <summary>
    /// A static Exceptions Factory class
    /// </summary>
    public static class IcsExceptions
    {
        public static Exception ThrowInvalidLine(string componentName, IcsContentLine contentLine)
        {
            return new FormatException($"The line {contentLine} is not allowed inside {componentName}");
        }
    }
}

