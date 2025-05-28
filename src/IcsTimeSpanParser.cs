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

using System;
using System.Globalization;

namespace Enbrea.Ics
{
    /// <summary>
    /// Parser for the iCalender duration value string representation
    /// </summary>
    /// <remarks>
    /// This implementation supports floating point (fractional) seconds, even if the specification 
    /// (RFC 5545) does not explicitly require or prohibit this. Many calendar systems and parsers 
    /// accept fractional seconds, especially because they are common in ISO 8601 duration specifications 
    /// (on which the RFC 5545 duration format is based).
    /// </remarks>
    public static class IcsTimeSpanParser
    {
        /// <summary>
        /// Converts the string representation of an iCalendar duration to its <see cref="TimeSpan"/>
        /// equivalent.
        /// </summary>
        /// <param name="input">The input string to be parsed</param>
        /// <returns>A time span that corresponds to input</returns>
        public static TimeSpan Parse(ReadOnlySpan<char> input)
        {
            if (input.IsEmpty)
            {
                throw new FormatException("Input cannot be empty.");
            }

            int pos = 0;
            bool negative = false;

            if (input[pos] == '+' || input[pos] == '-')
            {
                negative = input[pos] == '-';
                pos++;
            }

            if (pos >= input.Length || input[pos] != 'P')
            {
                throw new FormatException("Duration must start with 'P' after optional sign.");
            }

            pos++;

            bool inTime = false;
            int weeks = 0, days = 0, hours = 0, minutes = 0;
            double seconds = 0;

            while (pos < input.Length)
            {
                if (input[pos] == 'T')
                {
                    inTime = true;
                    pos++;
                    continue;
                }

                var start = pos;
                while (pos < input.Length && (char.IsDigit(input[pos]) || input[pos] == '.'))
                {
                    pos++;
                }

                if (start == pos || pos >= input.Length)
                {
                    throw new FormatException("Expected number followed by a unit.");
                }

                var numberSpan = input[start..pos];

                if (!double.TryParse(numberSpan, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                {
                    throw new FormatException("Invalid numeric value.");
                }

                var unit = input[pos++];

                if (!inTime)
                {
                    switch (unit)
                    {
                        case 'W': 
                            weeks = (int)value; 
                            break;
                        case 'D': 
                            days = (int)value; 
                            break;
                        default: 
                            throw new FormatException($"Unexpected date unit '{unit}'.");
                    }
                }
                else
                {
                    switch (unit)
                    {
                        case 'H': 
                            hours = (int)value; 
                            break;
                        case 'M': 
                            minutes = (int)value; 
                            break;
                        case 'S': 
                            seconds = value; 
                            break;
                        default: 
                            throw new FormatException($"Unexpected time unit '{unit}'.");
                    }
                }
            }

            var ts = new TimeSpan(weeks * 7 + days, hours, minutes, (int)seconds, (int)((seconds - (int)seconds) * 1000));
            return negative ? -ts : ts;
        }

        /// <summary>
        /// Converts the string representation of an iCalendar duration to its <see cref="TimeSpan"/>
        /// equivalent.
        /// </summary>
        /// <param name="input">The input string to be parsed</param>
        /// <param name="result">A time span that corresponds to input.</param>
        /// <returns>TRUE, if parsing was successfull</returns>
        public static bool TryParse(ReadOnlySpan<char> input, out TimeSpan result)
        {
            result = TimeSpan.Zero;
            try
            {
                result = Parse(input);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
