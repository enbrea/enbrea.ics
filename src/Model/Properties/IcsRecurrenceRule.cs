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
    /// Represents an iCalendar Recurrence Rule property
    /// </summary>
    public class IcsRecurrenceRule : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRecurrenceRule"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsRecurrenceRule(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRecurrenceRule"/> class.
        /// </summary>
        public IcsRecurrenceRule()
            : base(IcsPropertyNames.RecurrenceRule)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRecurrenceRule"/> class.
        /// </summary>
        /// <param name="value">A recurrence rule pattern</param>
        public IcsRecurrenceRule(IcsRecurrencePattern value)
            : base(IcsPropertyNames.RecurrenceRule)
        {
            Value = value;
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
        /// The recurrence rule pattern
        /// </summary>
        public IcsRecurrencePattern Value
        {
            get 
            { 
                return IcsConverter.ToRecurrencePattern(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromRecurrencePattern(value); 
            }
        }

        /// <summary>
        /// Property has a time zone definition?
        /// </summary>
        /// <returns>True, if time zone definition exists</returns>
        public bool HasTimeZoneId()
        {
            return ContentLine.GetParameter(IcsParameterNames.TimeZoneId) != null;
        }
    }
}
