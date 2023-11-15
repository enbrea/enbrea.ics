#region ENBREA.ICS - Copyright (C) 2023 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA.ICS 
 *    
 *    Copyright (C) 2023 STÜBER SYSTEMS GmbH
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
            return string.Join(',', values.ToString());
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
            return string.Join(',', values.ToString());
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
            return string.Join(',', values.ToString());
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
            return string.Join(',', values.ToString());
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
            return string.Join(',', values.ToString());
        }

        public static string FromSByteArray(sbyte[] values)
        {
            return string.Join(',', values.ToString());
        }

        public static string FromShortArray(short[] values)
        {
            return string.Join(',', values.ToString());
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
                return value.ToUpper() switch
                {
                    "AUDIO" => IcsActionValue.Audio,
                    "DISPLAY" => IcsActionValue.Display,
                    "EMAIL" => IcsActionValue.Email,
                    _ => IcsActionValue.Unknown
                };
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
                return value.ToUpper() switch
                {
                    "TRUE" => true,
                    "FALSE" => false,
                    _ => throw new NotImplementedException(),
                };
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
                var parts = value.Split(',');
                var result = new byte[parts.Length];

                for (var i = 0; i < parts.Length; i++)
                {
                    result[i] = byte.Parse(parts[i]);
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
                return value.ToUpper() switch
                {
                    "PUBLIC" => IcsClassificationValue.Public,
                    "PRIVATE" => IcsClassificationValue.Private,
                    "CONFIDENTIAL" => IcsClassificationValue.Confidential,
                    _ => IcsClassificationValue.Unknown
                };
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
                var parts = value.Split(',');
                var result = new DateOnly[parts.Length];

                for (var i = 0; i < parts.Length; i++)
                {
                    result[i] = ToDateOnly(parts[i]);
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
                var parts = value.Split(',');
                var result = new DateTime[parts.Length];

                for (var i = 0; i < parts.Length; i++)
                {
                    result[i] = ToDateTime(parts[i]);
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
                return value.ToUpper() switch
                {
                    "MO" => DayOfWeek.Monday,
                    "TU" => DayOfWeek.Tuesday,
                    "WE" => DayOfWeek.Wednesday,
                    "TH" => DayOfWeek.Thursday,
                    "FR" => DayOfWeek.Friday,
                    "SA" => DayOfWeek.Saturday,
                    "SU" => DayOfWeek.Sunday,
                    _ => throw new FormatException($"{value} is not a valid day of week value.")
                };
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
                return value.ToUpper() switch
                {
                    "MO" => DayOfWeek.Monday,
                    "TU" => DayOfWeek.Tuesday,
                    "WE" => DayOfWeek.Wednesday,
                    "TH" => DayOfWeek.Thursday,
                    "FR" => DayOfWeek.Friday,
                    "SA" => DayOfWeek.Saturday,
                    "SU" => DayOfWeek.Sunday,
                    _ => throw new FormatException($"{value} is not a valid day of week value.")
                };
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
                return value.ToUpper() switch
                {
                    "NEEDS-ACTION" => IcsEventParticipationStatus.NeedsAction,
                    "ACCEPTED" => IcsEventParticipationStatus.Accepted,
                    "TENTATIVE" => IcsEventParticipationStatus.Tentative,
                    "DELEGATED" => IcsEventParticipationStatus.Delegated,
                    _ => IcsEventParticipationStatus.Unknown
                };
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
                return value.ToUpper() switch
                {
                    "TENTATIVE" => IcsEventStatusValue.Tentative,
                    "CONFIRMED" => IcsEventStatusValue.Confirmed,
                    "CANCELLED" => IcsEventStatusValue.Cancelled,
                    _ => IcsEventStatusValue.Unknown
                };
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
                return value.ToUpper() switch
                {
                    "BUSY" => IcsFreeBusyType.Busy,
                    "FREE" => IcsFreeBusyType.Free,
                    "BUSY-UNAVAILABLE" => IcsFreeBusyType.BusyUnavailable,
                    "BUSY-TENTATIVE" => IcsFreeBusyType.BusyTentative,
                    _ => IcsFreeBusyType.Unknown
                };
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
                return value.ToUpper() switch
                {
                    "NEEDS-ACTION" => IcsJournalParticipationStatus.NeedsAction,
                    "ACCEPTED" => IcsJournalParticipationStatus.Accepted,
                    "DECLINED" => IcsJournalParticipationStatus.Declined,
                    _ => IcsJournalParticipationStatus.Unknown
                };
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
                return value.ToUpper() switch
                {
                    "DRAFT" => IcsJournalStatusValue.Draft,
                    "FINAL" => IcsJournalStatusValue.Final,
                    "CANCELLED" => IcsJournalStatusValue.Cancelled,
                    _ => IcsJournalStatusValue.Unknown
                };
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
                return value.ToUpper() switch
                {
                    "CHAIR" => IcsParticipationRole.Chair,
                    "REQ-PARTICIPANT" => IcsParticipationRole.Required,
                    "OPT-PARTICIPANT" => IcsParticipationRole.Optional,
                    "NON-PARTICIPANT" => IcsParticipationRole.None,
                    _ => IcsParticipationRole.Unknown
                };
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
                var parts = value.Split(',');
                var result = new IcsPeriod[parts.Length];

                for (var i = 0; i < parts.Length; i++)
                {
                    result[i] = IcsPeriod.Parse(parts[i]);
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
                return value.ToUpper() switch
                {
                    "SECONDLY" => IcsRecurrenceFrequency.Secondly,
                    "MINUTELY" => IcsRecurrenceFrequency.Minutely,
                    "HOURLY" => IcsRecurrenceFrequency.Hourly,
                    "DAILY" => IcsRecurrenceFrequency.Daily,
                    "WEEKLY" => IcsRecurrenceFrequency.Weekly,
                    "MONTHLY" => IcsRecurrenceFrequency.Monthly,
                    "YEARLY" => IcsRecurrenceFrequency.Yearly,
                    _ => throw new FormatException($"{value} is not a valid recurrence frequency value.")
                };
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
                return value.ToUpper() switch
                {
                    "PARENT" => IcsRelationshipType.Parent,
                    "CHILD" => IcsRelationshipType.Child,
                    "SIBLING" => IcsRelationshipType.Sibling,
                    _ => IcsRelationshipType.Unknown
                };
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
                return value.ToUpper() switch
                {
                    "START" => IcsTriggerRelationship.Start,
                    "END" => IcsTriggerRelationship.End,
                    _ => default
                };
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
                var parts = value.Split(',');
                var result = new IcsDayRule[parts.Length];

                for (var i = 0; i < parts.Length; i++)
                {
                    result[i] = IcsDayRule.Parse(parts[i]);
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
                var parts = value.Split(',');
                var result = new sbyte[parts.Length];

                for (var i = 0; i < parts.Length; i++)
                {
                    result[i] = sbyte.Parse(parts[i]);
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
                var parts = value.Split(',');
                var result = new short[parts.Length];

                for (var i = 0; i < parts.Length; i++)
                {
                    result[i] = short.Parse(parts[i]);
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
                return value.ToUpper() switch
                {
                    "NEEDS-ACTION" => IcsTodoParticipationStatus.NeedsAction,
                    "ACCEPTED" => IcsTodoParticipationStatus.Accepted,
                    "DECLINED" => IcsTodoParticipationStatus.Declined,
                    "TENTATIVE" => IcsTodoParticipationStatus.Tentative,
                    "DELEGATED" => IcsTodoParticipationStatus.Delegated,
                    "COMPLETED" => IcsTodoParticipationStatus.Completed,
                    "IN-PROCESS" => IcsTodoParticipationStatus.InProcess,
                    _ => IcsTodoParticipationStatus.Unknown
                };
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
                return value.ToUpper() switch
                {
                    "NEEDS-ACTION" => IcsTodoStatusValue.NeedsAction,
                    "COMPLETED" => IcsTodoStatusValue.Completed,
                    "IN-PROCES" => IcsTodoStatusValue.InProcess,
                    "CANCELLED" => IcsTodoStatusValue.Cancelled,
                    _ => IcsTodoStatusValue.Unknown
                };
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
                return value.ToUpper() switch
                {
                    "OPAQUE" => IcsTransparencyType.Opaque,
                    "TRANSPARENT" => IcsTransparencyType.Transparent,
                    _ => IcsTransparencyType.Unknown
                };
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
                return value.ToUpper() switch
                {
                    "INDIVIDUAL" => IcsUserType.Individual,
                    "GROUP" => IcsUserType.Group,
                    "ROOM" => IcsUserType.Room,
                    "RESOURCE" => IcsUserType.Resource,
                    _ => IcsUserType.Unknown
                };
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
    }
}
