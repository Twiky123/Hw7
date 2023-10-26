using System;
using System.Globalization;

namespace labatym8
{
    class ClassImplementingIFormattables : IFormattable
    {
        private int firstValue = 10;

        public override string ToString()
        {
            return ToString("G", NumberFormatInfo.CurrentInfo);
        }

        public string ToString(string format)
        {
            return ToString(format, NumberFormatInfo.CurrentInfo);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return firstValue.ToString("G", provider);
        }
    }
}