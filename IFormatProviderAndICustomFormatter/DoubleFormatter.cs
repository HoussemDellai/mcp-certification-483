using System;
using System.Globalization;

namespace IFormatProviderAndICustomFormatter
{
    public class DoubleFormatter : IFormatProvider, ICustomFormatter
    {
        // always use dot separator for doubles
        private CultureInfo enUsCulture = CultureInfo.GetCultureInfo("en-US");

        //implement IFormatProvider
        public object GetFormat(Type formatType)
        {
            return (formatType == typeof(ICustomFormatter)) ? this : null;
        }

        //implement ICustomFormatter
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is double)
            {
                if (string.IsNullOrEmpty(format))
                {
                    // by default, format doubles to 3 decimal places
                    return string.Format(enUsCulture, "{0:0.000}", arg);
                }
                else
                {
                    // if user supplied own format use it
                    return ((double)arg).ToString(format, enUsCulture);
                }
            }
            // format everything else normally
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, formatProvider);
            else
                return arg.ToString();
        }
    }
}