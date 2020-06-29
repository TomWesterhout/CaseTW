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
using Course.Models;

namespace Course.Controllers
{
    public class CursusController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Cursus
        public IQueryable<Cursus> GetCursus()
        {
            return db.Cursus;
        }

        // GET: api/Cursus/5
        [ResponseType(typeof(Cursus))]
        public async Task<IHttpActionResult> GetCursus(int id)
        {
            Cursus cursus = await db.Cursus.FindAsync(id);
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

            db.Entry(cursus).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursusExists(id))
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

            db.Cursus.Add(cursus);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cursus.Id }, cursus);
        }

        // DELETE: api/Cursus/5
        [ResponseType(typeof(Cursus))]
        public async Task<IHttpActionResult> DeleteCursus(int id)
        {
            Cursus cursus = await db.Cursus.FindAsync(id);
            if (cursus == null)
            {
                return NotFound();
            }

            db.Cursus.Remove(cursus);
            await db.SaveChangesAsync();

            return Ok(cursus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CursusExists(int id)
        {
            return db.Cursus.Count(e => e.Id == id) > 0;
        }
    }
}