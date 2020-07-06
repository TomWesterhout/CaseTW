using Course.Services;
using Course.Services.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Tests.Services
{
    [TestClass]
    public class TextFileValidationServiceTest
    {
        [TestMethod]
        public void ValidateTextFile_ShouldReturnValidResponse()
        {
            var textFileValidationService = new TextFileValidationService(); // The reason for creating a new instance for each method is because otherwise the tests will faill when run collectively.

            string[] textFile = new string[]
            {
                "Titel: C# Programmeren",
                "Cursuscode: CNETIN",
                "Duur: 5 dagen",
                "Startdatum: 8/10/2018"
            };

            List<string> expectedResult = new List<string>
            {
                "Valid"
            };

            List<string> actualResult = textFileValidationService.ValidateTextFile(textFile);

            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.Count == 1);
            Assert.AreEqual(expectedResult.Count(), actualResult.Count());
            Assert.AreEqual(expectedResult[0], actualResult[0]);
        }

        [TestMethod]
        public void ValidateTextFile_ShouldReturnInvalidResponseOnLineThree_DueToWrongAttribute()
        {
            var textFileValidationService = new TextFileValidationService();

            string[] textFile = new string[]
           {
                "Titel: C# Programmeren",
                "Cursuscode: CNETIN",
                "Startdatum: 8/10/2018"
           };

            List<string> expectedResult = new List<string>
            {
                "error",
                "Bestand is niet in correct formaat op regel 3.",
                "Er zijn geen cursusinstanties toegevoegd."
            };

            List<string> actualResult = textFileValidationService.ValidateTextFile(textFile);

            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.Count == 3);
            Assert.AreEqual(expectedResult.Count(), actualResult.Count());
            Assert.AreEqual(expectedResult[0], actualResult[0]);
            Assert.AreEqual(expectedResult[1], actualResult[1]);
            Assert.AreEqual(expectedResult[2], actualResult[2]);
        }

        [TestMethod]
        public void ValidateTextFile_ShouldReturnInvalidResponseOnLineTwo()
        {
            var textFileValidationService = new TextFileValidationService();

            string[] textFile = new string[]
           {
                "Titel: C# Programmeren",
                "Duur: 5 dagen",
                "Cursuscode: CNETIN",
                "Startdatum: 8/10/2018"
           };

            List<string> expectedResult = new List<string>
            {
                "error",
                "Bestand is niet in correct formaat op regel 2.",
                "Er zijn geen cursusinstanties toegevoegd."
            };

            List<string> actualResult = textFileValidationService.ValidateTextFile(textFile);

            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.Count == 3);
            Assert.AreEqual(expectedResult.Count(), actualResult.Count());
            Assert.AreEqual(expectedResult[0], actualResult[0]);
            Assert.AreEqual(expectedResult[1], actualResult[1]);
            Assert.AreEqual(expectedResult[2], actualResult[2]);
        }

        [TestMethod]
        public void ValidateTextFile_ShouldReturnInvalidResponseOnLineFour()
        {
            var textFileValidationService = new TextFileValidationService();

            string[] textFile = new string[]
           {
                "Titel: C# Programmeren",
                "Cursuscode: CNETIN",
                "Duur: 5 dagen",
                "Startdatum: 8-10-2018"
           };

            List<string> expectedResult = new List<string>
            {
                "error",
                "Bestand is niet in correct formaat op regel 4.",
                "Er zijn geen cursusinstanties toegevoegd."
            };

            List<string> actualResult = textFileValidationService.ValidateTextFile(textFile);

            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.Count == 3);
            Assert.AreEqual(expectedResult.Count(), actualResult.Count());
            Assert.AreEqual(expectedResult[0], actualResult[0]);
            Assert.AreEqual(expectedResult[1], actualResult[1]);
            Assert.AreEqual(expectedResult[2], actualResult[2]);
        }

        [TestMethod]
        public void ValidateTextFile_ShouldReturnInvalidResponseOnLineThree_DueToDagen()
        {
            var textFileValidationService = new TextFileValidationService();

            string[] textFile = new string[]
           {
                "Titel: C# Programmeren",
                "Cursuscode: CNETIN",
                "Duur: 5",
                "Startdatum: 8/10/2018"
           };

            List<string> expectedResult = new List<string>
            {
                "error",
                "Bestand is niet in correct formaat op regel 3.",
                "Er zijn geen cursusinstanties toegevoegd."
            };

            List<string> actualResult = textFileValidationService.ValidateTextFile(textFile);

            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.Count == 3);
            Assert.AreEqual(expectedResult.Count(), actualResult.Count());
            Assert.AreEqual(expectedResult[0], actualResult[0]);
            Assert.AreEqual(expectedResult[1], actualResult[1]);
            Assert.AreEqual(expectedResult[2], actualResult[2]);
        }

        [TestMethod]
        public void ValidateTextFile_ShouldReturnInvalidResponseOnLineThree_DueToNoBlankLine()
        {
            var textFileValidationService = new TextFileValidationService();

            string[] textFile = new string[]
           {
                "Titel: C# Programmeren",
                "Cursuscode: CNETIN",
                "Duur: 5 dagen",
                "Startdatum: 8/10/2018",
                "Titel: Java Persistence API",
                "Cursuscode: JPA",
                "Duur: 2 dagen",
                "Startdatum: 10/10/2018"
           };

            List<string> expectedResult = new List<string>
            {
                "error",
                "Bestand is niet in correct formaat op regel 5.",
                "Er zijn geen cursusinstanties toegevoegd."
            };

            List<string> actualResult = textFileValidationService.ValidateTextFile(textFile);

            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.Count == 3);
            Assert.AreEqual(expectedResult.Count(), actualResult.Count());
            Assert.AreEqual(expectedResult[0], actualResult[0]);
            Assert.AreEqual(expectedResult[1], actualResult[1]);
            Assert.AreEqual(expectedResult[2], actualResult[2]);
        }
    }
}
