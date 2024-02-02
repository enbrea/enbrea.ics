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
    /// Represents an iCalendar Organizer property
    /// </summary>
    public class IcsOrganizer : IcsString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsOrganizer"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsOrganizer(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsOrganizer"/> class.
        /// </summary>
        public IcsOrganizer()
            : base(IcsPropertyNames.Organizer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsOrganizer"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsOrganizer(string value)
            : base(IcsPropertyNames.Organizer, value)
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
    }
}
