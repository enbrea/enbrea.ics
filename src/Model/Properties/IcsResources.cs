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
    /// Represents an iCalendar Resources property
    /// </summary>
    public class IcsResources : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsResources"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsResources(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsResources"/> class.
        /// </summary>
        public IcsResources()
            : base(IcsPropertyNames.Resources)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsResources"/> class.
        /// </summary>
        /// <param name="values">An array of resource names</param>
        public IcsResources(string[] values)
            : base(IcsPropertyNames.Resources)
        {
            Values = values;
        }

        /// <summary>
        /// Specify an alternate text representation for the property value.
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

        /// <summary>
        /// List of resource names
        /// </summary>
        public string[] Values
        {
            get 
            { 
                return IcsConverter.ToStringArrayOrDefault(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromStringArray(value); 
            }
        }
    }
}
