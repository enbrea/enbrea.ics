#region ENBREA.ICS - Copyright (C) 2023 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA.ICS 
 *    
 *    Copyright (C) 2023 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using System.Collections.Generic;

namespace Enbrea.Ics
{
    internal class IcsDaylightRuleBuilder : IcsTimeZoneRuleBuilder<IcsDaylightRule>
    {
        public IcsDaylightRuleBuilder(IList<IcsDaylightRule> timeZoneRuleList)
            : base(IcsComponentNames.Daylight, timeZoneRuleList)
        {
        }
    }
}