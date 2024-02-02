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

using System.Collections.Generic;
using System.IO;

namespace Enbrea.Ics
{
    /// <summary>
    /// Deserializes <see cref="IcsCalendar"> instances from a given stream
    /// </summary>
    public class IcsReader
    {
        private readonly IcsContentLineParser _icsParser;
        private IcsCalendarBuilder _icsCalendarBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsReader"/> class.
        /// </summary>
        /// <param name="textReader">The text reader to be used.</param>
        public IcsReader(TextReader textReader)
        {
            _icsParser = new IcsContentLineParser(textReader);
            _icsCalendarBuilder = null;
        }

        /// <summary>
        /// Reads all iCalendar objects out of the stream and gives back an enumerator. 
        /// </summary>
        /// <returns>An enumerator of iCalendar objects.</returns>
        public IEnumerable<IcsCalendar> Read()
        {
            foreach (var contentLine in _icsParser.Read())
            {
                if (ConsumeContentLine(contentLine))
                {
                    yield return _icsCalendarBuilder.Calendar;
                    _icsCalendarBuilder = null;
                }
            }
        }

        /// <summary>
        /// Reads all iCalendar objects out of the stream and gives back an enumerator. 
        /// </summary>
        /// <returns>An async enumerator of iCalendar objects.</returns>
        public async IAsyncEnumerable<IcsCalendar> ReadAsync()
        {
            await foreach (var contentLine in _icsParser.ReadAsync())
            {
                if (ConsumeContentLine(contentLine))
                {
                    yield return _icsCalendarBuilder.Calendar;
                    _icsCalendarBuilder = null;
                }
            }
        }

        /// <summary>
        /// Consumes a freshly parsed content line to build the current iCalendar object.
        /// </summary>
        /// <param name="contentLine">The conten line</param>
        /// <returns>True if this was the last content line of the iCalendar object.</returns>
        private bool ConsumeContentLine(IcsContentLine contentLine)
        {
            if (_icsCalendarBuilder != null)
            {
                if (contentLine.Name == IcsCoreNames.End && contentLine.Value == IcsComponentNames.Calendar)
                {
                    return true;
                }
                else
                {
                    _icsCalendarBuilder.Consume(contentLine);
                    return false;
                }
            }
            else
            {
                if (contentLine.Name == IcsCoreNames.Begin)
                {
                    if (contentLine.Value == IcsComponentNames.Calendar)
                    {
                        if (_icsCalendarBuilder == null)
                        {
                            _icsCalendarBuilder = new IcsCalendarBuilder();
                            return false;
                        }
                        else
                        {
                            throw IcsExceptions.ThrowInvalidLine(IcsComponentNames.Calendar, contentLine);
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}