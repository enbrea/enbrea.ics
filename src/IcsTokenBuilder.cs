#region ENBREA.ICS Copyright (C) 2022 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA.ICS 
 *    
 *    Copyright (C) 2022 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using System.Text;

namespace Enbrea.Ics
{
    public class IcsTokenBuilder
    {
        private readonly StringBuilder _value;
        private IcsTokenType _type;

        public IcsTokenBuilder(IcsTokenType type)
        {
            _type = type;
            _value = new StringBuilder();
        }

        public IcsTokenType Type
        {
            get { return _type; }
        }

        public void Append(char c)
        {
            _value.Append(c);
        }

        public void Reset(IcsTokenType newType)
        {
            _type = newType;
            _value.Clear();
        }

        public IcsToken ToToken()
        {
            return new IcsToken(_type, _value.ToString());
        }
    }
}