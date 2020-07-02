using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Course.Data.Interface;
using Course.Models;
using Course.Services;
using Newtonsoft.Json;

namespace Course.Controllers
{
    [RoutePrefix("Api/CursusInstantie")]
    public class CursusInstantieController : ApiController
    {
        private ICursusInstantieRepository _cursusInstantieRepository;
        private ITextFileToObjectConverterService _textFileToObjectConverterService;

        public CursusInstantieController(ICursusInstantieRepository cursusInstantieRepository, ITextFileToObjectConverterService textFileToObjectConverterService)
        {
            _cursusInstantieRepository = cursusInstantieRepository;
            _textFileToObjectConverterService = textFileToObjectConverterService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IEnumerable<CursusInstantie>> GetCursusInstantie()
        {
            var cursusInstantieData = await _cursusInstantieRepository.GetAllAsync();
            return cursusInstantieData.OrderBy(ci => ci.StartDatum);
        }

        [Route("Upload")]
        [HttpPost]
        public async Task<HttpResponseMessage> UploadTextFile()
        {
            HttpRequest httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count < 1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Geen tekstbestand gevonden.");
            }

            HttpPostedFile textFile = httpRequest.Files[0];

            string extractionResult = await _textFileToObjectConverterService.ExtractObjectsFromTextFile(textFile);

            return Request.CreateResponse(HttpStatusCode.Created, extractionResult);
        }
    }
}
