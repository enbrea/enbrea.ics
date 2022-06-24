#region enbrea.ics copyright (c) 2022 stüber systems gmbh
/*    
 *    enbrea.ics 
 *    
 *    copyright (c) 2022 stüber systems gmbh
 *
 *    licensed under the mit license, version 2.0. 
 * 
 */
#endregion

using System;

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalendar PERIOD value
    /// </summary>
    public struct IcsPeriod : IEquatable<IcsPeriod>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsPeriod"/> struct.
        /// </summary>
        /// <param name="startDateTime">Start DATE-TIME</param>
        /// <param name="endDateTime">End DATE-TIME</param>
        public IcsPeriod(DateTime startDateTime, DateTime endDateTime)
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Duration = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsPeriod"/> struct.
        /// </summary>
        /// <param name="startDateTime">Start DATE-TIME</param>
        /// <param name="duration">A duration</param>
        public IcsPeriod(DateTime startDateTime, TimeSpan duration)
        {
            StartDateTime = startDateTime;
            EndDateTime = null;
            Duration = duration;
        }

        /// <summary>
        /// Duration
        /// </summary>
        public TimeSpan? Duration { get; internal set; }

        /// <summary>
        /// End DATE-TIME
        /// </summary>
        public DateTime? EndDateTime { get; internal set; }

        /// <summary>
        /// Start DATE-TIME
        /// </summary>
        public DateTime StartDateTime { get; internal set; }

        /// <summary>
        /// Determines whether two specified instances of <see cref="IcsPeriod"/> are not equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>TRUE if left and right do not represent the same content; otherwise, FALSE.</returns>
        public static bool operator !=(IcsPeriod left, IcsPeriod right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="IcsPeriod"/> are equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>TRUE if left and right do represent the same content; otherwise, FALSE.</returns>
        public static bool operator ==(IcsPeriod left, IcsPeriod right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts the specified string representation of an iCalendar period of time value 
        /// to its <see cref="IcsPeriod"/> equivalent.
        /// </summary>
        /// <param name="value">The string representation</param>
        /// <returns>A <see cref="IcsPeriod"/> instance</returns>
        public static IcsPeriod Parse(string value)
        {
            var parts = value.Split('/');

            if (parts.Length == 2)
            {
                if (parts[1].StartsWith("+P") || parts[1].StartsWith("P"))
                {
                    return new IcsPeriod(
                        IcsConverter.ToDateTime(parts[0]),
                        IcsConverter.ToDateTime(parts[1]));
                }
                else
                {
                    return new IcsPeriod(
                        IcsConverter.ToDateTime(parts[0]),
                        IcsConverter.ToTimeSpan(parts[1]));
                }
            }
            else
            {
                throw new FormatException($"{value} is not a valid period.");
            }
        }

        /// <summary>
        /// Returns a value indicating whether the value of this instance is equal to the value 
        /// of the specified <see cref="IcsPeriod"/> instance.
        /// </summary>
        /// <param name="other">The object to compare to this instance.</param>
        /// <returns>
        /// True if the value parameter equals the value of this instance; otherwise, false.
        /// </returns>
        public bool Equals(IcsPeriod other)
        {
            return StartDateTime.Equals(other.StartDateTime) && EndDateTime.Equals(other.EndDateTime);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare to this instance.</param>
        /// <returns>
        /// True if value is an instance of <see cref="IcsPeriod"/> and equals the value 
        /// of this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is IcsPeriod other && Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(StartDateTime, EndDateTime, Duration);
        }

        /// <summary>
        /// Has a duration value?
        /// </summary>
        /// <returns>TRUE if duration value exists; otherwise, FALSE.</returns>
        public bool HasDuration()
        {
            return Duration != null;
        }

        /// <summary>
        /// Has an end DATE-TIME value?
        /// </summary>
        /// <returns>TRUE if DATE-TIME value exists; otherwise, FALSE.</returns>
        public bool HasEndDateTime()
        {
            return EndDateTime != null;
        }

        /// <summary>
        /// Converts the value of the current <see cref="IcsPeriod"/> object to its 
        /// equivalent string representation.
        /// </summary>
        /// <returns>A string that contains the string representation.</returns>        
        public override string ToString()
        {
            if (HasEndDateTime())
            {
                return string.Join('/', IcsConverter.FromDateTime(StartDateTime), IcsConverter.FromDateTime(EndDateTime));
            }
            else
            {
                return string.Join('/', IcsConverter.FromDateTime(StartDateTime), IcsConverter.FromTimeSpan(Duration));
            }
        }
    }
}