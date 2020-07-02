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
            try
            {
                return _processedText[index].Substring(7);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return string.Empty;
        }

        public int ConvertDuur(int index)
        {
            try
            {
                string StarOfValue = _processedText[index + 2].Substring(6);
                return Int32.Parse(Regex.Match(StarOfValue, @"\d+").Value);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return 0;
        }

        public string ConvertCode(int index)
        {
            try
            {
                return _processedText[index + 1].Substring(12);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return string.Empty;
        }

        public DateTime ExtractStartdatum(int i)
        {
            try
            {
                string startOfValue = _processedText[i + 3].Substring(12);
                return DateTime.Parse(startOfValue);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return new DateTime();
        }
    }
}