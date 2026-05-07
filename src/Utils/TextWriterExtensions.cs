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
using System.IO;
using System.Text;
using System.Threading;
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

        public static Task WriteComponentAsync(this TextWriter textWriter, IcsComponent component, CancellationToken cancellationToken = default)
        {
            return component.WriteContentAsync(textWriter, cancellationToken);
        }

        public static void WriteComponentList<T>(this TextWriter textWriter, IList<T> componentList)
            where T : IcsComponent
        {
            foreach (var component in componentList)
            {
                component.WriteContent(textWriter);
            }
        }

        public static async Task WriteComponentListAsync<T>(this TextWriter textWriter, IList<T> componentList, CancellationToken cancellationToken = default)
            where T : IcsComponent
        {
            foreach (var component in componentList)
            {
                await component.WriteContentAsync(textWriter, cancellationToken).ConfigureAwait(false); 
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

        public static async Task WriteContentAsync(this TextWriter textWriter, string name, string value, CancellationToken cancellationToken = default)
        {
            await textWriter.WriteLineAsync(IcsContentLine.ToString(name, value).AsMemory(), cancellationToken).ConfigureAwait(false);
        }

        public static async Task WriteContentAsync(this TextWriter textWriter, IcsContentLine contentLine, CancellationToken cancellationToken = default)
        {
            await textWriter.WriteLineAsync(contentLine.ToString().AsMemory(), cancellationToken).ConfigureAwait(false);
        }

        public static void WriteProperty(this TextWriter textWriter, IcsProperty property)
        {
            if (property != null)
            {
                textWriter.WriteLine(property.ContentLine.ToString());
            }
        }

        public static async Task WritePropertyAsync(this TextWriter textWriter, IcsProperty property, CancellationToken cancellationToken = default)
        {
            if (property != null)
            {
                await textWriter.WriteLineAsync(property.ContentLine.ToString().AsMemory(), cancellationToken).ConfigureAwait(false);
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

        public static async Task WritePropertyListAsync<T>(this TextWriter textWriter, IList<T> propertyList, CancellationToken cancellationToken = default)
            where T : IcsProperty
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (propertyList.Count == 0)
            {
                return;
            }

            var sb = new StringBuilder();
            using var bufferWriter = new StringWriter(sb);

            foreach (var property in propertyList)
            {
                bufferWriter.WriteLine(property.ContentLine.ToString());
            }

            await textWriter.WriteAsync(sb.ToString().AsMemory(), cancellationToken).ConfigureAwait(false);
        }
    }
}
