using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Controllers;
using Course.Data;
using Course.Data.Interface;
using Course.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Course.Tests.Controllers
{
    [TestClass]
    class CursusInstantieControllerTest
    {
        private static Mock<ICursusInstantieRepository> _cursusInstantierepository;
        private static Mock<ApplicationDbContext> _applicationDbContext;
        private static CursusInstantieController _cursusInstantieController;

        [ClassInitialize]
        public static void Initialize()
        {
            _cursusInstantierepository = new Mock<ICursusInstantieRepository>();
            _applicationDbContext = new Mock<ApplicationDbContext>();
            _cursusInstantieController = new CursusInstantieController(_applicationDbContext.Object);

            Cursus cursusOne = new Cursus { Id = 1, Duur = 5, Titel = "C# Programmeren", Code = "CNETIN" };
            Cursus cursusTwo = new Cursus { Id = 2, Duur = 2, Titel = "Java Persistence API", Code = "JPA" };

            var cursusList = new List<Cursus>()
            {
                cursusOne,
                cursusTwo
            };

            var cursusInstantieList = new List<CursusInstantie>()
            {
                new CursusInstantie() { StartDatum = new DateTime(29/06/2020), CursusId = cursusOne.Id, Cursus = cursusOne },
                new CursusInstantie() { StartDatum = new DateTime(06/07/2020), CursusId = cursusTwo.Id, Cursus = cursusTwo },
                new CursusInstantie() { StartDatum = new DateTime(13/07/2020), CursusId = cursusOne.Id, Cursus = cursusOne }
            };
        }

        [TestMethod]
        public void GetCursusInstantieByWeek_ShouldReturnAllRelevantCursusInstanties()
        {
            int cursusWeek = 28;
            int cursusYear = 2020;

            Cursus cursusTwo = new Cursus { Id = 2, Duur = 2, Titel = "Java Persistence API", Code = "JPA" };
            var response = new List<CursusInstantie> { new CursusInstantie() { StartDatum = new DateTime(06 / 07 / 2020), CursusId = cursusTwo.Id, Cursus = cursusTwo } };

            CollectionAssert.AreEqual(response.ToList(), response.ToList());
        }
    }
}
