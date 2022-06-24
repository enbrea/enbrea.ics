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
    /// Represents an abstract iCalendar component
    /// </summary>
    public abstract class IcsComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IcsComponent"/> class.
        /// </summary>
        /// <param name="name">The name of the component</param>
        public IcsComponent(string name)
        {
            Name = name;
            CustomProperties = new List<IcsContentLine>();
        }

        /// <summary>
        /// A list of <see cref="IcsContentLine""> instances not supported by this library.
        /// </summary>
        public IList<IcsContentLine> CustomProperties { get; set; }

        /// <summary>
        /// The name of the component
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Adds a new custom property to the component
        /// </summary>
        /// <param name="name">Name of the custom property</param>
        /// <param name="value">Value of the custom property</param>
        /// <returns>Gives back the newly created custom property</returns>
        public IcsContentLine AddCustomProperty(string name, string value)
        {
            var o = new IcsContentLine(name, value);
            CustomProperties.Add(o);
            return o;
        }

        /// <summary>
        /// Serializes the component to a text writer
        /// </summary>
        /// <param name="textWriter">Text writer</param>
        public virtual void WriteContent(TextWriter textWriter)
        {
            foreach (var property in CustomProperties)
            {
                textWriter.WriteContent(property);
            }
        }

        /// <summary>
        /// Serializes the component to a text writer
        /// </summary>
        /// <param name="textWriter">Text writer</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public virtual async Task WriteContentAsync(TextWriter textWriter)
        {
            foreach (var property in CustomProperties)
            {
                await textWriter.WriteContentAsync(property);
            }
        }
    }
}
