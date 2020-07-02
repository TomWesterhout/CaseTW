using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course.Data.StaticText
{
    public class TextFileConverterResponseText
    {
        public static readonly string baseText = "Er zijn {0} cursussen en {1} cursusinstanties toegevoegd.";

        public static readonly string duplicateText = "Er zijn {0} duplicaten tegengekomen.";
    }
}