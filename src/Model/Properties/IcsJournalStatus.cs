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
    /// Represents an iCalendar Journal Status property
    /// </summary>
    public class IcsJournalStatus : IcsProperty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsJournalStatus"/> class.
        /// </summary>
        /// <param name="contentLine">Raw content line of the property</param>
        public IcsJournalStatus(IcsContentLine contentLine)
            : base(contentLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsJournalStatus"/> class.
        /// </summary>
        public IcsJournalStatus()
            : base(IcsPropertyNames.Status)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsJournalStatus"/> class.
        /// </summary>
        /// <param name="value">A status value</param>
        public IcsJournalStatus(IcsJournalStatusValue value)
            : base(IcsPropertyNames.Status)
        {
            Value = value;
        }

        /// <summary>
        /// The status value
        /// </summary>
        public IcsJournalStatusValue Value
        {
            get 
            { 
                return IcsConverter.ToJournalStatusValue(ContentLine.Value); 
            }
            set 
            { 
                ContentLine.Value = IcsConverter.FromJournalStatusValue(value); 
            }
        }
    }
}
