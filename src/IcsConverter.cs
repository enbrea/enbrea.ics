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
using System.Text;

namespace Enbrea.Ics
{
    /// <summary>
    /// A static class hosting converter methods for various value types 
    /// </summary>
    public static class IcsConverter
    {
        public static string FromActionValue(IcsActionValue? value)
        {
            if (value != null)
            {
                return value switch
                {
                    IcsActionValue.Audio => "AUDIO",
                    IcsActionValue.Display => "DISPLAY",
                    IcsActionValue.Email => "EMAIL",
                    _ => default
                };
            }
            else
            {
                return default;
            }
        }

        public static string FromBinary(byte[] value)
        {
            return Convert.ToBase64String(value);
        }

        public static string FromBoolean(bool? value)
        {
            if (value != null)
            {
                return (bool)value ? "TRUE" : "FALSE";
            }
            else
            {
                return default;
            }
        }

        public static string FromByte(byte? value)
        {
            if (value != null)
            {
                return value.ToString();
            }
            else
            {
                return default;
            }
        }

        public static string FromByteArray(byte[] values)
        {
            return string.Join(',', values);
        }

        public static string FromClassificationValue(IcsClassificationValue? value)
        {
            if (value != null)
            {
                return value switch
                {
                    IcsClassificationValue.Public => "PUBLIC",
                    IcsClassificationValue.Private => "PRIVATE",
                    IcsClassificationValue.Confidential => "CONFIDENTIAL",
                    _ => default
                };
            }
            else
            {
                return default;
            }
        }

        public static string FromDateOnly(DateOnly? value)
        {
            if (value != null)
            {
                return value?.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
            }
            else
            {
                return default;
            }
        }

        public static string FromDateOnlyArray(DateOnly[] values)
        {
            return string.Join(',', values);
        }

        public static string FromDateTime(DateTime? value)
        {
            if (value != null)
            {
                if (value?.Kind == DateTimeKind.Utc)
                {
                    return value?.ToString("yyyyMMdd'T'HHmmss'Z'", CultureInfo.InvariantCulture);
                }
                else
                {
                    return value?.ToString("yyyyMMdd'T'HHmmss", CultureInfo.InvariantCulture);
                }
            }
            else
            {
                return default;
            }
        }

        public static string FromDateTimeArray(DateTime[] values)
        {
            return string.Join(',', values);
        }

        public static string FromDayOfWeek(DayOfWeek? value)
        {
            if (value != null)
            {
                return value switch
                {
                    DayOfWeek.Monday => "MO",
                    DayOfWeek.Tuesday => "TU",
                    DayOfWeek.Wednesday => "WE",
                    DayOfWeek.Thursday => "TH",
                    DayOfWeek.Friday => "FR",
                    DayOfWeek.Saturday => "SA",
                    DayOfWeek.Sunday => "SU",
                    _ => default
                };
            }
            else
            {
                return default;
            }
        }

        public static string FromEventParticipationStatus(IcsEventParticipationStatus? value)
        {
            if (value != null)
            {
                return value switch
                {
                    IcsEventParticipationStatus.NeedsAction => "NEEDS-ACTION",
                    IcsEventParticipationStatus.Accepted => "ACCEPTED",
                    IcsEventParticipationStatus.Tentative => "TENTATIVE",
                    IcsEventParticipationStatus.Delegated => "DELEGATED",
                    _ => default
                };
            }
            else
            {
                return default;
            }
        }

        public static string FromEventStatusValue(IcsEventStatusValue? value)
        {
            if (value != null)
            {
                return value switch
                {
                    IcsEventStatusValue.Tentative => "TENTATIVE",
                    IcsEventStatusValue.Confirmed => "CONFIRMED",
                    IcsEventStatusValue.Cancelled => "CANCELLED",
                    _ => default
                };
            }
            else
            {
                return default;
            }
        }

        public static string FromFloat(double? value)
        {
            if (value != null)
            {
                return value?.ToString("0.000000", CultureInfo.InvariantCulture.NumberFormat);
            }
            else
            {
                return default;
            }
        }

        public static string FromFreeBusyType(IcsFreeBusyType? value)
        {
            if (value != null)
            {
                return value switch
                {
                    IcsFreeBusyType.Busy => "BUSY",
                    IcsFreeBusyType.Free => "FREE",
                    IcsFreeBusyType.BusyUnavailable => "BUSY-UNAVAILABLE",
                    IcsFreeBusyType.BusyTentative => "BUSY-TENTATIVE",
                    _ => default
                };
            }
            else
            {
                return default;
            }
        }

        public static string FromGeoPosition(IcsGeoPosition? value)
        {
            if (value != null)
            {
                return $"{value?.Latitude};{value?.Longitude}";
            }
            else
            {
                return default;
            }
        }

        public static string FromInteger(int? value)
        {
            if (value != null)
            {
                return value.ToString();
            }
            else
            {
                return default;
            }
        }

        public static string FromJournalParticipationStatus(IcsJournalParticipationStatus? value)
        {
            if (value != null)
            {
                return value switch
                {
                    IcsJournalParticipationStatus.NeedsAction => "NEEDS-ACTION",
                    IcsJournalParticipationStatus.Accepted => "ACCEPTED",
                    IcsJournalParticipationStatus.Declined => "DECLINED",
                    _ => default
                };
            }
            else
            {
                return default;
            }
        }

        public static string FromJournalStatusValue(IcsJournalStatusValue? value)
        {
            if (value != null)
            {
                return value switch
                {
                    IcsJournalStatusValue.Draft => "DRAFT",
                    IcsJournalStatusValue.Final => "FINAL",
                    IcsJournalStatusValue.Cancelled => "CANCELLED",
                    _ => default
                };
            }
            else
            {
                return default;
            }
        }

        public static string FromParticipationRole(IcsParticipationRole? value)
        {
            if (value != null)
            {
                return value switch
                {
                    IcsParticipationRole.Chair => "CHAIR",
                    IcsParticipationRole.Required => "REQ-PARTICIPANT",
                    IcsParticipationRole.Optional => "OPT-PARTICIPANT",
                    IcsParticipationRole.None => "NON-PARTICIPANT",
                    _ => default
                };
            }
            else
            {
                return default;
            }
        }

        public static string FromPeriodArray(IcsPeriod[] values)
        {
            return string.Join(',', values);
        }

        public static string FromRecurrenceFrequency(IcsRecurrenceFrequency? value)
        {
            if (value != null)
            {
                return value switch
                {
                    IcsRecurrenceFrequency.Secondly => "SECONDLY",
                    IcsRecurrenceFrequency.Minutely => "MINUTELY",
                    IcsRecurrenceFrequency.Hourly => "HOURLY",
                    IcsRecurrenceFrequency.Daily => "DAILY",
                    IcsRecurrenceFrequency.Weekly => "WEEKLY",
                    IcsRecurrenceFrequency.Monthly => "MONTHLY",
                    IcsRecurrenceFrequency.Yearly => "YEARLY",
                    _ => throw new NotImplementedException(),
                };
            }
            else
            {
                return default;
            }
        }

        public static string FromRecurrencePattern(IcsRecurrencePattern value)
        {
            if (value != null)
            {
                return value.ToString();
            }
            else
            {
                return default;
            }
        }

        public static string FromRelationshipType(IcsRelationshipType? value)
        {
            if (value != null)
            {
                return value switch
                {
                    IcsRelationshipType.Parent => "PARENT",
                    IcsRelationshipType.Child => "CHILD",
                    IcsRelationshipType.Sibling => "SIBLING",
                    _ => throw new NotImplementedException(),
                };
            }
            else
            {
                return default;
            }
        }

        public static string FromRelationshipValue(IcsTriggerRelationship? value)
        {
            if (value != null)
            {
                return value switch
                {
                    IcsTriggerRelationship.Start => "START",
                    IcsTriggerRelationship.End => "END",
                    _ => throw new NotImplementedException(),
                };
            }
            else
            {
                return default;
            }
        }

        public static string FromRequestStatusValue(IcsRequestStatusValue? value)
        {
            if (value != null)
            {
                return value.ToString();
            }
            else
            {
                return default;
            }
        }

        public static string FromRRuleByDayArray(IcsDayRule[] values)
        {
            return string.Join(',', values);
        }

        public static string FromSByteArray(sbyte[] values)
        {
            return string.Join(',', values);
        }

        public static string FromShortArray(short[] values)
        {
            return string.Join(',', values);
        }

        public static string FromStringArray(string[] values)
        {
            return string.Join(',', values);
        }

        public static string FromTimeSpan(TimeSpan? value)
        {
            // This slightly modified convertion was taken from:
            // https://github.com/rianjs/ical.net/blob/6c03c42bd9e040622ffaa240be856dc531a20823/src/Ical.Net/Serialization/DataTypes/TimeSpanSerializer.cs
            if (value != null)
            {
                if (value == TimeSpan.Zero)
                {
                    return "P0D";
                }

                var sb = new StringBuilder();

                if (value < TimeSpan.Zero)
                {
                    sb.Append('-');
                }

                sb.Append('P');

                if (value?.Days > 7 && value?.Days % 7 == 0 && value?.Hours == 0 && value?.Minutes == 0 && value?.Seconds == 0)
                {
                    sb.Append(Math.Abs((int)(value?.Days / 7)) + 'W');
                }
                else
                {
                    if (value?.Days != 0)
                    {
                        sb.Append(Math.Abs((int)value?.Days) + 'D');
                    }
                    if (value?.Hours != 0 || value?.Minutes != 0 || value?.Seconds != 0)
                    {
                        sb.Append('T');

                        if (value?.Hours != 0)
                        {
                            sb.Append(Math.Abs((int)value?.Hours) + 'H');
                        }
                        if (value?.Minutes != 0)
                        {
                            sb.Append(Math.Abs((int)value?.Minutes) + 'M');
                        }
                        if (value?.Seconds != 0)
                        {
                            sb.Append(Math.Abs((int)value?.Seconds) + 'S');
                        }
                    }
                }

                return sb.ToString();
            }
            else
            {
                return default;
            }
        }

        public static string FromTodoParticipationStatus(IcsTodoParticipationStatus? value)
        {
            if (value != null)
            {
                return value switch
                {
                    IcsTodoParticipationStatus.NeedsAction => "NEEDS-ACTION",
                    IcsTodoParticipationStatus.Accepted => "ACCEPTED",
                    IcsTodoParticipationStatus.Declined => "DECLINED",
                    IcsTodoParticipationStatus.Tentative => "TENTATIVE",
                    IcsTodoParticipationStatus.Delegated => "DELEGATED",
                    IcsTodoParticipationStatus.Completed => "COMPLETED",
                    IcsTodoParticipationStatus.InProcess => "IN-PROCESS",
                    _ => throw new NotImplementedException(),
                };
            }
            else
            {
                return default;
            }
        }

        public static string FromTodoStatusValue(IcsTodoStatusValue? value)
        {
            if (value != null)
            {
                return value switch
                {
                    IcsTodoStatusValue.NeedsAction => "NEEDS-ACTION",
                    IcsTodoStatusValue.Completed => "COMPLETED",
                    IcsTodoStatusValue.InProcess => "IN-PROCESS",
                    IcsTodoStatusValue.Cancelled => "CANCELLED",
                    _ => throw new NotImplementedException(),
                };
            }
            else
            {
                return default;
            }
        }

        public static string FromTransparencyValue(IcsTransparencyType? value)
        {
            if (value != null)
            {
                return value switch
                {
                    IcsTransparencyType.Opaque => "OPAQUE",
                    IcsTransparencyType.Transparent => "TRANSPARENT",
                    _ => throw new NotImplementedException(),
                };
            }
            else
            {
                return default;
            }
        }

        public static string FromUri(Uri value)
        {
            return value.ToString();
        }

        public static string FromUserType(IcsUserType? value)
        {
            if (value != null)
            {
                return value switch
                {
                    IcsUserType.Individual => "INDIVIDUAL",
                    IcsUserType.Group => "GROUP",
                    IcsUserType.Room => "ROOM",
                    IcsUserType.Resource => "RESOURCE",
                    _ => throw new NotImplementedException(),
                };
            }
            else
            {
                return default;
            }
        }

        public static string FromUtcOffset(IcsUtcOffset? value)
        {
            if (value != null)
            {
                return value.ToString();
            }
            else
            {
                return default;
            }
        }

        public static IcsActionValue? ToActionValueOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "AUDIO", StringComparison.OrdinalIgnoreCase)) return IcsActionValue.Audio;
                if (string.Equals(value, "DISPLAY", StringComparison.OrdinalIgnoreCase)) return IcsActionValue.Display;
                if (string.Equals(value, "EMAIL", StringComparison.OrdinalIgnoreCase)) return IcsActionValue.Email;

                return IcsActionValue.Unknown;
            }
            else
            {
                return default;
            }
        }

        public static byte[] ToBinaryOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return Convert.FromBase64String(value);
            }
            else
            {
                return default;
            }
        }

        public static bool? ToBoolean(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "TRUE", StringComparison.OrdinalIgnoreCase)) return true;
                if (string.Equals(value, "FALSE", StringComparison.OrdinalIgnoreCase)) return false;

                throw new NotImplementedException();
            }
            else
            {
                return default;
            }
        }

        public static byte ToByte(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return byte.Parse(value);
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static byte[] ToByteArrayOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var span = value.AsSpan();
                var result = new byte[CountCommaSeparatedValues(span)];
                var resultIndex = 0;
                var start = 0;

                for (var i = 0; i <= span.Length; i++)
                {
                    if (i == span.Length || span[i] == ',')
                    {
                        result[resultIndex++] = byte.Parse(span[start..i]);
                        start = i + 1;
                    }
                }

                return result;
            }
            else
            {
                return default;
            }
        }

        public static IcsClassificationValue ToClassificationValue(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "PUBLIC", StringComparison.OrdinalIgnoreCase)) return IcsClassificationValue.Public;
                if (string.Equals(value, "PRIVATE", StringComparison.OrdinalIgnoreCase)) return IcsClassificationValue.Private;
                if (string.Equals(value, "CONFIDENTIAL", StringComparison.OrdinalIgnoreCase)) return IcsClassificationValue.Confidential;

                return IcsClassificationValue.Unknown;
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static DateOnly ToDateOnly(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return DateOnly.ParseExact(value, "yyyyMMdd", CultureInfo.InvariantCulture);
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static DateOnly[] ToDateOnlyArrayOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var span = value.AsSpan();
                var result = new DateOnly[CountCommaSeparatedValues(span)];
                var resultIndex = 0;
                var start = 0;

                for (var i = 0; i <= span.Length; i++)
                {
                    if (i == span.Length || span[i] == ',')
                    {
                        result[resultIndex++] = DateOnly.ParseExact(span[start..i], "yyyyMMdd", CultureInfo.InvariantCulture);
                        start = i + 1;
                    }
                }

                return result;
            }
            else
            {
                return default;
            }
        }

        public static DateOnly? ToDateOnlyOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return DateOnly.ParseExact(value, "yyyyMMdd", CultureInfo.InvariantCulture);
            }
            else
            {
                return default;
            }
        }

        public static DateTime ToDateTime(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (value.EndsWith('Z'))
                {
                    return DateTime.SpecifyKind(DateTime.ParseExact(value, "yyyyMMdd'T'HHmmss'Z'", CultureInfo.InvariantCulture), DateTimeKind.Utc);
                }
                else
                {
                    return DateTime.SpecifyKind(DateTime.ParseExact(value, "yyyyMMdd'T'HHmmss", CultureInfo.InvariantCulture), DateTimeKind.Local);
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static DateTime[] ToDateTimeArrayOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var span = value.AsSpan();
                var result = new DateTime[CountCommaSeparatedValues(span)];
                var resultIndex = 0;
                var start = 0;

                for (var i = 0; i <= span.Length; i++)
                {
                    if (i == span.Length || span[i] == ',')
                    {
                        var part = span[start..i];
                        result[resultIndex++] = part.EndsWith("Z", StringComparison.Ordinal)
                            ? DateTime.SpecifyKind(DateTime.ParseExact(part, "yyyyMMdd'T'HHmmss'Z'", CultureInfo.InvariantCulture), DateTimeKind.Utc)
                            : DateTime.SpecifyKind(DateTime.ParseExact(part, "yyyyMMdd'T'HHmmss", CultureInfo.InvariantCulture), DateTimeKind.Local);
                        start = i + 1;
                    }
                }

                return result;
            }
            else
            {
                return default;
            }
        }

        public static DateTime? ToDateTimeOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (value.EndsWith('Z'))
                {
                    return DateTime.SpecifyKind(DateTime.ParseExact(value, "yyyyMMdd'T'HHmmss'Z'", CultureInfo.InvariantCulture), DateTimeKind.Utc);
                }
                else
                {
                    return DateTime.SpecifyKind(DateTime.ParseExact(value, "yyyyMMdd'T'HHmmss", CultureInfo.InvariantCulture), DateTimeKind.Local);
                }
            }
            else
            {
                return default;
            }
        }

        public static DayOfWeek ToDayOfWeek(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "MO", StringComparison.OrdinalIgnoreCase)) return DayOfWeek.Monday;
                if (string.Equals(value, "TU", StringComparison.OrdinalIgnoreCase)) return DayOfWeek.Tuesday;
                if (string.Equals(value, "WE", StringComparison.OrdinalIgnoreCase)) return DayOfWeek.Wednesday;
                if (string.Equals(value, "TH", StringComparison.OrdinalIgnoreCase)) return DayOfWeek.Thursday;
                if (string.Equals(value, "FR", StringComparison.OrdinalIgnoreCase)) return DayOfWeek.Friday;
                if (string.Equals(value, "SA", StringComparison.OrdinalIgnoreCase)) return DayOfWeek.Saturday;
                if (string.Equals(value, "SU", StringComparison.OrdinalIgnoreCase)) return DayOfWeek.Sunday;

                throw new FormatException($"{value} is not a valid day of week value.");
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static DayOfWeek? ToDayOfWeekOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "MO", StringComparison.OrdinalIgnoreCase)) return DayOfWeek.Monday;
                if (string.Equals(value, "TU", StringComparison.OrdinalIgnoreCase)) return DayOfWeek.Tuesday;
                if (string.Equals(value, "WE", StringComparison.OrdinalIgnoreCase)) return DayOfWeek.Wednesday;
                if (string.Equals(value, "TH", StringComparison.OrdinalIgnoreCase)) return DayOfWeek.Thursday;
                if (string.Equals(value, "FR", StringComparison.OrdinalIgnoreCase)) return DayOfWeek.Friday;
                if (string.Equals(value, "SA", StringComparison.OrdinalIgnoreCase)) return DayOfWeek.Saturday;
                if (string.Equals(value, "SU", StringComparison.OrdinalIgnoreCase)) return DayOfWeek.Sunday;

                throw new FormatException($"{value} is not a valid day of week value.");
            }
            else
            {
                return default;
            }
        }

        public static IcsEventParticipationStatus? ToEventParticipationStatusOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "NEEDS-ACTION", StringComparison.OrdinalIgnoreCase)) return IcsEventParticipationStatus.NeedsAction;
                if (string.Equals(value, "ACCEPTED", StringComparison.OrdinalIgnoreCase)) return IcsEventParticipationStatus.Accepted;
                if (string.Equals(value, "TENTATIVE", StringComparison.OrdinalIgnoreCase)) return IcsEventParticipationStatus.Tentative;
                if (string.Equals(value, "DELEGATED", StringComparison.OrdinalIgnoreCase)) return IcsEventParticipationStatus.Delegated;

                return IcsEventParticipationStatus.Unknown;
            }
            else
            {
                return default;
            }
        }

        public static IcsEventStatusValue ToEventStatusValue(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "TENTATIVE", StringComparison.OrdinalIgnoreCase)) return IcsEventStatusValue.Tentative;
                if (string.Equals(value, "CONFIRMED", StringComparison.OrdinalIgnoreCase)) return IcsEventStatusValue.Confirmed;
                if (string.Equals(value, "CANCELLED", StringComparison.OrdinalIgnoreCase)) return IcsEventStatusValue.Cancelled;

                return IcsEventStatusValue.Unknown;
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static double? ToFloat(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return double.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
            }
            else
            {
                return default;
            }
        }

        public static IcsFreeBusyType? ToFreeBusyTypeOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "BUSY", StringComparison.OrdinalIgnoreCase)) return IcsFreeBusyType.Busy;
                if (string.Equals(value, "FREE", StringComparison.OrdinalIgnoreCase)) return IcsFreeBusyType.Free;
                if (string.Equals(value, "BUSY-UNAVAILABLE", StringComparison.OrdinalIgnoreCase)) return IcsFreeBusyType.BusyUnavailable;
                if (string.Equals(value, "BUSY-TENTATIVE", StringComparison.OrdinalIgnoreCase)) return IcsFreeBusyType.BusyTentative;

                return IcsFreeBusyType.Unknown;
            }
            else
            {
                return default;
            }
        }

        public static IcsGeoPosition ToGeoPosition(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return IcsGeoPosition.Parse(value);
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static int? ToIntegerOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return int.Parse(value);
            }
            else
            {
                return default;
            }
        }

        public static IcsJournalParticipationStatus? ToJournalParticipationStatusOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "NEEDS-ACTION", StringComparison.OrdinalIgnoreCase)) return IcsJournalParticipationStatus.NeedsAction;
                if (string.Equals(value, "ACCEPTED", StringComparison.OrdinalIgnoreCase)) return IcsJournalParticipationStatus.Accepted;
                if (string.Equals(value, "DECLINED", StringComparison.OrdinalIgnoreCase)) return IcsJournalParticipationStatus.Declined;

                return IcsJournalParticipationStatus.Unknown;
            }
            else
            {
                return default;
            }
        }

        public static IcsJournalStatusValue ToJournalStatusValue(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "DRAFT", StringComparison.OrdinalIgnoreCase)) return IcsJournalStatusValue.Draft;
                if (string.Equals(value, "FINAL", StringComparison.OrdinalIgnoreCase)) return IcsJournalStatusValue.Final;
                if (string.Equals(value, "CANCELLED", StringComparison.OrdinalIgnoreCase)) return IcsJournalStatusValue.Cancelled;

                return IcsJournalStatusValue.Unknown;
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static IcsParticipationRole? ToParticipationRoleOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "CHAIR", StringComparison.OrdinalIgnoreCase)) return IcsParticipationRole.Chair;
                if (string.Equals(value, "REQ-PARTICIPANT", StringComparison.OrdinalIgnoreCase)) return IcsParticipationRole.Required;
                if (string.Equals(value, "OPT-PARTICIPANT", StringComparison.OrdinalIgnoreCase)) return IcsParticipationRole.Optional;
                if (string.Equals(value, "NON-PARTICIPANT", StringComparison.OrdinalIgnoreCase)) return IcsParticipationRole.None;

                return IcsParticipationRole.Unknown;
            }
            else
            {
                return default;
            }
        }

        public static IcsPeriod[] ToPeriodArrayOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var span = value.AsSpan();
                var result = new IcsPeriod[CountCommaSeparatedValues(span)];
                var resultIndex = 0;
                var start = 0;

                for (var i = 0; i <= span.Length; i++)
                {
                    if (i == span.Length || span[i] == ',')
                    {
                        result[resultIndex++] = IcsPeriod.Parse(span[start..i].ToString());
                        start = i + 1;
                    }
                }

                return result;
            }
            else
            {
                return default;
            }
        }

        public static IcsRecurrenceFrequency? ToRecurrenceFrequencyOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "SECONDLY", StringComparison.OrdinalIgnoreCase)) return IcsRecurrenceFrequency.Secondly;
                if (string.Equals(value, "MINUTELY", StringComparison.OrdinalIgnoreCase)) return IcsRecurrenceFrequency.Minutely;
                if (string.Equals(value, "HOURLY", StringComparison.OrdinalIgnoreCase)) return IcsRecurrenceFrequency.Hourly;
                if (string.Equals(value, "DAILY", StringComparison.OrdinalIgnoreCase)) return IcsRecurrenceFrequency.Daily;
                if (string.Equals(value, "WEEKLY", StringComparison.OrdinalIgnoreCase)) return IcsRecurrenceFrequency.Weekly;
                if (string.Equals(value, "MONTHLY", StringComparison.OrdinalIgnoreCase)) return IcsRecurrenceFrequency.Monthly;
                if (string.Equals(value, "YEARLY", StringComparison.OrdinalIgnoreCase)) return IcsRecurrenceFrequency.Yearly;

                throw new FormatException($"{value} is not a valid recurrence frequency value.");
            }
            else
            {
                return default;
            }
        }

        public static IcsRecurrencePattern ToRecurrencePattern(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return IcsRecurrencePattern.Parse(value);
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static IcsRelationshipType? ToRelationshipTypeOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "PARENT", StringComparison.OrdinalIgnoreCase)) return IcsRelationshipType.Parent;
                if (string.Equals(value, "CHILD", StringComparison.OrdinalIgnoreCase)) return IcsRelationshipType.Child;
                if (string.Equals(value, "SIBLING", StringComparison.OrdinalIgnoreCase)) return IcsRelationshipType.Sibling;

                return IcsRelationshipType.Unknown;
            }
            else
            {
                return default;
            }
        }

        public static IcsTriggerRelationship ToRelationshipValue(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "START", StringComparison.OrdinalIgnoreCase)) return IcsTriggerRelationship.Start;
                if (string.Equals(value, "END", StringComparison.OrdinalIgnoreCase)) return IcsTriggerRelationship.End;

                return default;
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static IcsRequestStatusValue ToRequestStatusValue(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return IcsRequestStatusValue.Parse(value);
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static IcsDayRule[] ToRRuleByDayArrayOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var span = value.AsSpan();
                var result = new IcsDayRule[CountCommaSeparatedValues(span)];
                var resultIndex = 0;
                var start = 0;

                for (var i = 0; i <= span.Length; i++)
                {
                    if (i == span.Length || span[i] == ',')
                    {
                        result[resultIndex++] = IcsDayRule.Parse(span[start..i].ToString());
                        start = i + 1;
                    }
                }

                return result;
            }
            else
            {
                return default;
            }
        }

        public static sbyte[] ToSByteArrayOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var span = value.AsSpan();
                var result = new sbyte[CountCommaSeparatedValues(span)];
                var resultIndex = 0;
                var start = 0;

                for (var i = 0; i <= span.Length; i++)
                {
                    if (i == span.Length || span[i] == ',')
                    {
                        result[resultIndex++] = sbyte.Parse(span[start..i]);
                        start = i + 1;
                    }
                }

                return result;
            }
            else
            {
                return default;
            }
        }

        public static short[] ToShortArrayOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var span = value.AsSpan();
                var result = new short[CountCommaSeparatedValues(span)];
                var resultIndex = 0;
                var start = 0;

                for (var i = 0; i <= span.Length; i++)
                {
                    if (i == span.Length || span[i] == ',')
                    {
                        result[resultIndex++] = short.Parse(span[start..i]);
                        start = i + 1;
                    }
                }

                return result;
            }
            else
            {
                return default;
            }
        }

        public static string[] ToStringArrayOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value.Split(',');
            }
            else
            {
                return default;
            }
        }

        public static TimeSpan ToTimeSpan(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return IcsTimeSpanParser.Parse(value);
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static TimeSpan? ToTimeSpanOrDefault(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return IcsTimeSpanParser.Parse(value);
            }
            else
            {
                return default;
            }
        }

        public static IcsTodoParticipationStatus ToTodoParticipationStatus(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "NEEDS-ACTION", StringComparison.OrdinalIgnoreCase)) return IcsTodoParticipationStatus.NeedsAction;
                if (string.Equals(value, "ACCEPTED", StringComparison.OrdinalIgnoreCase)) return IcsTodoParticipationStatus.Accepted;
                if (string.Equals(value, "DECLINED", StringComparison.OrdinalIgnoreCase)) return IcsTodoParticipationStatus.Declined;
                if (string.Equals(value, "TENTATIVE", StringComparison.OrdinalIgnoreCase)) return IcsTodoParticipationStatus.Tentative;
                if (string.Equals(value, "DELEGATED", StringComparison.OrdinalIgnoreCase)) return IcsTodoParticipationStatus.Delegated;
                if (string.Equals(value, "COMPLETED", StringComparison.OrdinalIgnoreCase)) return IcsTodoParticipationStatus.Completed;
                if (string.Equals(value, "IN-PROCESS", StringComparison.OrdinalIgnoreCase)) return IcsTodoParticipationStatus.InProcess;

                return IcsTodoParticipationStatus.Unknown;
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static IcsTodoStatusValue ToTodoStatusValue(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "NEEDS-ACTION", StringComparison.OrdinalIgnoreCase)) return IcsTodoStatusValue.NeedsAction;
                if (string.Equals(value, "COMPLETED", StringComparison.OrdinalIgnoreCase)) return IcsTodoStatusValue.Completed;
                if (string.Equals(value, "IN-PROCESS", StringComparison.OrdinalIgnoreCase)) return IcsTodoStatusValue.InProcess;
                if (string.Equals(value, "CANCELLED", StringComparison.OrdinalIgnoreCase)) return IcsTodoStatusValue.Cancelled;

                return IcsTodoStatusValue.Unknown;
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static IcsTransparencyType ToTransparencyValue(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "OPAQUE", StringComparison.OrdinalIgnoreCase)) return IcsTransparencyType.Opaque;
                if (string.Equals(value, "TRANSPARENT", StringComparison.OrdinalIgnoreCase)) return IcsTransparencyType.Transparent;

                return IcsTransparencyType.Unknown;
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static Uri ToUri(string value)
        {
            return new Uri(value);
        }

        public static IcsUserType ToUserType(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.Equals(value, "INDIVIDUAL", StringComparison.OrdinalIgnoreCase)) return IcsUserType.Individual;
                if (string.Equals(value, "GROUP", StringComparison.OrdinalIgnoreCase)) return IcsUserType.Group;
                if (string.Equals(value, "ROOM", StringComparison.OrdinalIgnoreCase)) return IcsUserType.Room;
                if (string.Equals(value, "RESOURCE", StringComparison.OrdinalIgnoreCase)) return IcsUserType.Resource;

                return IcsUserType.Unknown;
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static IcsUtcOffset ToUtcOffset(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return IcsUtcOffset.Parse(value);
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        private static int CountCommaSeparatedValues(ReadOnlySpan<char> value)
        {
            if (value.IsEmpty)
            {
                return 0;
            }

            var count = 1;

            for (var i = 0; i < value.Length; i++)
            {
                if (value[i] == ',')
                {
                    count++;
                }
            }

            return count;
        }
    }
}
