using Course.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Course.Services
{
    public class TextFileValidationService : ITextFileValidationService
    {
        private List<string> validationResponse = new List<string>();
        public List<string> ValidateTextFile(string[] textFile)
        {
            for (int lineIndex = 0; lineIndex < textFile.Length; lineIndex++)
            {
                switch (lineIndex % 5)
                {
                    case 0:
                        if (!IsTitleValid(textFile[lineIndex]))
                        {
                            InvalidResponse(lineIndex);
                            return validationResponse;
                        }
                        break;
                    case 1:
                        if (!IsCursusCodeValid(textFile[lineIndex]))
                        {
                            InvalidResponse(lineIndex);
                            return validationResponse;
                        }
                        break;
                    case 2:
                        if (!IsDuurValid(textFile[lineIndex]))
                        {
                            InvalidResponse(lineIndex);
                            return validationResponse;
                        }
                        break;
                    case 3:
                        if (!IsStartDatumValid(textFile[lineIndex]))
                        {
                            InvalidResponse(lineIndex);
                            return validationResponse;
                        }
                        break;
                    case 4:
                        if (!string.IsNullOrEmpty(textFile[lineIndex]))
                        {
                            InvalidResponse(lineIndex);
                            return validationResponse;
                        }
                        break;
                    default:
                        break;
                }
            }
            ValidResponse();
            return validationResponse;
        }

        // Validation Methods
        private bool IsTitleValid(string line)
        {
            Regex regex = new Regex(@"^Titel:\s.+");
            return regex.IsMatch(line);
        }

        private bool IsCursusCodeValid(string line)
        {
            Regex regex = new Regex(@"^Cursuscode:\s.+");
            return regex.IsMatch(line);
        }

        private bool IsDuurValid(string line)
        {
            Regex regex = new Regex(@"^Duur:\s\d\sdagen");
            return regex.IsMatch(line);
        }

        private bool IsStartDatumValid(string line)
        {
            Regex regex = new Regex(@"^Startdatum:\s\d{1,2}\/\d{1,2}\/\d{4}$");
            return regex.IsMatch(line);
        }

        // Response Methods

        private void InvalidResponse(int lineIndex)
        {
            validationResponse.Add("error");
            validationResponse.Add(string.Format("Bestand is niet in correct formaat op regel {0}.", lineIndex + 1));
            validationResponse.Add("Er zijn geen cursusinstanties toegevoegd.");
        }

        private void ValidResponse()
        {
            validationResponse.Add("Valid");
        }
    }
}