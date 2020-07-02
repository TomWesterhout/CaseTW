using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Services.Interface
{
    public interface ITextFileToAttributeConverterService
    {
        string ConvertTitel(int index);
        int ConvertDuur(int index);
        string ConvertCode(int index);
        DateTime ExtractStartdatum(int i);

    }
}
