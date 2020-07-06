using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Course.Configuration;
using Course.Controllers;
using Course.Data;
using Course.Data.Interface;
using Course.Models;
using Course.Services;
using Course.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Course.Tests.Controllers
{
    [TestClass]
    public class CursusInstantieControllerTest
    {
        private static Mock<ICursusInstantieRepository> _cursusInstantierepository;
        private static Mock<ITextFileToObjectConverterService> _textFileToObjectConverterService;
        private static CursusInstantieController _cursusInstantieController;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            _cursusInstantierepository = new Mock<ICursusInstantieRepository>();
            _textFileToObjectConverterService = new Mock<ITextFileToObjectConverterService>();

            AutoMapperProfile profile = new AutoMapperProfile();
            MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            IMapper mapper = new Mapper(configuration);

            _cursusInstantieController = new CursusInstantieController
            (
                _cursusInstantierepository.Object,
                _textFileToObjectConverterService.Object,
                mapper
            );
        }

        [TestMethod]
        public void GetCursusInstantieByWeek_ShouldReturnCursusInstanties()
        {
            int cursusWeek = 28; // Week number matches CursusInstantie StartDatum.
            int cursusYear = 2020;

            Cursus cursus = new Cursus { Id = 1, Duur = 5, Titel = "Java Persistence API", Code = "JPA" };

            CursusInstantie cursusInstantie = new CursusInstantie()
            {
                StartDatum = new DateTime(06 / 07 / 2020),
                CursusId = cursus.Id,
                Cursus = cursus
            };

            IEnumerable<CursusInstantie> cursusInstantieList = new List<CursusInstantie> { cursusInstantie };

            Task<IEnumerable<CursusInstantie>> getByWeekAndYearMethodResponse = Task.FromResult(cursusInstantieList);

            _cursusInstantierepository.Setup(cir => cir.GetByWeekAndYear(cursusWeek, cursusYear))
                .Returns(getByWeekAndYearMethodResponse);

            Task<IEnumerable<CursusInstantieViewModel>> actualResponse = _cursusInstantieController.GetCursusInstantieByWeek(cursusWeek, cursusYear);

            Assert.IsNotNull(actualResponse);
            Assert.IsInstanceOfType(actualResponse, typeof(Task<IEnumerable<CursusInstantieViewModel>>));
            Assert.IsTrue(actualResponse.Result.Count() == 1);
        }

        [TestMethod]
        public void GetCursusInstantieByWeek_ShouldNotReturnCursusInstanties()
        {
            int cursusWeek = 20; 
            int cursusYear = 2020;

            IEnumerable<CursusInstantie> cursusInstantieList = new List<CursusInstantie>();

            Task<IEnumerable<CursusInstantie>> getByWeekAndYearMethodResponse = Task.FromResult(cursusInstantieList);

            _cursusInstantierepository.Setup(cir => cir.GetByWeekAndYear(cursusWeek, cursusYear))
                .Returns(getByWeekAndYearMethodResponse);

            Task<IEnumerable<CursusInstantieViewModel>> actualResponse = _cursusInstantieController.GetCursusInstantieByWeek(cursusWeek, cursusYear);

            Assert.IsNotNull(actualResponse);
            Assert.IsInstanceOfType(actualResponse, typeof(Task<IEnumerable<CursusInstantieViewModel>>));
            Assert.IsTrue(actualResponse.Result.Count() == 0);
        }
    }
}
