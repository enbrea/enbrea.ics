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
using Xunit;

namespace Enbrea.Ics.Tests
{
    /// <summary>
    /// Unit tests for <see cref="IcsContentLineParser"/>.
    /// </summary>
    public class TestIcsContentLineParser
    {
        [Fact]
        public void SupportFoldedLines()
        {
            var textLine =
                "DESCRIPTION:This is a lo" + Environment.NewLine +
                " ng description" + Environment.NewLine +
                "  that exists on a long line.";

            using var strReader = new StringReader(textLine);

            var icsParser = new IcsContentLineParser(strReader);

            Assert.NotNull(icsParser);

            IEnumerator<IcsContentLine> enumerator = icsParser.Read().GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal("DESCRIPTION", enumerator.Current.Name);
            Assert.Equal("This is a long description that exists on a long line.", enumerator.Current.Value);
        }

        [Fact]
        public void SupportLineWithMultipleParams()
        {
            var textLine =
                "ATTENDEE;RSVP=TRUE;ROLE=REQ-PARTICIPANT:mailto:" + Environment.NewLine +
                " jsmith@example.com" + Environment.NewLine +
                "RDATE;VALUE=DATE:19970304,19970504,19970704,19970904";

            using var strReader = new StringReader(textLine);

            var icsParser = new IcsContentLineParser(strReader);

            Assert.NotNull(icsParser);

            IEnumerator<IcsContentLine> enumerator = icsParser.Read().GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal("ATTENDEE", enumerator.Current.Name);
            Assert.Equal("TRUE", enumerator.Current.GetParameter("RSVP"));
            Assert.Equal("REQ-PARTICIPANT", enumerator.Current.GetParameter("ROLE"));
            Assert.Equal("mailto:jsmith@example.com", enumerator.Current.Value);

            Assert.True(enumerator.MoveNext());
            Assert.Equal("RDATE", enumerator.Current.Name);
            Assert.Equal("DATE", enumerator.Current.GetParameter("VALUE"));
            Assert.Equal("19970304,19970504,19970704,19970904", enumerator.Current.Value);
        }

        [Fact]
        public void SupportLineWithOneParam()
        {
            var textLine =
                "ATTENDEE;MEMBER=\"mailto:ietf-calsch@example.org\":mailto:jsmith@example.com";

            using var strReader = new StringReader(textLine);

            var icsParser = new IcsContentLineParser(strReader);

            Assert.NotNull(icsParser);

            IEnumerator<IcsContentLine> enumerator = icsParser.Read().GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal("ATTENDEE", enumerator.Current.Name);
            Assert.Equal("mailto:ietf-calsch@example.org", enumerator.Current.GetParameter("MEMBER"));
            Assert.Equal("mailto:jsmith@example.com", enumerator.Current.Value);
        }
    }
}
