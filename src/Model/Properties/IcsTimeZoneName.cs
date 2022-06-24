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
    /// Represents an iCalendar Time Zone Name property
    /// </summary>
    public class IcsTimeZoneName : IcsString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZoneName"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsTimeZoneName(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZoneName"/> class.
        /// </summary>
        public IcsTimeZoneName()
            : base(IcsPropertyNames.TimeZoneName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZoneName"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsTimeZoneName(string value)
            : base(IcsPropertyNames.TimeZoneName, value)
        {
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
