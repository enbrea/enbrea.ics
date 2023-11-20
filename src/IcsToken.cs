#region ENBREA.ICS Copyright (C) 2023 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA.ICS 
 *    
 *    Copyright (C) 2023 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

namespace Enbrea.Ics
{
    public class IcsToken
    {
        private readonly IcsTokenType _type;
        private readonly string _value;

        public IcsToken(IcsTokenType type, string value)
        {
            _type = type;
            _value = value;
        }

        public IcsTokenType Type
        {
            get { return _type; }
        }

        public string Value
        {
            get { return _value; }
        }
    }
}