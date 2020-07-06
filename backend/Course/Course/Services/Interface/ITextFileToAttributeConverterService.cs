using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Services.Interface
{
    public interface ITextFileToAttributeConverterService
    {
        string ConvertTitel(int index, string[] processedText);
        int ConvertDuur(int index, string[] processedText);
        string ConvertCode(int index, string[] processedText);
        DateTime ConvertStartdatum(int i, string[] processedText);

    }
}
