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
    /// Represents an abstract text value based iCalendar property
    /// </summary>
    public abstract class IcsText : IcsString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsText"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsText(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsText"/> class.
        /// </summary>
        /// <param name="name">A property name</param>
        public IcsText(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsText"/> class.
        /// </summary>
        /// <param name="name">A property name</param>
        /// <param name="value">A string value</param>
        public IcsText(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Specify an alternate text representation for the property.
        /// </summary>
        public Uri AlternateRepresentation
        {
            get
            {
                return IcsConverter.ToUri(ContentLine.GetParameter(IcsParameterNames.AlternateRepresentation));
            }
            set
            {
                ContentLine.SetParameter(IcsParameterNames.AlternateRepresentation, IcsConverter.FromUri(value));
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
    }
}
