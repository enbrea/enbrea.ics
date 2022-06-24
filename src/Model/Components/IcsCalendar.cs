#region ENBREA.ICS - Copyright (C) 2022 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA.ICS 
 *    
 *    Copyright (C) 2022 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Enbrea.Ics
{
    /// <summary>
    /// Represents an iCalendar object
    /// </summary>
    public class IcsCalendar : IcsComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsCalendar"/> class.
        /// </summary>
        private IcsCalendar()
            : base(IcsComponentNames.Calendar)
        {
            EventList = new List<IcsEvent>();
            FreeBusyList = new List<IcsFreeBusy>();
            JournalList = new List<IcsJournal>();
            TimeZoneList = new List<IcsTimeZone>();
            TodoList = new List<IcsTodo>();
        }

        /// <summary>
        /// A list of <see cref="IcsEvent""> instances
        /// </summary>
        public IList<IcsEvent> EventList { get; set; }

        /// <summary>
        /// A list of <see cref="IcsFreeBusy""> instances
        /// </summary>
        public IList<IcsFreeBusy> FreeBusyList { get; set; }

        /// <summary>
        /// A list of <see cref="IcsJournal""> instances
        /// </summary>
        public IList<IcsJournal> JournalList { get; set; }

        /// <summary>
        /// Defines the method associated with the iCalendar object.
        /// </summary>
        public IcsMethod Method { get; set; }

        /// <summary>
        /// Specifies the identifier for the product that created the iCalendar object.
        /// </summary>
        public IcsProductId ProductId { get; set; }

        /// <summary>
        /// Defines the calendar scale used for the calendar information specified in this iCalendar 
        /// object. The default value is "GREGORIAN".
        /// </summary>
        public IcsScale Scale { get; set; }

        /// <summary>
        /// A list of <see cref="IcsTimeZone""> instances
        /// </summary>
        public IList<IcsTimeZone> TimeZoneList { get; set; }

        /// <summary>
        /// A list of <see cref="IcsTodo""> instances
        /// </summary>
        public IList<IcsTodo> TodoList { get; set; }

        /// <summary>
        /// Specifies the identifier corresponding to the highest version number or the minimum and 
        /// maximum range of the iCalendar specification that is required in order to interpret the
        /// iCalendar object. The default value is "2.0".
        /// </summary>
        public IcsVersion Version { get; set; }

        /// <summary>
        /// A static factory method which creates a new instance of the <see cref="IcsCalendar"/> class 
        /// with minimal default values.
        /// </summary>
        /// <returns>a new instance of the <see cref="IcsCalendar"/> class.</returns>
        static public IcsCalendar CreateWithDefaults()
        {
            var newCalendar = new IcsCalendar()
            {
                Method = new IcsMethod("PUBLISH"),
                ProductId = new IcsProductId(" -//STUEBER SYSTEMS//NONSGML Enbrea.Ics//EN"),
                Scale = new IcsScale("GREGORIAN"),
                Version = new IcsVersion("2.0"),

            };
            return newCalendar;
        }

        /// <summary>
        /// A static factory method which creates a new instance of the <see cref="IcsCalendar"/> class 
        /// without any default values.
        /// </summary>
        /// <returns>a new instance of the <see cref="IcsCalendar"/> class.</returns>
        static public IcsCalendar CreateWithoutDefaults()
        {
            return new IcsCalendar();
        }

        /// <summary>
        /// Adds a new event component to the calendar
        /// </summary>
        /// <returns>Gives back the newly created event component</returns>
        public IcsEvent AddEvent()
        {
            var e = new IcsEvent();
            EventList.Add(e);
            return e;
        }

        /// <summary>
        /// Adds a new freebusy component to the calendar
        /// </summary>
        /// <returns>Gives back the newly created freebusy component</returns>
        public IcsFreeBusy AddFreeBusy()
        {
            var e = new IcsFreeBusy();
            FreeBusyList.Add(e);
            return e;
        }

        /// <summary>
        /// Adds a new journal component to the calendar
        /// </summary>
        /// <returns>Gives back the newly created journal component</returns>
        public IcsJournal AddJournal()
        {
            var e = new IcsJournal();
            JournalList.Add(e);
            return e;
        }

        /// <summary>
        /// Adds a new time zone component to the calendar
        /// </summary>
        /// <returns>Gives back the newly created time zone component</returns>
        public IcsTimeZone AddTimeZone()
        {
            var e = new IcsTimeZone();
            TimeZoneList.Add(e);
            return e;
        }

        /// <summary>
        /// Adds a new to-do component to the component
        /// </summary>
        /// <returns>Gives back the newly created to-do component</returns>
        public IcsTodo AddTodo()
        {
            var e = new IcsTodo();
            TodoList.Add(e);
            return e;
        }

        /// <summary>
        /// Serializes the complete calendar to a text writer
        /// </summary>
        /// <param name="textWriter">Text writer</param>
        public override void WriteContent(TextWriter textWriter)
        {
            textWriter.Write(IcsCoreNames.Begin, Name);

            textWriter.WriteProperty(Version);
            textWriter.WriteProperty(ProductId);
            textWriter.WriteProperty(Scale);
            textWriter.WriteProperty(Method);
            textWriter.WriteComponentList(EventList);
            textWriter.WriteComponentList(TodoList);
            textWriter.WriteComponentList(JournalList);
            textWriter.WriteComponentList(FreeBusyList);
            textWriter.WriteComponentList(TimeZoneList);

            base.WriteContent(textWriter);

            textWriter.Write(IcsCoreNames.End, Name);
        }

        /// <summary>
        /// Serializes the complete calendar to a text writer
        /// </summary>
        /// <param name="textWriter">Text writer</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public override async Task WriteContentAsync(TextWriter textWriter)
        {
            await textWriter.WriteContentAsync(IcsCoreNames.Begin, Name);

            await textWriter.WritePropertyAsync(Version);
            await textWriter.WritePropertyAsync(ProductId);
            await textWriter.WritePropertyAsync(Scale);
            await textWriter.WritePropertyAsync(Method);
            await textWriter.WriteComponentListAsync(EventList);
            await textWriter.WriteComponentListAsync(TodoList);
            await textWriter.WriteComponentListAsync(JournalList);
            await textWriter.WriteComponentListAsync(FreeBusyList);
            await textWriter.WriteComponentListAsync(TimeZoneList);

            await base.WriteContentAsync(textWriter);

            await textWriter.WriteContentAsync(IcsCoreNames.End, Name);
        }
    }
}
