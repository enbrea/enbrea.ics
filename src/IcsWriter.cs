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

using System.IO;
using System.Threading.Tasks;

namespace Enbrea.Ics
{
    /// <summary>
    /// Serializes a <see cref="IcsCalendar"> instances to a given stream
    /// </summary>
    public class IcsWriter
    {
        private TextWriter _textWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsWriter"/> class.
        /// </summary>
        /// <param name="textWriter">The text writer to be used.</param>
        public IcsWriter(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        /// <summary>
        /// Serializes an iCalender instance.
        /// </summary>
        /// <param name="calendar">The iCalender instance</param>
        public void Write(IcsCalendar calendar)
        {
            calendar.WriteContent(_textWriter);
        }

        /// <summary>
        /// Serializes an iCalender instance.
        /// </summary>
        /// <param name="calendar">The iCalender instance</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteAsync(IcsCalendar calendar)
        {
            await calendar.WriteContentAsync(_textWriter);
        }
    }
}
