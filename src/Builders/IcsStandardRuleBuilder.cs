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

using System.Collections.Generic;

namespace Enbrea.Ics
{
    internal class IcsStandardRuleBuilder : IcsTimeZoneRuleBuilder<IcsStandardRule>
    {
        public IcsStandardRuleBuilder(IList<IcsStandardRule> timeZoneRuleList)
            : base(IcsComponentNames.Standard, timeZoneRuleList)
        {
        }
    }
}