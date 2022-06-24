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

using System;

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalendar Attachment property
    /// </summary>
    public class IcsAttachment : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsAttachment"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsAttachment(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsAttachment"/> class.
        /// </summary>
        public IcsAttachment()
            : base(IcsPropertyNames.Attachment)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsAttachment"/> class.
        /// </summary>
        /// <param name="value">An url value</param>
        public IcsAttachment(Uri value)
            : base(IcsPropertyNames.Attachment)
        {
            ValueAsUri = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsAttachment"/> class.
        /// </summary>
        /// <param name="value">An inline binary encoded value</param>
        public IcsAttachment(byte[] value)
            : base(IcsPropertyNames.Attachment)
        {
            ValueAsBinary = value;
        }

        /// <summary>
        /// Specify the content type of a referenced object
        /// </summary>
        public string FormatType
        {
            get 
            { 
                return ContentLine.GetParameter(IcsParameterNames.FormatType); 
            }
            set 
            { 
                ContentLine.SetParameter(IcsParameterNames.FormatType, value); 
            }
        }

        /// <summary>
        /// Value as inline binary encoded
        /// </summary>
        public byte[] ValueAsBinary
        {
            get 
            { 
                return IcsConverter.ToBinaryOrDefault(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromBinary(value);
                ContentLine.SetParameter(IcsParameterNames.Encoding, "BASE64");
                ContentLine.SetParameter(IcsParameterNames.Value, "BINARY");
            }
        }

        /// <summary>
        /// Value as url associated with the attachment.
        /// </summary>
        public Uri ValueAsUri
        {
            get 
            { 
                return IcsConverter.ToUri(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromUri(value);
                ContentLine.RemoveParameter(IcsParameterNames.Encoding);
                ContentLine.RemoveParameter(IcsParameterNames.Value);
            }
        }

        /// <summary>
        /// Is value inline binary encoded?
        /// </summary>
        /// <returns>TRUE, if value is inline binary encoded</returns>
        public bool IsBinary()
        {
            return 
                ContentLine.GetParameter(IcsParameterNames.Encoding) == "BASE64" && 
                ContentLine.GetParameter(IcsParameterNames.Value) == "BINARY";
        }

        /// <summary>
        /// Is value an url?
        /// </summary>
        /// <returns>TRUE, if value is url</returns>
        public bool IsUri()
        {
            return !IsBinary();
        }
    }
}
