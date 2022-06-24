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
    /// Represents an iCalendar Time Zone Component
    /// </summary>
    public class IcsTimeZone : IcsComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsTimeZone"/> class.
        /// </summary>
        public IcsTimeZone()
            : base(IcsComponentNames.TimeZone)
        {
            DaylightRuleList = new List<IcsDaylightRule>();
            StandardRuleList = new List<IcsStandardRule>();
        }

        /// <summary>
        /// Defines the set of Daylight Saving Time observances (or rules) for the time zone for a 
        /// given interval of time.
        /// </summary>
        public IList<IcsDaylightRule> DaylightRuleList { get; set; }

        /// <summary>
        /// Specifies the text value that uniquely identifies this time zone in the scope 
        /// of an iCalendar object.
        /// </summary>
        public IcsTimeZoneId Id { get; set; }

        /// <summary>
        /// Specifies the date and time that the information associated with the time zone was 
        /// last revised.
        /// </summary>
        public IcsLastModified LastModified { get; set; }

        /// <summary>
        /// Defines the set of Standard Time observances (or rules) for a the time zone for a given 
        /// interval of time.
        /// </summary>
        public IList<IcsStandardRule> StandardRuleList { get; set; }

        /// <summary>
        /// Provides a means for this time zone component to point to a network location that 
        /// can be used to retrieve an up-to-date version of itself.
        /// </summary>
        public IcsTimeZoneUrl Url { get; set; }

        /// <summary>
        /// Adds a new daylight sub component to the time zone
        /// </summary>
        /// <returns>Gives back the newly created daylight sub component</returns>
        public IcsDaylightRule AddDaylightRule()
        {
            var o = new IcsDaylightRule();
            DaylightRuleList.Add(o);
            return o;
        }

        /// <summary>
        /// Adds a new standard sub component to the time zone
        /// </summary>
        /// <returns>Gives back the newly created standard sub component</returns>
        public IcsStandardRule AddStandardRule()
        {
            var o = new IcsStandardRule();
            StandardRuleList.Add(o);
            return o;
        }

        /// <summary>
        /// Serializes the complete component to a stream
        /// </summary>
        /// <param name="textWriter">Text writer</param>
        public override void WriteContent(TextWriter textWriter)
        {
            textWriter.Write(IcsCoreNames.Begin, IcsComponentNames.TimeZone);

            textWriter.WriteComponentList(DaylightRuleList);
            textWriter.WriteProperty(Id);
            textWriter.WriteProperty(LastModified);
            textWriter.WriteComponentList(StandardRuleList);
            textWriter.WriteProperty(Url);

            base.WriteContent(textWriter);

            textWriter.Write(IcsCoreNames.End, IcsComponentNames.TimeZone);
        }

        /// <summary>
        /// Serializes the complete component to a stream
        /// </summary>
        /// <param name="textWriter">Text writer</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public override async Task WriteContentAsync(TextWriter textWriter)
        {
            await textWriter.WriteContentAsync(IcsCoreNames.Begin, IcsComponentNames.TimeZone);

            await textWriter.WriteComponentListAsync(DaylightRuleList);
            await textWriter.WritePropertyAsync(Id);
            await textWriter.WritePropertyAsync(LastModified);
            await textWriter.WriteComponentListAsync(StandardRuleList);
            await textWriter.WritePropertyAsync(Url);

            await base.WriteContentAsync(textWriter);

            await textWriter.WriteContentAsync(IcsCoreNames.End, IcsComponentNames.TimeZone);
        }
    }
}
