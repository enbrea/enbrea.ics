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
using System.Text;

namespace Enbrea.Ics
{
    /// <summary>
    /// Extensions for <see cref="string"/>
    /// </summary>
    public static class StringExtensions
    {
        public static string Escape(this string value)
        {
            // If the string is empty, we can return it as is
            if (value.Length == 0) return value;

            // Check if escaping is required
            var requiresEscaping = false;
            
            for (var i = 0; i < value.Length; i++)
            {
                var c = value[i];
                if (c == ',' || c == ';' || c == '\\' || c == '\n' || c == '\r')
                {
                    requiresEscaping = true;
                    break;
                }
            }

            if (!requiresEscaping) return value;

            // Escaping is required, so we create a new string with the escaped characters
            var sb = new StringBuilder(value.Length);

            for (var i = 0; i < value.Length; i++)
            {
                switch (value[i])
                {
                    case ',': 
                        sb.Append(@"\,"); 
                        break;
                    case ';': 
                        sb.Append(@"\;"); 
                        break;
                    case '\\': 
                        sb.Append(@"\\"); 
                        break;
                    case '\n':
                        if ((i == 0) || (value[i - 1] != '\r')) sb.Append(@"\n");
                        break;
                    case '\r':
                        if ((i == 0) || (value[i - 1] != '\n')) sb.Append(@"\n"); 
                        break;
                    default:
                        sb.Append(value[i]);
                        break;
                }
            }
            return sb.ToString();
        }

        public static string UnEscape(this string value)
        {
            // If the string is empty or has only one character, we can return it as is
            if (value.Length <= 1) return value;

            // Check if unescaping is required
            if (!value.Contains('\\')) return value;

            // Unescaping is required, so we create a new string with the unescaped characters
            var sb = new StringBuilder(value.Length);

            for (var i = 0; i < value.Length; i++)
            {
                if (value[i] == '\\')
                {
                    if (i < value.Length - 1)
                    {
                        switch (value[i + 1])
                        {
                            case ',':
                                sb.Append(',');
                                i++;
                                break;
                            case ';':
                                sb.Append(';');
                                i++;
                                break;
                            case 'n':
                            case 'N':
                                sb.Append(Environment.NewLine);
                                i++;
                                break;
                            case '\\':
                                sb.Append('\\');
                                i++;
                                break;
                            default:
                                sb.Append(value[i]);
                                break;
                        }
                    }
                }
                else
                {
                    sb.Append(value[i]);
                }
            }
            return sb.ToString();
        }
    }
}
