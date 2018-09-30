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
using Ciclo_Academico.Context;
using Ciclo_Academico.Models;

namespace Ciclo_Academico.Controllers
{
    public class ProvaController : ApiController
    {
        private Ciclo_AcademicoContext db = new Ciclo_AcademicoContext();

        // GET: api/Prova
        public IQueryable<Prova> GetProva()
        {
            return db.Prova;
        }

        // GET: api/Prova/5
        [ResponseType(typeof(Prova))]
        public async Task<IHttpActionResult> GetProva(Guid id)
        {
            Prova prova = await db.Prova.FindAsync(id);
            if (prova == null)
            {
                return NotFound();
            }

            return Ok(prova);
        }

        // PUT: api/Prova/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProva(Guid id, Prova prova)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prova.Id)
            {
                return BadRequest();
            }

            db.Entry(prova).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvaExists(id))
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

        // POST: api/Prova
        [ResponseType(typeof(Prova))]
        public async Task<IHttpActionResult> PostProva(Prova prova)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prova.Add(prova);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProvaExists(prova.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = prova.Id }, prova);
        }

        // DELETE: api/Prova/5
        [ResponseType(typeof(Prova))]
        public async Task<IHttpActionResult> DeleteProva(Guid id)
        {
            Prova prova = await db.Prova.FindAsync(id);
            if (prova == null)
            {
                return NotFound();
            }

            db.Prova.Remove(prova);
            await db.SaveChangesAsync();

            return Ok(prova);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProvaExists(Guid id)
        {
            return db.Prova.Count(e => e.Id == id) > 0;
        }
    }
}