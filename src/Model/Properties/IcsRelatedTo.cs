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
    /// Represents an iCalendar Related To property
    /// </summary>
    public class IcsRelatedTo : IcsString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRelatedTo"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsRelatedTo(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRelatedTo"/> class.
        /// </summary>
        public IcsRelatedTo()
            : base(IcsPropertyNames.RelatedTo)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRelatedTo"/> class.
        /// </summary>
        /// <param name="value">A string value</param>
        public IcsRelatedTo(string value)
            : base(IcsPropertyNames.RelatedTo, value)
        {
        }

        /// <summary>
        /// The property value
        /// </summary>
        public IcsRelationshipType? Type
        {
            get 
            { 
                return IcsConverter.ToRelationshipTypeOrDefault(ContentLine.GetParameter(IcsParameterNames.RelationshipType)); 
            }
            set 
            { 
                ContentLine.SetParameter(IcsParameterNames.RelationshipType, IcsConverter.FromRelationshipType(value)); 
            }
        }
    }
}
