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
    /// Represents an iCalendar Attendee property
    /// </summary>
    public class IcsTodoAttendee : IcsAttendee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTodoAttendee"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsTodoAttendee(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTodoAttendee"/> class.
        /// </summary>
        public IcsTodoAttendee()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTodoAttendee"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsTodoAttendee(string value)
            : base(value)
        {
        }

        /// <summary>
        /// Specify the participation status for the calendar user specified by 
        /// the attendee.
        /// </summary>
        public IcsTodoParticipationStatus ParticipationStatus
        {
            get
            {
                return IcsConverter.ToTodoParticipationStatus(ContentLine.GetParameter(IcsParameterNames.ParticipationStatus));
            }
            set
            {
                ContentLine.SetParameter(IcsParameterNames.ParticipationStatus, IcsConverter.FromTodoParticipationStatus(value));
            }
        }
    }
}