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
    /// Specifies the types of tokens recognized when parsing iCalendar (ICS) data.
    /// </summary>
    public enum IcsTokenType { 
        Name, 
        ParamName, 
        ParamValue, 
        Value 
    }
}