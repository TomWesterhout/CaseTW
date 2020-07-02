using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Course.Data;
using Course.Data.Interface;
using Course.Data.Repository;
using Course.Models;

namespace Course.Controllers
{
    public class CursusController : ApiController
    {
        private ICursusRepository _cursusRepository;

        public CursusController(ICursusRepository cursusRepository)
        {
            _cursusRepository = cursusRepository;
        }

        // GET: api/Cursus
        public async Task<IEnumerable<Cursus>> GetCursus()
        {
            return await _cursusRepository.GetAllAsync();
        }

        // GET: api/Cursus/5
        [ResponseType(typeof(Cursus))]
        public async Task<IHttpActionResult> GetCursus(int id)
        {
            Cursus cursus = await _cursusRepository.GetByIdAsync(id);
            if (cursus == null)
            {
                return NotFound();
            }

            return Ok(cursus);
        }

        // PUT: api/Cursus/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCursus(int id, Cursus cursus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cursus.Id)
            {
                return BadRequest();
            }

            _cursusRepository.Update(cursus);

            try
            {
                await _cursusRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CursusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cursus
        [ResponseType(typeof(Cursus))]
        public async Task<IHttpActionResult> PostCursus(Cursus cursus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _cursusRepository.Add(cursus);
            await _cursusRepository.SaveAsync();

            return CreatedAtRoute("DefaultApi", new { id = cursus.Id }, cursus);
        }

        // DELETE: api/Cursus/5
        [ResponseType(typeof(Cursus))]
        public async Task<IHttpActionResult> DeleteCursus(int id)
        {
            Cursus cursus = await _cursusRepository.GetByIdAsync(id);
            if (cursus == null)
            {
                return NotFound();
            }

            _cursusRepository.Remove(cursus);
            await _cursusRepository.SaveAsync();

            return Ok(cursus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cursusRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private async Task<bool> CursusExists(int id)
        {
            var cursus = await _cursusRepository.GetByIdAsync(id);
            return (cursus != null);
        }
    }
}