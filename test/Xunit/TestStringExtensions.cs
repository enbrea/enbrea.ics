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

using System;
using Xunit;

namespace Enbrea.Ics.Tests
{
    /// <summary>
    /// Unit tests for <see cref="StringExtensions"/>.
    /// </summary>
    public class TestStringExtensions
    {
        [Fact]
        public void SupportEscapeString_1()
        {
            var text =
                $"This is a long {Environment.NewLine}description {Environment.NewLine}that exists on a long line.";

            var str = text.Escape();

            Assert.Equal("This is a long \\ndescription \\nthat exists on a long line.", str);
        }

        [Fact]
        public void SupportEscapeString_2()
        {
            var text =
                "This is an unescaped string: \\ + , + ;";

            var str = text.Escape();

            Assert.Equal("This is an unescaped string: \\\\ + \\, + \\;", str);
        }

        [Fact]
        public void SupportUnEscapeString_1()
        {
            var text =
                "This is a long \\ndescription \\nthat exists on a long line.";

            var str = text.UnEscape();

            Assert.Equal($"This is a long {Environment.NewLine}description {Environment.NewLine}that exists on a long line.", str);
        }

        [Fact]
        public void SupportUnEscapeString_2()
        {
            var text =
                "This is an escaped string: \\\\ + \\, + \\;";

            var str = text.UnEscape();

            Assert.Equal("This is an escaped string: \\ + , + ;", str);
        }
    }
}
