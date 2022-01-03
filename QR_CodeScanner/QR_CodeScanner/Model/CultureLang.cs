using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace QR_CodeScanner.Model
{
    public class CultureLang
    {
        public string GetCulture()
        {
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString();
            return culture;
        }
    }
}
