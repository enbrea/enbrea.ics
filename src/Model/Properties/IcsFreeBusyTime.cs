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
    /// Represents an iCalendar Free/Busy Time property
    /// </summary>
    public class IcsFreeBusyTime : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsFreeBusyTime"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsFreeBusyTime(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsFreeBusyTime"/> class.
        /// </summary>
        public IcsFreeBusyTime()
            : base(IcsPropertyNames.FreeBusy)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsFreeBusyTime"/> class.
        /// </summary>
        /// <param name="values">An array of periods of time</param>
        public IcsFreeBusyTime(IcsPeriod[] values)
            : base(IcsPropertyNames.FreeBusy)
        {
            Values = values;
        }

        /// <summary>
        /// An identifier for the time zone definition
        /// </summary>
        public string TimeZoneId
        {
            get 
            { 
                return ContentLine.GetParameter(IcsParameterNames.TimeZoneId); 
            }
            set 
            { 
                ContentLine.SetParameter(IcsParameterNames.TimeZoneId, value); 
            }
        }

        /// <summary>
        /// Specifies the free or busy time typ
        /// </summary>
        public IcsFreeBusyType? Type
        {
            get 
            { 
                return IcsConverter.ToFreeBusyTypeOrDefault(ContentLine.GetParameter(IcsParameterNames.FreeBusyType)); 
            }
            set 
            { 
                ContentLine.SetParameter(IcsParameterNames.FreeBusyType, IcsConverter.FromFreeBusyType(value)); 
            }
        }

        /// <summary>
        /// List of periods
        /// </summary>
        public IcsPeriod[] Values
        {
            get 
            { 
                return IcsConverter.ToPeriodArrayOrDefault(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromPeriodArray(value); 
            }
        }

        /// <summary>
        /// Has time zone parameter?
        /// </summary>
        /// <returns>TRUE, if time zone parameter exists</returns>
        public bool HasTimeZoneId()
        {
            return ContentLine.GetParameter(IcsParameterNames.TimeZoneId) != null;
        }
    }
}
