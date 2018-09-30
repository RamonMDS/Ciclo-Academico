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
    public class TurmaController : ApiController
    {
        private Ciclo_AcademicoContext db = new Ciclo_AcademicoContext();

        // GET: api/Turma
        public IQueryable<Turma> GetTurma()
        {
            return db.Turma;
        }

        // GET: api/Turma/5
        [ResponseType(typeof(Turma))]
        public async Task<IHttpActionResult> GetTurma(Guid id)
        {
            Turma turma = await db.Turma.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }

            return Ok(turma);
        }

        // PUT: api/Turma/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTurma(Guid id, Turma turma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turma.Id)
            {
                return BadRequest();
            }

            db.Entry(turma).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaExists(id))
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

        // POST: api/Turma
        [ResponseType(typeof(Turma))]
        public async Task<IHttpActionResult> PostTurma(Turma turma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Turma.Add(turma);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TurmaExists(turma.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = turma.Id }, turma);
        }

        // DELETE: api/Turma/5
        [ResponseType(typeof(Turma))]
        public async Task<IHttpActionResult> DeleteTurma(Guid id)
        {
            Turma turma = await db.Turma.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }

            db.Turma.Remove(turma);
            await db.SaveChangesAsync();

            return Ok(turma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TurmaExists(Guid id)
        {
            return db.Turma.Count(e => e.Id == id) > 0;
        }
    }
}