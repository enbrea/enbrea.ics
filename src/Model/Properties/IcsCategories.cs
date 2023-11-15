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
    /// Represents an iCalendar Categories property
    /// </summary>
    public class IcsCategories : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsCategories"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsCategories(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsCategories"/> class.
        /// </summary>
        public IcsCategories()
            : base(IcsPropertyNames.Categories)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsCategories"/> class.
        /// </summary>
        /// <param name="values">An array of category names</param>
        public IcsCategories(string[] values)
            : base(IcsPropertyNames.Categories)
        {
            Values = values;
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
        /// The list of category names
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
