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
    /// Represents an iCalendar content line
    /// </summary>
    public class IcsContentLine
    {
        private static readonly int DefaultLineFoldingLength = 75;
        private static readonly string LineFoldingInsert = $"{Environment.NewLine} ";
        private readonly IDictionary<string, string> _parameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsContentLine"/> class.
        /// </summary>
        public IcsContentLine()
        {
            _parameters = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsContentLine"/> class.
        /// </summary>
        /// <param name="name">A content line name</param>
        public IcsContentLine(string name)
            : this()
        {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IcsContentLine"/> class.
        /// </summary>
        /// <param name="name">A content line name</param>
        /// <param name="value">A content line value</param>
        public IcsContentLine(string name, string value)
            : this(name)
        {
            Value = value;
        }

        /// <summary>
        /// Defines the name of the content line.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Defines the value of the content line.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// A static function that converts a name/value pair into a content line.
        /// </summary>
        /// <param name="name">Name of the content line</param>
        /// <param name="value">Value of the content line</param>
        /// <returns>The resulting content line</returns>
        public static string ToString(string name, string value)
        {
            var line = new IcsContentLine(name, value);
            return line.ToString();
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
        /// Gives back the complete content line as folded, quoted and escaped string.
        /// </summary>
        /// <returns>The complete content line as string</returns>
        public override string ToString()
        {
            return ToString(DefaultLineFoldingLength);
        }

        /// <summary>
        /// Gives back the complete content line as folded, quoted and escaped string.
        /// </summary>
        /// <param name="lineFoldingLength">The number of characters from which line folding 
        /// should be applied.</param>
        /// <returns>The complete content line as string</returns>
        public string ToString(int lineFoldingLength)
        {
            var sb = new StringBuilder();

            sb.Append(Name);
            foreach (var parameter in _parameters)
            {
                sb.Append(';');
                sb.Append(parameter.Key);
                sb.Append('=');
                if (parameter.Value.IndexOfAny(new char[] { '"', ';', ':', ',' }) != -1)
                {
                    sb.Append('"');
                    sb.Append(parameter.Value.Escape());
                    sb.Append('"');
                }
                else
                {
                    sb.Append(parameter.Value.Escape());
                }
            }
            sb.Append(':');
            sb.Append(Value.Escape());

            if (sb.Length > lineFoldingLength)
            {
                int i = lineFoldingLength;
                int l;
                do
                {
                    sb.Insert(i, LineFoldingInsert);
                    l = i;
                    i += lineFoldingLength + LineFoldingInsert.Length;
                }
                while (sb.Length - l > lineFoldingLength);
            }

            return sb.ToString();
        }
    }
}
