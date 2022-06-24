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

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalendar Attendee property
    /// </summary>
    public class IcsEventAttendee : IcsAttendee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsEventAttendee"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsEventAttendee(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsEventAttendee"/> class.
        /// </summary>
        public IcsEventAttendee()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsEventAttendee"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsEventAttendee(string value)
            : base(value)
        {
        }

        /// <summary>
        /// Specify the participation status for the calendar user specified by 
        /// the attendee.
        /// </summary>
        public IcsEventParticipationStatus? ParticipationStatus
        {
            get
            {
                return IcsConverter.ToEventParticipationStatusOrDefault(ContentLine.GetParameter(IcsParameterNames.ParticipationStatus));
            }
            set
            {
                ContentLine.SetParameter(IcsParameterNames.ParticipationStatus, IcsConverter.FromEventParticipationStatus(value));
            }
        }
    }
}