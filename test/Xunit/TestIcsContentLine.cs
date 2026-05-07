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
    /// Unit tests for <see cref="IcsContentLine"/>.
    /// </summary>
    public class TestIcsContentLine
    {
        [Fact]
        public void ToString_FoldsLongLine_AtSpecifiedLength()
        {
            var textLine =
                "DESCRIPTION:This is a lo" + Environment.NewLine +
                " ng description that exis" + Environment.NewLine +
                " ts on a long line.";

            var contentLine = new IcsContentLine
            {
                Name = "DESCRIPTION",
                Value = "This is a long description that exists on a long line."
            };

            Assert.Equal(textLine, contentLine.ToString(24));
        }

        [Fact]
        public void ToString_SerializesLine_WithMultipleParameters()
        {
            var textLine =
                "ATTENDEE;RSVP=TRUE;ROLE=REQ-PARTICIPANT:mailto:" + Environment.NewLine +
                " jsmith@example.com";

            var contentLine = new IcsContentLine
            {
                Name = "ATTENDEE"
            };
            contentLine.SetParameter("RSVP", "TRUE");
            contentLine.SetParameter("ROLE", "REQ-PARTICIPANT");
            contentLine.Value = "mailto:jsmith@example.com";

            Assert.Equal(textLine, contentLine.ToString(47));
        }

        [Fact]
        public void ToString_SerializesLine_WithQuotedParameter()
        {
            var textLine =
                "ATTENDEE;MEMBER=\"mailto:ietf-calsch@example.org\":mailto:jsmith@example.com";

            var contentLine = new IcsContentLine
            {
                Name = "ATTENDEE"
            };
            contentLine.SetParameter("MEMBER", "mailto:ietf-calsch@example.org");
            contentLine.Value = "mailto:jsmith@example.com";

            Assert.Equal(textLine, contentLine.ToString());
        }
    }
}
