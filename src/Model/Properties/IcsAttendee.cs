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
    /// Represents an iCalendar Attendee property
    /// </summary>
    public class IcsAttendee : IcsString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsAttendee"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsAttendee(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsAttendee"/> class.
        /// </summary>
        public IcsAttendee()
            : base(IcsPropertyNames.Attendee)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsAttendee"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsAttendee(string value)
            : base(IcsPropertyNames.Attendee, value)
        {
        }

        /// <summary>
        /// Specifies the common name to be associated with the calendar user specified 
        /// by this property.
        /// </summary>
        public string CommonName
        {
            get
            {
                return ContentLine.GetParameter(IcsParameterNames.CommonName);
            }
            set
            {
                ContentLine.SetParameter(IcsParameterNames.CommonName, value);
            }
        }

        /// <summary>
        /// Specify the calendar users that have delegated their participation to the calendar user 
        /// specified by the attendee.
        /// </summary>
        public string[] DelegatedFrom
        {
            get
            {
                return IcsConverter.ToStringArrayOrDefault(ContentLine.GetParameter(IcsParameterNames.DelegatedFrom));
            }
            set
            {
                ContentLine.SetParameter(IcsParameterNames.DelegatedFrom, IcsConverter.FromStringArray(value));
            }
        }

        /// <summary>
        /// Specify the calendar users to whom the calendar user specified by the attendee has 
        /// delegated participation.
        /// </summary>
        public string[] DelegatedTo
        {
            get
            {
                return IcsConverter.ToStringArrayOrDefault(ContentLine.GetParameter(IcsParameterNames.DelegatedTo));
            }
            set
            {
                ContentLine.SetParameter(IcsParameterNames.DelegatedTo, IcsConverter.FromStringArray(value));
            }
        }

        /// <summary>
        /// Specifies a reference to the directory entry associated with the calendar user 
        /// specified by this property.
        /// </summary>
        public Uri DirectoryEntryReference
        {
            get
            {
                return IcsConverter.ToUri(ContentLine.GetParameter(IcsParameterNames.DirectoryEntryReference));
            }
            set
            {
                ContentLine.SetParameter(IcsParameterNames.DirectoryEntryReference, IcsConverter.FromUri(value));
            }
        }

        /// <summary>
        /// Specify the language for text values in this property.
        /// </summary>
        public string Language
        {
            get
            {
                return ContentLine.GetParameter(IcsParameterNames.Language);
            }
            set
            {
                ContentLine.SetParameter(IcsParameterNames.Language, value);
            }
        }

        /// <summary>
        /// Specify the group or list membership of the calendar user specified by the 
        /// attendee.
        /// </summary>
        public string[] Member
        {
            get
            {
                return IcsConverter.ToStringArrayOrDefault(ContentLine.GetParameter(IcsParameterNames.Member));
            }
            set
            {
                ContentLine.SetParameter(IcsParameterNames.Member, IcsConverter.FromStringArray(value));
            }
        }

        /// <summary>
        /// Specify the participation role for the calendar user specified by the attendee.
        /// </summary>
        public IcsParticipationRole? ParticipationRole
        {
            get
            {
                return IcsConverter.ToParticipationRoleOrDefault(ContentLine.GetParameter(IcsParameterNames.ParticipationRole));
            }
            set
            {
                ContentLine.SetParameter(IcsParameterNames.ParticipationRole, IcsConverter.FromParticipationRole(value));
            }
        }

        /// <summary>
        /// Specify whether there is an expectation of a favor of a reply from the calendar 
        /// user specified by the attendee value.
        /// </summary>
        public bool? RSVPExpectation
        {
            get
            {
                return IcsConverter.ToBoolean(ContentLine.GetParameter(IcsParameterNames.RSVPExpectation));
            }
            set
            {
                ContentLine.SetParameter(IcsParameterNames.RSVPExpectation, IcsConverter.FromBoolean(value));
            }
        }

        /// <summary>
        /// Specifies the calendar user that is acting on behalf of the calendar user specified by 
        /// this property.
        /// </summary>
        public string SentBy
        {
            get
            {
                return ContentLine.GetParameter(IcsParameterNames.SentBy);
            }
            set
            {
                ContentLine.SetParameter(IcsParameterNames.SentBy, value);
            }
        }

        /// <summary>
        /// Identify the type of calendar user specified by the attendee.
        /// </summary>
        public IcsUserType UserType
        {
            get
            {
                return IcsConverter.ToUserType(ContentLine.GetParameter(IcsParameterNames.UserType));
            }
            set
            {
                ContentLine.SetParameter(IcsParameterNames.UserType, IcsConverter.FromUserType(value));
            }
        }
    }
}