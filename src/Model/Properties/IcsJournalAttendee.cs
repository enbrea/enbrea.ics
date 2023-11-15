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
    /// Represents an iCalendar Attendee property
    /// </summary>
    public class IcsJournalAttendee : IcsAttendee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsJournalAttendee"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsJournalAttendee(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsJournalAttendee"/> class.
        /// </summary>
        public IcsJournalAttendee()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsJournalAttendee"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsJournalAttendee(string value)
            : base(value)
        {
        }

        /// <summary>
        /// Specify the participation status for the calendar user specified by 
        /// the attendee.
        /// </summary>
        public IcsJournalParticipationStatus? ParticipationStatus
        {
            get
            {
                return IcsConverter.ToJournalParticipationStatusOrDefault(ContentLine.GetParameter(IcsParameterNames.ParticipationStatus));
            }
            set
            {
                ContentLine.SetParameter(IcsParameterNames.ParticipationStatus, IcsConverter.FromJournalParticipationStatus(value));
            }
        }
    }
}