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
    /// Represents an iCalendar Geographic Position value.
    /// </summary>
    public struct IcsGeoPosition : IEquatable<IcsGeoPosition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsGeoPosition"/> struct.
        /// </summary>
        /// <param name="latitude">Latitude value</param>
        /// <param name="longitude">Longitude value</param>
        public IcsGeoPosition(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Latitude value
        /// </summary>
        public double Latitude { get; internal set; }

        /// <summary>
        /// The longitude represents the location east or west of the prime meridian as a
        /// positive or negative real number, respectively.
        /// </summary>
        public double Longitude { get; internal set; }

        /// <summary>
        /// Determines whether two specified instances of <see cref="IcsGeoPosition"/> are not equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>TRUE if left and right do not represent the same content; otherwise, FALSE.</returns>
        public static bool operator !=(IcsGeoPosition left, IcsGeoPosition right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="IcsGeoPosition"/> are equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>TRUE if left and right do represent the same content; otherwise, FALSE.</returns>
        public static bool operator ==(IcsGeoPosition left, IcsGeoPosition right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts the specified string representation of an iCalendar geographic position 
        /// value to its <see cref="IcsGeoPosition"/> equivalent.
        /// </summary>
        /// <param name="value">The string representation</param>
        /// <returns>A <see cref="IcsGeoPosition"/> instance</returns>
        public static IcsGeoPosition Parse(string value)
        {
            var parts = value.Split(';');

            if (parts.Length == 2)
            {
                return new IcsGeoPosition(double.Parse(parts[0], CultureInfo.InvariantCulture), double.Parse(parts[1], CultureInfo.InvariantCulture));
            }
            else
            {
                throw new FormatException($"{value} is not a valid geographic position.");
            }
        }

        /// <summary>
        /// Returns a value indicating whether the value of this instance is equal to the value 
        /// of the specified <see cref="IcsGeoPosition"/> instance.
        /// </summary>
        /// <param name="other">The object to compare to this instance.</param>
        /// <returns>
        /// True if the value parameter equals the value of this instance; otherwise, false.
        /// </returns>
        public bool Equals(IcsGeoPosition other)
        {
            return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare to this instance.</param>
        /// <returns>
        /// True if value is an instance of <see cref="IcsGeoPosition"/> and equals the value 
        /// of this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is IcsGeoPosition other && Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Latitude, Longitude);
        }

        /// <summary>
        /// Converts the value of the current <see cref="IcsGeoPosition"/> object to its 
        /// equivalent string representation.
        /// </summary>
        /// <returns>A string that contains the string representation.</returns>        
        public override string ToString()
        {
            return string.Join(';', IcsConverter.FromFloat(Latitude), IcsConverter.FromFloat(Longitude));
        }
    }
}