using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Ciclo_Academico.Context;
using Ciclo_Academico.Models;

namespace Ciclo_Academico.Controllers
{
    public class AlunoController : ApiController
    {
        private Ciclo_AcademicoContext db = new Ciclo_AcademicoContext();

        // GET: api/Aluno
        public IQueryable<Aluno> GetAluno()
        {
            return db.Aluno;
        }

        // GET: api/Aluno/5
        [ResponseType(typeof(Aluno))]
        public async Task<IHttpActionResult> GetAluno(Guid id)
        {
            Aluno aluno = await db.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // PUT: api/Aluno/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAluno(Guid id, Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aluno.Id)
            {
                return BadRequest();
            }

            db.Entry(aluno).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
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

        // POST: api/Aluno
        [ResponseType(typeof(Aluno))]
        public async Task<IHttpActionResult> PostAluno(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Aluno.Add(aluno);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlunoExists(aluno.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aluno.Id }, aluno);
        }

        // DELETE: api/Aluno/5
        [ResponseType(typeof(Aluno))]
        public async Task<IHttpActionResult> DeleteAluno(Guid id)
        {
            Aluno aluno = await db.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            db.Aluno.Remove(aluno);
            await db.SaveChangesAsync();

            return Ok(aluno);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlunoExists(Guid id)
        {
            return db.Aluno.Count(e => e.Id == id) > 0;
        }
    }
}