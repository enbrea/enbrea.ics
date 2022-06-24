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
    /// Represents an iCalendar Request Status value
    /// </summary>
    public struct IcsRequestStatusValue : IEquatable<IcsRequestStatusValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsRequestStatusValue"/> struct.
        /// </summary>
        /// <param name="code">A status code</param>
        /// <param name="description">A status description</param>
        /// <param name="extraData">Optional extra data</param>
        public IcsRequestStatusValue(string code, string description, string extraData = null)
        {
            Code = code;
            Description = description;
            ExtraData = extraData; 
        }

        /// <summary>
        /// Status code
        /// </summary>
        public string Code { get; internal set; }

        /// <summary>
        /// Status description
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// Optional extra data 
        /// </summary>
        public string ExtraData { get; internal set; }

        /// <summary>
        /// Determines whether two specified instances of <see cref="IcsRequestStatusValue"/> are not equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>TRUE if left and right do not represent the same content; otherwise, FALSE.</returns>
        public static bool operator !=(IcsRequestStatusValue left, IcsRequestStatusValue right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="IcsRequestStatusValue"/> are equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>TRUE if left and right do represent the same content; otherwise, FALSE.</returns>
        public static bool operator ==(IcsRequestStatusValue left, IcsRequestStatusValue right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts the specified string representation of an iCalendar request status value to 
        /// its <see cref="IcsRequestStatusValue"/> equivalent.
        /// </summary>
        /// <param name="value">The string representation</param>
        /// <returns>A <see cref="IcsRequestStatusValue"/> instance</returns>
        public static IcsRequestStatusValue Parse(string value)
        {
            var parts = value.Split(';');

            if (parts.Length == 2)
            {
                return new IcsRequestStatusValue(parts[0], parts[1]);
            }
            else if (parts.Length == 3)
            {
                return new IcsRequestStatusValue(parts[0], parts[1], parts[2]);
            }
            else
            {
                throw new FormatException($"{value} is not a valid request status.");
            }
        }

        /// <summary>
        /// Returns a value indicating whether the value of this instance is equal to the value 
        /// of the specified <see cref="IcsRequestStatusValue"/> instance.
        /// </summary>
        /// <param name="other">The object to compare to this instance.</param>
        /// <returns>
        /// True if the value parameter equals the value of this instance; otherwise, false.
        /// </returns>
        public bool Equals(IcsRequestStatusValue other)
        {
            return Code.Equals(other.Code) && Description.Equals(other.Description) && ExtraData.Equals(other.ExtraData);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare to this instance.</param>
        /// <returns>
        /// True if value is an instance of <see cref="IcsRequestStatusValue"/> and equals the value 
        /// of this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is IcsRequestStatusValue other && Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Code, Description, ExtraData);
        }

        /// <summary>
        /// Converts the value of the current <see cref="IcsRequestStatusValue"/> object to its 
        /// equivalent string representation.
        /// </summary>
        /// <returns>A string that contains the string representation.</returns>        
        public override string ToString()
        {
            return string.Join(';', Code, Description, ExtraData);
        }
    }
}