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
using SalesCannon.Models;
using SalesDomain.Models;

namespace SalesApi.Controllers
{
    public class FincasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Fincas
        public IQueryable<Finca> GetFincas()
        {
            return db.Fincas;
        }

        // GET: api/Fincas/5
        [ResponseType(typeof(Finca))]
        public async Task<IHttpActionResult> GetFinca(int id)
        {
            Finca finca = await db.Fincas.FindAsync(id);
            if (finca == null)
            {
                return NotFound();
            }

            return Ok(finca);
        }

        // PUT: api/Fincas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFinca(int id, Finca finca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != finca.IdFinca)
            {
                return BadRequest();
            }

            db.Entry(finca).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FincaExists(id))
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

        // POST: api/Fincas
        [ResponseType(typeof(Finca))]
        public async Task<IHttpActionResult> PostFinca(Finca finca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fincas.Add(finca);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = finca.IdFinca }, finca);
        }

        // DELETE: api/Fincas/5
        [ResponseType(typeof(Finca))]
        public async Task<IHttpActionResult> DeleteFinca(int id)
        {
            Finca finca = await db.Fincas.FindAsync(id);
            if (finca == null)
            {
                return NotFound();
            }

            db.Fincas.Remove(finca);
            await db.SaveChangesAsync();

            return Ok(finca);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FincaExists(int id)
        {
            return db.Fincas.Count(e => e.IdFinca == id) > 0;
        }
    }
}