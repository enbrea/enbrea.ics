[![NuGet Gallery](https://img.shields.io/badge/NuGet%20Gallery-enbrea.ics-blue.svg)](https://www.nuget.org/packages/Enbrea.Ics/)
![GitHub](https://img.shields.io/github/license/enbrea/enbrea.ics)

# ENBREA ICS

A .NET library for parsing and building [iCalendar](https://tools.ietf.org/html/rfc5545) streams and files:

+ Supports .NET 6, .NET 8 and .NET 9
+ Supports reading and writing of the following iCal components:
  + VCALENDAR
  + VEVENT
  + VTODO
  + VJOURNAL
  + VFREEBUSY
  + VTIMEZONE
  + VALARM
  + STANDARD
  + DAYLIGHT
+ Supports reading and writing of custom properties and parameters
+ Includes low level iCalendar content line parser
+ Includes high level iCalendar object reader and writer 
+ Includes synchron and asynchron methods

## Installation

```
dotnet add package Enbrea.Ics
```

## Getting started

Documentation is available in the [GitHub wiki](https://github.com/enbrea/enbrea.ics/wiki).

## Todo

- [ ] Adding more unit tests
- [ ] Adding support for [RFC 7986: New Properties for iCalendar](https://datatracker.ietf.org/doc/html/rfc7986)
- [ ] Adding support for [RFC 9073: Event Publishing Extensions to iCalendar](https://datatracker.ietf.org/doc/html/rfc9073)
- [ ] Adding support for [RFC 9074: "VALARM" Extensions for iCalendar](https://datatracker.ietf.org/doc/html/rfc9074)

## Can I help?

Yes, that would be much appreciated. The best way to help is to post a response via the Issue Tracker and/or submit a Pull Request.