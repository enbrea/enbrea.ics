#region ENBREA.ICS Copyright (C) 2022 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA.ICS 
 *    
 *    Copyright (C) 2022 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using System;
using System.Diagnostics;

namespace Enbrea.Ics
{
    /// <summary>
    /// Internal parser for the iCalender Duration value string representation
    /// </summary>
    /// <remnarks>
    /// Heavly inspired by the internal .NET class System.Globalization.TimeSpanParse.
    /// </remnarks>
    public static class IcsTimeSpanParser
    {
        private enum TokenType : byte
        {
            None = 0,         // None of the Token fields are set
            End = 1,          // End of input
            Num = 2,          // Number
            Sep = 3,          // Literal
            NumOverflow = 4   // Number that overflowed
        }

        /// <summary>
        /// Converts the string representation of an iCalendar duration to its <see cref="TimeSpan"/>
        /// equivalent.
        /// </summary>
        /// <param name="input">The input string to be parsed</param>
        /// <returns>A time span that corresponds to input</returns>
        public static TimeSpan Parse(ReadOnlySpan<char> input)
        {
            bool success = TryParseTimeSpan(input, out var ts, true);
            Debug.Assert(success, "Should have thrown on failure");
            return ts;
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
            if (TryParseTimeSpan(input, out var ts, false))
            {
                result = ts;
                return true;
            }

            result = default;
            return false;
        }

        private static bool SetOverflowFailure(bool throwOnFailure)
        {
            if (!throwOnFailure)
            {
                return false;
            }

            throw new OverflowException("Error");
        }

        private static bool TryParseTimeSpan(ReadOnlySpan<char> input, out TimeSpan result, bool throwOnFailure)
        {
            result = default;

            bool? negate = null;   // Negate result?

            bool seenP = false;    // already processed P sign?
            bool seenW = false;    // already processed W sign?
            bool seenD = false;    // already processed D sign?
            bool seenT = false;    // already processed T sign?
            bool seenH = false;    // already processed H sign?
            bool seenM = false;    // already processed M sign?
            bool seenS = false;    // already processed S sign?

            int ww = 0;            // parsed weeks
            int dd = 0;            // parsed days
            int hh = 0;            // parsed hours
            int mm = 0;            // parsed minutes
            int ss = 0;            // parsed seconds

            var tokenizer = new TimeSpanTokenizer(input);

            int? lastNum = null;

            while (!tokenizer.EOL)
            {
                var token = tokenizer.GetNextToken();

                if (token._ttt == TokenType.Sep)
                {
                    switch (token._sep)
                    {
                        case '+':
                            if (negate != null || seenP) return SetOverflowFailure(throwOnFailure);
                            negate = false;
                            break;
                        case '-':
                            if (negate != null || seenP) return SetOverflowFailure(throwOnFailure);
                            negate = true;
                            break;
                        case 'P':
                            if (seenP) return SetOverflowFailure(throwOnFailure);
                            seenP = true;
                            break;
                        case 'W':
                            if (lastNum == null || !seenP || seenW) return SetOverflowFailure(throwOnFailure);
                            ww = (int)lastNum;
                            seenW = true;
                            break;
                        case 'D':
                            if (lastNum == null || !seenP || seenD) return SetOverflowFailure(throwOnFailure);
                            dd = (int)lastNum;
                            seenD = true;
                            break;
                        case 'T':
                            if (!seenP || seenT) return SetOverflowFailure(throwOnFailure);
                            seenT = true;
                            break;
                        case 'H':
                            if (lastNum == null || !seenT || seenH) return SetOverflowFailure(throwOnFailure);
                            hh = (int)lastNum;
                            seenH = true;
                            break;
                        case 'M':
                            if (lastNum == null || !seenT || seenM) return SetOverflowFailure(throwOnFailure);
                            mm = (int)lastNum;
                            seenM = true;
                            break;
                        case 'S':
                            if (lastNum == null || !seenT || seenS) return SetOverflowFailure(throwOnFailure);
                            ss = (int)lastNum;
                            seenS = true;
                            break;
                        default:
                            return SetOverflowFailure(throwOnFailure);
                    }
                    lastNum = null;
                }
                else if (token._ttt == TokenType.Num)
                {
                    lastNum = token._num;
                }
            }

            // Generate the resulting TimeSpan value
            result = new TimeSpan(ww > 0 ? ww * 7 : dd, hh, mm, ss);

            // Negate TimeSpan value if - sign was processed
            if (negate != null && (bool)negate) result = result.Negate();

            return true;
        }

        private ref struct TimeSpanToken
        {
            internal int _num;
            internal char _sep;
            internal TokenType _ttt;

            public TimeSpanToken(TokenType type)
                : this(type, 0, default)
            {
            }

            public TimeSpanToken(TokenType type, int number, char separator)
            {
                _ttt = type;
                _num = number;
                _sep = separator;
            }
        }

        private ref struct TimeSpanTokenizer
        {
            private readonly ReadOnlySpan<char> _value;
            private int _pos;

            internal TimeSpanTokenizer(ReadOnlySpan<char> input)
            {
                _value = input;
                _pos = 0;
            }

            internal bool EOL => _pos >= _value.Length;

            internal TimeSpanToken GetNextToken()
            {
                // Get the position of the next character to be processed. If there is no
                // next character, we're at the end.
                int pos = _pos;
                if (pos >= _value.Length)
                {
                    return new TimeSpanToken(TokenType.End);
                }

                // Now retrieve that character. If it's a digit, we're processing a number.
                int num = _value[pos] - '0';
                if ((uint)num <= 9)
                {
                    if (num == 0)
                    {
                        // Read all leading zeroes.
                        while (true)
                        {
                            int digit;
                            if (++_pos >= _value.Length || (uint)(digit = _value[_pos] - '0') > 9)
                            {
                                return new TimeSpanToken(TokenType.Num, 0, default);
                            }

                            if (digit == 0)
                            {
                                continue;
                            }

                            num = digit;
                            break;
                        }
                    }

                    // Continue to read as long as we're reading digits.
                    while (++_pos < _value.Length)
                    {
                        int digit = _value[_pos] - '0';
                        if ((uint)digit > 9)
                        {
                            break;
                        }

                        num = num * 10 + digit;
                        if ((num & 0xF0000000) != 0)
                        {
                            // Max limit we can support 268435455 which is FFFFFFF
                            return new TimeSpanToken(TokenType.NumOverflow);
                        }
                    }

                    // Return the number
                    return new TimeSpanToken(TokenType.Num, num, default);
                }

                // Otherwise, we're processing a separator, and we've already processed
                // the first character of it. 
                _pos++;

                // Return the separator.
                return new TimeSpanToken(TokenType.Sep, 0, _value[pos]);
            }
        }
    }
}
