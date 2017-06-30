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
using KeptitWebService;

namespace KeptitWebService.Controllers
{
    public class GreenkeepersController : ApiController
    {
        private KeptitContext db = new KeptitContext();

        // GET: api/Greenkeepers1
        public IQueryable<Greenkeeper> GetGreenkeepers()
        {
            return db.Greenkeepers;
        }

        // GET: api/Greenkeepers1/5
        [ResponseType(typeof(Greenkeeper))]
        public async Task<IHttpActionResult> GetGreenkeeper(int id)
        {
            Greenkeeper greenkeeper = await db.Greenkeepers.FindAsync(id);
            if (greenkeeper == null)
            {
                return NotFound();
            }

            return Ok(greenkeeper);
        }

        // PUT: api/Greenkeepers1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGreenkeeper(int id, Greenkeeper greenkeeper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != greenkeeper.GreenkeeperID)
            {
                return BadRequest();
            }

            db.Entry(greenkeeper).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreenkeeperExists(id))
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

        // POST: api/Greenkeepers1
        [ResponseType(typeof(Greenkeeper))]
        public async Task<IHttpActionResult> PostGreenkeeper(Greenkeeper greenkeeper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Greenkeepers.Add(greenkeeper);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GreenkeeperExists(greenkeeper.GreenkeeperID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = greenkeeper.GreenkeeperID }, greenkeeper);
        }

        // DELETE: api/Greenkeepers1/5
        [ResponseType(typeof(Greenkeeper))]
        public async Task<IHttpActionResult> DeleteGreenkeeper(int id)
        {
            Greenkeeper greenkeeper = await db.Greenkeepers.FindAsync(id);
            if (greenkeeper == null)
            {
                return NotFound();
            }

            db.Greenkeepers.Remove(greenkeeper);
            await db.SaveChangesAsync();

            return Ok(greenkeeper);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GreenkeeperExists(int id)
        {
            return db.Greenkeepers.Count(e => e.GreenkeeperID == id) > 0;
        }
    }
}