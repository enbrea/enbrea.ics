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
using Xunit;

namespace Enbrea.Ics.Tests
{
    /// <summary>
    /// Unit tests for <see cref="StringExtensions"/>.
    /// </summary>
    public class TestStringExtensions
    {
        [Fact]
        public void Escape_ConvertsNewLines_ToIcsEscapes()
        {
            var text =
                $"This is a long {Environment.NewLine}description {Environment.NewLine}that exists on a long line.";

            var str = text.Escape();

            Assert.Equal("This is a long \\ndescription \\nthat exists on a long line.", str);
        }

        [Fact]
        public void Escape_ConvertsSpecialCharacters_ToIcsEscapes()
        {
            var text =
                "This is an unescaped string: \\ + , + ;";

            var str = text.Escape();

            Assert.Equal("This is an unescaped string: \\\\ + \\, + \\;", str);
        }

        [Fact]
        public void Escape_ReturnsSameInstance_WhenNoEscapingIsNeeded()
        {
            var text = "This string needs no escaping.";

            var str = text.Escape();

            Assert.Same(text, str);
        }

        [Fact]
        public void UnEscape_ConvertsIcsEscapes_ToNewLines()
        {
            var text =
                "This is a long \\ndescription \\nthat exists on a long line.";

            var str = text.UnEscape();

            Assert.Equal($"This is a long {Environment.NewLine}description {Environment.NewLine}that exists on a long line.", str);
        }

        [Fact]
        public void UnEscape_ConvertsIcsEscapes_ToSpecialCharacters()
        {
            var text =
                "This is an escaped string: \\\\ + \\, + \\;";

            var str = text.UnEscape();

            Assert.Equal("This is an escaped string: \\ + , + ;", str);
        }

        [Fact]
        public void UnEscape_ReturnsSameInstance_WhenNoUnescapingIsNeeded()
        {
            var text = "This string is already unescaped.";

            var str = text.UnEscape();

            Assert.Same(text, str);
        }
    }
}
