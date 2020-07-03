using Course.Services.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Course.Services
{
    public class TextFileToAttributeConverterService : ITextFileToAttributeConverterService
    {
        private string[] _processedText;

        public TextFileToAttributeConverterService(string[] processedText)
        {
            _processedText = processedText;
        }
        public string ConvertTitel(int index)
        {
            Match match = Regex.Match(_processedText[index], @"[^:\s]*$");
            if (match.Success)
            {
                return match.Value;
            }
            return string.Empty;
        }

        public string ConvertCode(int index)
        {
            Match match = Regex.Match(_processedText[index + 1], @"[^:\s]*$");
            if (match.Success)
            {
                return match.Value;
            }
            return string.Empty;
        }

        public int ConvertDuur(int index)
        {
            Match match = Regex.Match(_processedText[index + 2], @"[Duur:\s]\d");
            if (match.Success)
            {
                return Int32.Parse(match.Value);
            }
            Debug.WriteLine(string.Format("No number found at line ${0}", index + 2));
            return 0;
        }

        public DateTime ExtractStartdatum(int index)
        {
            Match match = Regex.Match(_processedText[index + 3], @"[Startdatum:\s]\d{1,2}\/\d{1,2}\/\d{4}$");
            if (match.Success)
            {
                return DateTime.Parse(match.Value);
            }
            Debug.WriteLine(string.Format("No date found at line ${0}", index + 2));
            return new DateTime();
        }
    }
}