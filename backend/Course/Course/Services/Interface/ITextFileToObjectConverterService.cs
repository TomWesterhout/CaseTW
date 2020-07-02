using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Course.Services
{
    public interface ITextFileToObjectConverterService
    {
        Task<string> ExtractObjectsFromTextFile(HttpPostedFile textFile);
    }
}
