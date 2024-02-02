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
            if (value.Length == 0) return value;

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
            if (value.Length <= 1) return value;

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
