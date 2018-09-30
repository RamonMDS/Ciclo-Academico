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
    public class AvaliacaoController : ApiController
    {
        private Ciclo_AcademicoContext db = new Ciclo_AcademicoContext();

        // GET: api/Avaliacao
        public IQueryable<Avaliacao> GetAvaliacaos()
        {
            return db.Avaliacao;
        }

        // GET: api/Avaliacao/5
        [ResponseType(typeof(Avaliacao))]
        public async Task<IHttpActionResult> GetAvaliacao(Guid id)
        {
            Avaliacao avaliacao = await db.Avaliacao.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return Ok(avaliacao);
        }

        // PUT: api/Avaliacao/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAvaliacao(Guid id, Avaliacao avaliacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != avaliacao.Id)
            {
                return BadRequest();
            }

            db.Entry(avaliacao).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvaliacaoExists(id))
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

        // POST: api/Avaliacao
        [ResponseType(typeof(Avaliacao))]
        public async Task<IHttpActionResult> PostAvaliacao(Avaliacao avaliacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Avaliacao.Add(avaliacao);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AvaliacaoExists(avaliacao.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = avaliacao.Id }, avaliacao);
        }

        // DELETE: api/Avaliacao/5
        [ResponseType(typeof(Avaliacao))]
        public async Task<IHttpActionResult> DeleteAvaliacao(Guid id)
        {
            Avaliacao avaliacao = await db.Avaliacao.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            db.Avaliacao.Remove(avaliacao);
            await db.SaveChangesAsync();

            return Ok(avaliacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AvaliacaoExists(Guid id)
        {
            return db.Avaliacao.Count(e => e.Id == id) > 0;
        }
    }
}