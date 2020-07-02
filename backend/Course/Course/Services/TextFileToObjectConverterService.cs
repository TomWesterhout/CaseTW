using Course.Data;
using Course.Data.Interface;
using Course.Data.Repository;
using Course.Data.StaticText;
using Course.Models;
using Course.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Course.Services
{
    public class TextFileToObjectConverterService : ITextFileToObjectConverterService
    {
        private ICursusInstantieRepository _cursusInstantieRepository;
        private ICursusRepository _cursusRepository;
        private ITextFileToAttributeConverterService _textFileToAttributeConverterService;
        private int cursusCount;
        private int cursusInstantieCount;
        private int duplicateCount;

        public TextFileToObjectConverterService(ApplicationDbContext context)
        {
            _cursusInstantieRepository = new CursusInstantieRepository(context);
            _cursusRepository = new CursusRepository(context);
        }

        public async Task<List<string>> ExtractObjectsFromTextFile(HttpPostedFile textFile)
        {
            string unprocessedText;
            using (StreamReader streamReader = new StreamReader(textFile.InputStream))
            {
                unprocessedText = streamReader.ReadToEnd();
            }

            string[] processedText = ProcessText(unprocessedText);
            _textFileToAttributeConverterService = new TextFileToAttributeConverterService(processedText);

            ResetCounters();

            try
            {
                List<Cursus> cursusObjecten = await ExtractCursusObjectsFromProcessedText(processedText);
                _cursusRepository.AddRange(cursusObjecten);
                await _cursusRepository.SaveAsync();

                List<CursusInstantie> cursusInstantieObjecten = await ExtractCursusInstantieObjectsFromProcessedText(processedText);
                _cursusInstantieRepository.AddRange(cursusInstantieObjecten);
                await _cursusInstantieRepository.SaveAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return CreateResponseMessages();
        }

        private string[] ProcessText(string unprocessedText)
        {
            return unprocessedText.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private async Task<List<Cursus>> ExtractCursusObjectsFromProcessedText(string[] processedText)
        {
            var cursusObjecten = new List<Cursus>();

            for (int i = 0; i < processedText.Length; i += 4)
            {
                Cursus cursusObject = InstantiateCursusObject(i, processedText);

                if (!await IsDuplicate(cursusObjecten, cursusObject))
                {
                    cursusObjecten.Add(cursusObject);
                    cursusCount++;
                }
            }
            return cursusObjecten;
        }

        private void ResetCounters()
        {
            cursusCount = 0;
            cursusInstantieCount = 0;
            duplicateCount = 0;
        }

        private Cursus InstantiateCursusObject(int index, string[] processedText)
        {
            return new Cursus
            {
                Titel = _textFileToAttributeConverterService.ConvertTitel(index),
                Duur = _textFileToAttributeConverterService.ConvertDuur(index),
                Code = _textFileToAttributeConverterService.ConvertCode(index)
            };
        }

        private async Task<bool> IsDuplicate(List<Cursus> cursusObjecten, Cursus cursusObject)
        {
            var databaseCursusObjects = await _cursusRepository.GetWhereAsync(c => c.Code == cursusObject.Code);
            return cursusObjecten.Any(co => co.Code == cursusObject.Code) || (databaseCursusObjects.Count() > 0);
        }

        private async Task<List<CursusInstantie>> ExtractCursusInstantieObjectsFromProcessedText(string[] processedText)
        {
            var cursusInstantieObjecten = new List<CursusInstantie>();

            for (int i = 0; i < processedText.Length; i += 4)
            {
                CursusInstantie cursusInstantieObject = await InstantiateCursusInstantieObject(i, processedText);

                if (await IsDuplicate(cursusInstantieObjecten, cursusInstantieObject))
                {
                    duplicateCount++;
                }
                else
                {
                    cursusInstantieObjecten.Add(cursusInstantieObject);
                    cursusCount++;
                }
            }
            return cursusInstantieObjecten;
        }

        private async Task<CursusInstantie> InstantiateCursusInstantieObject(int index, string[] processedText)
        {
            string cursusCode = _textFileToAttributeConverterService.ConvertCode(index);
            Cursus cursus = await _cursusRepository.FirstOrDefaultAsync(ci => ci.Code == cursusCode);

            return new CursusInstantie
            {
                StartDatum = _textFileToAttributeConverterService.ExtractStartdatum(index),
                CursusId = cursus.Id,
                Cursus = cursus
            };
        }

        private async Task<bool> IsDuplicate(List<CursusInstantie> cursusInstantieObjecten, CursusInstantie cursusInstantieObject)
        {
            var databaseCursusInstantieObjects = await _cursusInstantieRepository.GetWhereAsync(ci => ci.StartDatum == cursusInstantieObject.StartDatum && ci.Cursus.Code == cursusInstantieObject.Cursus.Code);
            return cursusInstantieObjecten.Any(cio => cio.StartDatum == cursusInstantieObject.StartDatum && cio.Cursus.Code == cursusInstantieObject.Cursus.Code) || (databaseCursusInstantieObjects.Count() > 0);
        }

        public List<string> CreateResponseMessages()
        {
            List<string> responseMessage = new List<string>();
            responseMessage.Add(string.Format(TextFileConverterResponseText.baseText, cursusCount, cursusInstantieCount));
            responseMessage.Add(duplicateCount > 0 ? string.Format(TextFileConverterResponseText.duplicateText, duplicateCount) : "");

            return responseMessage;
        }
    }
}