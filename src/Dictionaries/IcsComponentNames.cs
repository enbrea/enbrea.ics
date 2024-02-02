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
    /// iCalendar component names
    /// </summary>
    public static class IcsComponentNames
    {
        public const string Alarm = "VALARM";
        public const string Calendar = "VCALENDAR";
        public const string Daylight = "DAYLIGHT";
        public const string Event = "VEVENT";
        public const string FreeBusy = "VFREEBUSY";
        public const string Journal = "VJOURNAL";
        public const string Standard = "STANDARD";
        public const string TimeZone = "VTIMEZONE"; 
        public const string Todo = "VTODO";
    }
}