[![NuGet Gallery](https://img.shields.io/badge/NuGet%20Gallery-enbrea.ics-blue.svg)](https://www.nuget.org/packages/Enbrea.Ics/)
![GitHub](https://img.shields.io/github/license/enbrea/enbrea.ics)

# ENBREA ICS

A modern .NET library for parsing and generating [iCalendar](https://datatracker.ietf.org/doc/html/rfc5545) streams and files with full RFC 5545 compliance.

+ Supports `.NET 10`, `.NET 9` and `.NET 8`
+ Supports reading and writing the following iCalendar components:
  + VCALENDAR
  + VEVENT
  + VTODO
  + VJOURNAL
  + VFREEBUSY
  + VTIMEZONE
  + VALARM
  + STANDARD
  + DAYLIGHT
+ Supports custom properties and parameters
+ Includes a low-level iCalendar content-line parser
+ Includes a low-level iCalendar duration parser
+ Includes high-level iCalendar object reader and writer
+ Provides both synchronous and asynchronous APIs

## Installation

```
dotnet add package Enbrea.Ics
```

## Getting started

Documentation is available in the [GitHub wiki](https://github.com/enbrea/enbrea.ics/wiki).

## Contributing

Yes, contributions are very welcome. The best way to help is to open an issue and/or submit a pull request.
