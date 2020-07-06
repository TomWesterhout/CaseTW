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
        public string ConvertTitel(int index, string[] processedText)
        {
            Match match = Regex.Match(processedText[index], @":\s(.*)");
            if (match.Success && match.Groups.Count == 2)
            {
                return match.Groups[1].ToString();
            }
            Debug.WriteLine(string.Format("No Titel found at line ${0}", index));
            return string.Empty;
        }

        public string ConvertCode(int index, string[] processedText)
        {
            Match match = Regex.Match(processedText[index + 1], @":\s(.*)");
            if (match.Success && match.Groups.Count == 2)
            {
                return match.Groups[1].ToString();
            }
            Debug.WriteLine(string.Format("No Code found at line ${0}", index + 1));
            return string.Empty;
        }

        public int ConvertDuur(int index, string[] processedText)
        {
            Match match = Regex.Match(processedText[index + 2], @"[Duur:\s]\d");
            if (match.Success)
            {
                return Int32.Parse(match.Value);
            }
            Debug.WriteLine(string.Format("No number found at line ${0}", index + 2));
            return 0;
        }

        public DateTime ConvertStartdatum(int index, string[] processedText)
        {
            Match match = Regex.Match(processedText[index + 3], @"[Startdatum:\s]\d{1,2}\/\d{1,2}\/\d{4}$");
            if (match.Success)
            {
                return DateTime.Parse(match.Value);
            }
            Debug.WriteLine(string.Format("No date found at line ${0}", index + 3));
            return new DateTime();
        }
    }
}