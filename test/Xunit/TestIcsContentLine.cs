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
    /// Unit tests for <see cref="IcsContentLine"/>.
    /// </summary>
    public class TestIcsContentLine
    {
        [Fact]
        public void SupportUnfoldedLines()
        {
            var textLine =
                "DESCRIPTION:This is a lo" + Environment.NewLine +
                " ng description that exis" + Environment.NewLine +
                " ts on a long line.";

            var contentLine = new IcsContentLine();

            contentLine.Name = "DESCRIPTION";
            contentLine.Value = "This is a long description that exists on a long line.";

            Assert.Equal(textLine, contentLine.ToString(24));
        }

        [Fact]
        public void SupportLineWithMultipleParams()
        {
            var textLine =
                "ATTENDEE;RSVP=TRUE;ROLE=REQ-PARTICIPANT:mailto:" + Environment.NewLine +
                " jsmith@example.com";

            var contentLine = new IcsContentLine();

            contentLine.Name = "ATTENDEE";
            contentLine.SetParameter("RSVP", "TRUE");
            contentLine.SetParameter("ROLE", "REQ-PARTICIPANT");
            contentLine.Value = "mailto:jsmith@example.com";

            Assert.Equal(textLine, contentLine.ToString(47));
        }

        [Fact]
        public void SupportLineWithOneParam()
        {
            var textLine =
                "ATTENDEE;MEMBER=\"mailto:ietf-calsch@example.org\":mailto:jsmith@example.com";

            var contentLine = new IcsContentLine();

            contentLine.Name = "ATTENDEE";
            contentLine.SetParameter("MEMBER", "mailto:ietf-calsch@example.org");
            contentLine.Value = "mailto:jsmith@example.com";

            Assert.Equal(textLine, contentLine.ToString());
        }
    }
}
