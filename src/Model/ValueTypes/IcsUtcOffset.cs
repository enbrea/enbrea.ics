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
    /// Represents an iCalendar UTC Offset value.
    /// </summary>
    public struct IcsUtcOffset : IEquatable<IcsUtcOffset>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsUtcOffset"/> struct.
        /// </summary>
        /// <param name="value">A time span value</param>
        public IcsUtcOffset(TimeSpan value)
        {
            Value = value;
        }

        /// <summary>
        /// The time span value
        /// </summary>
        public TimeSpan Value { get; internal set; }

        /// <summary>
        /// Determines whether two specified instances of <see cref="IcsUtcOffset"/>are not equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>TRUE if left and right do not represent the same content; otherwise, FALSE.</returns>
        public static bool operator !=(IcsUtcOffset left, IcsUtcOffset right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="IcsUtcOffset"/>are equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>TRUE if left and right do represent the same content; otherwise, FALSE.</returns>
        public static bool operator ==(IcsUtcOffset left, IcsUtcOffset right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts the specified string representation of an iCalendar utc offset to 
        /// its <see cref="TimeSpan"/> equivalent.
        /// </summary>
        /// <param name="value">The string representation</param>
        /// <returns>A <see cref="IcsUtcOffset"/> instance</returns>
        public static IcsUtcOffset Parse(string value)
        {
            if (value.Length == 5)
            {
                var timeSpanValue = TimeSpan.ParseExact(value.Substring(1, 4), "mmss", CultureInfo.InvariantCulture);
                return new IcsUtcOffset((value[0] == '-') ? timeSpanValue.Negate() : timeSpanValue);
            }
            else
            {
                throw new FormatException($"{value} is not a valid utc offset.");
            }
        }

        /// <summary>
        /// Returns a value indicating whether the value of this instance is equal to the value 
        /// of the specified <see cref="IcsUtcOffset"/> instance.
        /// </summary>
        /// <param name="other">The object to compare to this instance.</param>
        /// <returns>
        /// True if the value parameter equals the value of this instance; otherwise, false.
        /// </returns>
        public bool Equals(IcsUtcOffset other)
        {
            return Value.Equals(other.Value);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare to this instance.</param>
        /// <returns>
        /// True if value is an instance of <see cref="IcsUtcOffset"/> and equals the value 
        /// of this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is IcsUtcOffset other && Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        /// <summary>
        /// Converts the value of the current <see cref="IcsUtcOffset"/> object to its 
        /// equivalent string representation.
        /// </summary>
        /// <returns>A string that contains the string representation.</returns>        
        public override string ToString()
        {
            return (Value < TimeSpan.Zero) ?
               Value.ToString(@"\-mmss", CultureInfo.InvariantCulture) :
               Value.ToString(@"\+mmss", CultureInfo.InvariantCulture);
        }
    }
}