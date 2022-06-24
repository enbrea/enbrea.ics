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
    /// Represents an iCalendar Action Property
    /// </summary>
    public class IcsAction : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsAction"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsAction(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsAction"/> class.
        /// </summary>
        public IcsAction()
            : base(IcsPropertyNames.Action)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsAction"/> class.
        /// </summary>
        /// <param name="value">An action value</param>
        public IcsAction(IcsActionValue value)
            : base(IcsPropertyNames.Action)
        {
            Value = value;
        }

        /// <summary>
        /// The action value
        /// </summary>
        public IcsActionValue? Value
        {
            get 
            { 
                return IcsConverter.ToActionValueOrDefault(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromActionValue(value); 
            }
        }
    }
}
