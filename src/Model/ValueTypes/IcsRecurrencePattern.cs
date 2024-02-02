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
using System.Collections.Generic;
using System.Text;

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalendar Recurrence Rule value
    /// </summary>
    public class IcsRecurrencePattern
    {
        private readonly IDictionary<string, string> _parameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRecurrencePattern"/> class.
        /// </summary>
        public IcsRecurrencePattern()
        {
            _parameters = new Dictionary<string, string>();
        }

        /// <summary>
        /// Specifies a list of days of the week. Each value can also be preceded by a positive (+n) or 
        /// negative (-n) integer.
        /// </summary>
        public IcsDayRule[] ByDay
        {
            get
            {
                return IcsConverter.ToRRuleByDayArrayOrDefault(GetParameter(IcsParameterNames.ByDay));
            }
            set
            {
                SetParameter(IcsParameterNames.ByDay, IcsConverter.FromRRuleByDayArray(value));
            }
        }

        /// <summary>
        /// Specifies a list of hours of the day.Valid values are 0 to 23.
        /// </summary>
        public byte[] ByHour
        {
            get
            {
                return IcsConverter.ToByteArrayOrDefault(GetParameter(IcsParameterNames.ByHour));
            }
            set
            {
                SetParameter(IcsParameterNames.ByHour, IcsConverter.FromByteArray(value));
            }
        }

        /// <summary>
        /// Specifies a list of minutes within an hour. Valid values are 0 to 59.
        /// </summary>
        public byte[] ByMinute
        {
            get
            {
                return IcsConverter.ToByteArrayOrDefault(GetParameter(IcsParameterNames.ByMinute));
            }
            set
            {
                SetParameter(IcsParameterNames.ByMinute, IcsConverter.FromByteArray(value));
            }
        }

        /// <summary>
        /// Specifies a list of months of the year. Valid values are 1 to 12.
        /// </summary>
        public byte[] ByMonth
        {
            get
            {
                return IcsConverter.ToByteArrayOrDefault(GetParameter(IcsParameterNames.ByMonth));
            }
            set
            {
                SetParameter(IcsParameterNames.ByMonth, IcsConverter.FromByteArray(value));
            }
        }

        /// <summary>
        /// Specifies a COMMAlist of days of the month.Valid values are 1 to 31 or -31 to -1.
        /// </summary>
        public sbyte[] ByMonthDay
        {
            get
            {
                return IcsConverter.ToSByteArrayOrDefault(GetParameter(IcsParameterNames.ByMonthDay));
            }
            set
            {
                SetParameter(IcsParameterNames.ByMonthDay, IcsConverter.FromSByteArray(value));
            }
        }

        /// <summary>
        /// Specifies a list of seconds within a minute.Valid values are 0 to 60. 
        /// </summary>
        public byte[] BySecond
        {
            get
            {
                return IcsConverter.ToByteArrayOrDefault(GetParameter(IcsParameterNames.BySecond));
            }
            set
            {
                SetParameter(IcsParameterNames.BySecond, IcsConverter.FromByteArray(value));
            }
        }

        /// <summary>
        /// Specifies a list of values that corresponds to the nth occurrence within the set of recurrence 
        /// instances specified by the rule.
        /// </summary>
        public short[] BySetPos
        {
            get
            {
                return IcsConverter.ToShortArrayOrDefault(GetParameter(IcsParameterNames.BySetPos));
            }
            set
            {
                SetParameter(IcsParameterNames.BySetPos, IcsConverter.FromShortArray(value));
            }
        }

        /// <summary>
        /// Specifies a list of ordinals specifying weeks of the year.Valid values are 1 to 53 
        /// or -53 to -1.
        /// </summary>
        public sbyte[] ByWeekNumber
        {
            get
            {
                return IcsConverter.ToSByteArrayOrDefault(GetParameter(IcsParameterNames.ByWeekNo));
            }
            set
            {
                SetParameter(IcsParameterNames.ByWeekNo, IcsConverter.FromSByteArray(value));
            }
        }

        /// <summary>
        /// Specifies a list of days of the year.Valid values are 1 to 366 or -366 to -1.
        /// </summary>
        public short[] ByYearDay
        {
            get
            {
                return IcsConverter.ToShortArrayOrDefault(GetParameter(IcsParameterNames.ByYearDay));
            }
            set
            {
                SetParameter(IcsParameterNames.ByYearDay, IcsConverter.FromShortArray(value));
            }
        }

        /// <summary>
        /// Defines the number of occurrences at which to range-bound the recurrence.
        /// </summary>
        public int? Count
        {
            get
            {
                return IcsConverter.ToIntegerOrDefault(GetParameter(IcsParameterNames.Count));
            }
            set
            {
                SetParameter(IcsParameterNames.Count, IcsConverter.FromInteger(value));
            }
        }

        /// <summary>
        /// Identifies the type of recurrence rule. This rule part MUST be specified in the recurrence rule.
        /// </summary>
        public IcsRecurrenceFrequency? Frequency
        {
            get
            {
                return IcsConverter.ToRecurrenceFrequencyOrDefault(GetParameter(IcsParameterNames.Frequency));
            }
            set
            {
                SetParameter(IcsParameterNames.Frequency, IcsConverter.FromRecurrenceFrequency(value));
            }
        }

        /// <summary>
        /// A positive integer representing at which intervals the recurrence rule repeats.
        /// </summary>
        public int? Interval
        {
            get
            {
                return IcsConverter.ToIntegerOrDefault(GetParameter(IcsParameterNames.Interval));
            }
            set
            {
                SetParameter(IcsParameterNames.Interval, IcsConverter.FromInteger(value));
            }
        }

        /// <summary>
        /// Defines a DATE value that bounds the recurrence rule in an inclusive manner.
        /// </summary>
        public DateOnly? UntilAsDate
        {
            get
            {
                return IcsConverter.ToDateOnlyOrDefault(GetParameter(IcsParameterNames.Until));
            }
            set
            {
                SetParameter(IcsParameterNames.Until, IcsConverter.FromDateOnly(value));
            }
        }

        /// <summary>
        /// Defines a DATE-TIME value that bounds the recurrence rule in an inclusive manner.
        /// </summary>
        public DateTime? UntilAsDateTime
        {
            get
            {
                return IcsConverter.ToDateTimeOrDefault(GetParameter(IcsParameterNames.Until));
            }
            set
            {
                SetParameter(IcsParameterNames.Until, IcsConverter.FromDateTime(value));
            }
        }

        /// <summary>
        /// Specifies the day on which the workweek starts.
        /// </summary>
        public DayOfWeek? WeekStart
        {
            get
            {
                return IcsConverter.ToDayOfWeekOrDefault(GetParameter(IcsParameterNames.WeekStart));
            }
            set
            {
                SetParameter(IcsParameterNames.WeekStart, IcsConverter.FromDayOfWeek(value));
            }
        }

        /// <summary>
        /// Converts the specified string representation of an iCalendar Recurrence Rule value 
        /// to its <see cref="IcsRecurrencePattern"/> equivalent.
        /// </summary>
        /// <param name="value">The string representation</param>
        /// <returns>A new <see cref="IcsRecurrencePattern"/> instance</returns>
        public static IcsRecurrencePattern Parse(string value)
        {
            var result = new IcsRecurrencePattern();

            var ruleParts = value.Split(';');

            foreach (var rulePart in ruleParts)
            {
                var paramParts = rulePart.Split('=');

                if (paramParts.Length == 2)
                {
                    result.SetParameter(paramParts[0], paramParts[1]);
                }
                else
                {
                    throw new FormatException($"{value} is not a key=value pattern for a recurrence definition.");
                }
            }

            return result;
        }

        /// <summary>
        /// Removes all parameters from the content line
        /// </summary>
        public void ClearParameters()
        {
            _parameters.Clear();
        }

        /// <summary>
        /// Determines whether content line contains a parameter
        /// with the specified name.
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <returns>TRUE, if determines this parameter</returns>
        public bool ContainsParameter(string name)
        {
            return _parameters.ContainsKey(name);
        }

        /// <summary>
        /// Gives back value of a named parameter
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <returns>The value of the parameter</returns>
        public string GetParameter(string name)
        {
            if (_parameters.TryGetValue(name, out var value))
            {
                return value;
            }
            else
            {
                return default;
            }
        }

        /// <summary>
        /// Gives back the total number of parameters 
        /// </summary>
        /// <returns>The total number of parameters</returns>
        public int GetParameterCount()
        {
            return _parameters.Count;
        }

        /// <summary>
        /// Is value type of UNTIL a DATE?
        /// </summary>
        /// <returns>TRUE, if value type is DATE</returns>
        public bool IsDate()
        {
            var p = GetParameter(IcsParameterNames.Until);
            return p != null && !p.Contains('T');
        }

        /// <summary>
        /// Is value type of UNTIL a DATE-TIME?
        /// </summary>
        /// <returns>TRUE, if value type is DATE-TIME</returns>
        public bool IsDateTime()
        {
            var p = GetParameter(IcsParameterNames.Until);
            return p != null && p.Contains('T');
        }

        /// <summary>
        /// Removes a parameter from the content line
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        public void RemoveParameter(string name)
        {
            if (_parameters.ContainsKey(name))
            {
                _parameters.Remove(name);
            }
        }

        /// <summary>
        /// Sets the value of a named parameter
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The value of the parameter</param>
        public void SetParameter(string name, string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (_parameters.ContainsKey(name))
            {
                _parameters[name] = value;
            }
            else
            {
                _parameters.Add(name, value);
            }
        }

        /// <summary>
        /// Gives back the complete Recurrence Rule value as string.
        /// </summary>
        /// <returns>The complete Recurrence Rule value as string</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var parmeter in _parameters)
            {
                if (sb.Length > 0) sb.Append(';');

                sb.Append(parmeter.Key);
                sb.Append('=');
                sb.Append(parmeter.Value);
            }

            return sb.ToString();
        }
    }
}
