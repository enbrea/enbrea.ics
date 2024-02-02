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
    /// Represents an iCalendar Request Status property
    /// </summary>
    public class IcsRequestStatus : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRequestStatus"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsRequestStatus(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRequestStatus"/> class.
        /// </summary>
        public IcsRequestStatus()
            : base(IcsPropertyNames.RequestStatus)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRequestStatus"/> class.
        /// </summary>
        /// <param name="value">A status value</param>
        public IcsRequestStatus(IcsRequestStatusValue value)
            : base(IcsPropertyNames.RequestStatus)
        {
            Value = value;
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
        /// The request status value
        /// </summary>
        public IcsRequestStatusValue Value
        {
            get
            {
                return IcsConverter.ToRequestStatusValue(ContentLine.Value);
            }
            set
            {
                ContentLine.Value = IcsConverter.FromRequestStatusValue(value);
            }
        }
    }
}
