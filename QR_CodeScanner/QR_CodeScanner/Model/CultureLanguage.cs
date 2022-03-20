using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace QR_CodeScanner.Model
{
    public static class CultureLanguage
    {
        public static string GetCulture()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString();
            return culture;
        }
    }
}
