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
    /// Extensions for <see cref="TextWriter"/>
    /// </summary>
    public static class TextWriterExtensions
    {
        public static void WriteComponent(this TextWriter textWriter, IcsComponent component)
        {
            component.WriteContent(textWriter);
        }

        public static async Task WriteComponentAsync(this TextWriter textWriter, IcsComponent component)
        {
            await component.WriteContentAsync(textWriter);
        }

        public static void WriteComponentList<T>(this TextWriter textWriter, IList<T> componentList)
            where T : IcsComponent
        {
            foreach (var component in componentList)
            {
                component.WriteContent(textWriter);
            }
        }

        public static async Task WriteComponentListAsync<T>(this TextWriter textWriter, IList<T> componentList)
            where T : IcsComponent
        {
            foreach (var component in componentList)
            {
                await component.WriteContentAsync(textWriter);
            }
        }

        public static void WriteContent(this TextWriter textWriter, string name, string value)
        {
            textWriter.WriteLine(IcsContentLine.ToString(name, value));
        }

        public static void WriteContent(this TextWriter textWriter, IcsContentLine contentLine)
        {
            textWriter.WriteLine(contentLine.ToString());
        }

        public static async Task WriteContentAsync(this TextWriter textWriter, string name, string value)
        {
            await textWriter.WriteLineAsync(IcsContentLine.ToString(name, value));
        }

        public static async Task WriteContentAsync(this TextWriter textWriter, IcsContentLine contentLine)
        {
            await textWriter.WriteLineAsync(contentLine.ToString());
        }

        public static void WriteProperty(this TextWriter textWriter, IcsProperty property)
        {
            if (property != null)
            {
                textWriter.WriteLine(property.ContentLine.ToString());
            }
        }

        public static async Task WritePropertyAsync(this TextWriter textWriter, IcsProperty property)
        {
            if (property != null)
            {
                await textWriter.WriteLineAsync(property.ContentLine.ToString());
            }
        }

        public static void WritePropertyList<T>(this TextWriter textWriter, IList<T> propertyList)
            where T : IcsProperty
        {
            foreach (var property in propertyList)
            {
                textWriter.WriteLine(property.ContentLine.ToString());
            }
        }

        public static async Task WritePropertyListAsync<T>(this TextWriter textWriter, IList<T> propertyList)
            where T : IcsProperty
        {
            foreach (var property in propertyList)
            {
                await textWriter.WriteLineAsync(property.ContentLine.ToString());
            }
        }
    }
}
