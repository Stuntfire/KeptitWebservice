using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KeptitWebService;

namespace KeptitWebService.Controllers
{
    public class GreenkeeperinfoTimersController : ApiController
    {
        private KeptitContextView db = new KeptitContextView();

        // GET: api/GreenkeeperinfoTimers
        public IQueryable<GreenkeeperinfoTimer> GetGreenkeeperinfoTimers()
        {
            return db.GreenkeeperinfoTimers;
        }

        // GET: api/GreenkeeperinfoTimers/5
        [ResponseType(typeof(GreenkeeperinfoTimer))]
        public IHttpActionResult GetGreenkeeperinfoTimer(string id)
        {
            GreenkeeperinfoTimer greenkeeperinfoTimer = db.GreenkeeperinfoTimers.Find(id);
            if (greenkeeperinfoTimer == null)
            {
                return NotFound();
            }

            return Ok(greenkeeperinfoTimer);
        }

        // PUT: api/GreenkeeperinfoTimers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGreenkeeperinfoTimer(string id, GreenkeeperinfoTimer greenkeeperinfoTimer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != greenkeeperinfoTimer.GreenkeeperName)
            {
                return BadRequest();
            }

            db.Entry(greenkeeperinfoTimer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreenkeeperinfoTimerExists(id))
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

        // POST: api/GreenkeeperinfoTimers
        [ResponseType(typeof(GreenkeeperinfoTimer))]
        public IHttpActionResult PostGreenkeeperinfoTimer(GreenkeeperinfoTimer greenkeeperinfoTimer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GreenkeeperinfoTimers.Add(greenkeeperinfoTimer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GreenkeeperinfoTimerExists(greenkeeperinfoTimer.GreenkeeperName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = greenkeeperinfoTimer.GreenkeeperName }, greenkeeperinfoTimer);
        }

        // DELETE: api/GreenkeeperinfoTimers/5
        [ResponseType(typeof(GreenkeeperinfoTimer))]
        public IHttpActionResult DeleteGreenkeeperinfoTimer(string id)
        {
            GreenkeeperinfoTimer greenkeeperinfoTimer = db.GreenkeeperinfoTimers.Find(id);
            if (greenkeeperinfoTimer == null)
            {
                return NotFound();
            }

            db.GreenkeeperinfoTimers.Remove(greenkeeperinfoTimer);
            db.SaveChanges();

            return Ok(greenkeeperinfoTimer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GreenkeeperinfoTimerExists(string id)
        {
            return db.GreenkeeperinfoTimers.Count(e => e.GreenkeeperName == id) > 0;
        }
    }
}