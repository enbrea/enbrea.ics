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
using System.IO;
using System.Text;

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalender BYDAY recurrence rule part value
    /// </summary>
    public struct IcsDayRule : IEquatable<IcsDayRule>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsDayRule"/> struct.
        /// </summary>
        /// <param name="dayOfWeek">A day of the week</param>
        public IcsDayRule(DayOfWeek dayOfWeek)
            : this(dayOfWeek, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsDayRule"/> struct.
        /// </summary>
        /// <param name="dayOfWeek">A day of the week</param>
        /// <param name="occurrence"></param>
        public IcsDayRule(DayOfWeek dayOfWeek, sbyte? occurrence)
        {
            DayOfWeek = dayOfWeek;
            Occurrence = occurrence;
        }

        /// <summary>
        /// A day of the week
        /// </summary>
        public DayOfWeek DayOfWeek { get; internal set; }

        /// <summary>
        /// Indicates the nth occurrence of a specific day within a MONTHLY or 
        /// YEARLY rule
        /// </summary>
        public sbyte? Occurrence { get; internal set; }

        /// <summary>
        /// Determines whether two specified instances of <see cref="IcsDayRule"/> are not equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>TRUE if left and right do not represent the same content; otherwise, FALSE.</returns>
        public static bool operator !=(IcsDayRule left, IcsDayRule right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="IcsDayRule"/> are equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>TRUE if left and right do represent the same content; otherwise, FALSE.</returns>
        public static bool operator ==(IcsDayRule left, IcsDayRule right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts the specified string representation of an iCalendar rule part value 
        /// to its <see cref="IcsDayRule"/> equivalent.
        /// </summary>
        /// <param name="value">The string representation</param>
        /// <returns>A new <see cref="IcsDayRule"/> instance</returns>
        public static IcsDayRule Parse(string value)
        {
            if (value != null)
            {
                if (value.Length < 2)
                {
                    throw new InvalidDataException("Invalid BYDAY value.");
                }
                else if (value.Length > 2)
                {
                    return new IcsDayRule(
                        IcsConverter.ToDayOfWeek(value.Substring(value.Length - 2, 2)),
                        sbyte.Parse(value.Substring(0, value.Length - 2)));
                }
                else 
                {
                    return new IcsDayRule(IcsConverter.ToDayOfWeek(value));
                }
            }
            else
            {
                throw new InvalidDataException("BYDAY value is empty.");
            }
        }

        /// <summary>
        /// Returns a value indicating whether the value of this instance is equal to the value 
        /// of the specified <see cref="IcsDayRule"/> instance.
        /// </summary>
        /// <param name="other">The object to compare to this instance.</param>
        /// <returns>
        /// True if the value parameter equals the value of this instance; otherwise, false.
        /// </returns>
        public bool Equals(IcsDayRule other)
        {
            return DayOfWeek.Equals(other.DayOfWeek) && Occurrence.Equals(other.Occurrence);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare to this instance.</param>
        /// <returns>
        /// True if value is an instance of <see cref="IcsDayRule"/> and equals the value 
        /// of this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is IcsDayRule other && Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(DayOfWeek, Occurrence);
        }

        /// <summary>
        /// Converts the value of the current <see cref="IcsDayRule"/> object to its 
        /// equivalent string representation.
        /// </summary>
        /// <returns>A string that contains the string representation.</returns>        
        public override string ToString()
        {
            var sb = new StringBuilder();

            if (Occurrence != null)
            {
                sb.Append(Occurrence.ToString());
            }

            sb.Append(IcsConverter.FromDayOfWeek(DayOfWeek));

            return sb.ToString();
        }
    }
}
