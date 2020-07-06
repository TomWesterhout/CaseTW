using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Course.Services.Interface;
using Course.Data.Interface;
using Course.Services;
using System.Web;

namespace Course.Tests.Services
{
    [TestClass]
    public class TextFileToAttributeConverterServiceTest
    {
        private static ITextFileToAttributeConverterService _textFileToAttributeConverterService;
        private static string[] _processedText;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            _textFileToAttributeConverterService = new TextFileToAttributeConverterService();
            _processedText = new string[]
            {
                "Titel: C# Programmeren",
                "Cursuscode: CNETIN",
                "Duur: 5 dagen",
                "Startdatum: 8/10/2018",
                ""
            };
        }

        [TestMethod]
        public void ConvertTitel_ShouldReturnMatchedValue()
        {
            int index = 0;
            string expectedResponse = "C# Programmeren";
            string actualResponse = _textFileToAttributeConverterService.ConvertTitel(index, _processedText);

            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestMethod]
        public void ConvertCode_ShouldReturnMatchedValue()
        {
            int index = 0;
            string expectedResponse = "CNETIN";
            string actualResponse = _textFileToAttributeConverterService.ConvertCode(index, _processedText);

            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestMethod]
        public void ConvertDuur_ShouldReturnMatchedValue()
        {
            int index = 0;
            int expectedResponse = 5;
            int actualResponse = _textFileToAttributeConverterService.ConvertDuur(index, _processedText);

            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestMethod]
        public void ConvertStartdatum_ShouldReturnMatchedValue()
        {
            int index = 0;
            DateTime expectedResponse = new DateTime(2018, 10, 08);
            DateTime actualResponse = _textFileToAttributeConverterService.ConvertStartdatum(index, _processedText);

            Assert.AreEqual(expectedResponse, actualResponse);
        }
    }
}
