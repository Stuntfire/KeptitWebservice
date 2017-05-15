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
    public class GreenkeeperMinutterPrDagsController : ApiController
    {
        private KeptitContextView2 db = new KeptitContextView2();

        // GET: api/GreenkeeperMinutterPrDags
        public IQueryable<GreenkeeperMinutterPrDag> GetGreenkeeperMinutterPrDags()
        {
            return db.GreenkeeperMinutterPrDags;
        }

        // GET: api/GreenkeeperMinutterPrDags/5
        [ResponseType(typeof(GreenkeeperMinutterPrDag))]
        public IHttpActionResult GetGreenkeeperMinutterPrDag(string id)
        {
            GreenkeeperMinutterPrDag greenkeeperMinutterPrDag = db.GreenkeeperMinutterPrDags.Find(id);
            if (greenkeeperMinutterPrDag == null)
            {
                return NotFound();
            }

            return Ok(greenkeeperMinutterPrDag);
        }

        // PUT: api/GreenkeeperMinutterPrDags/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGreenkeeperMinutterPrDag(string id, GreenkeeperMinutterPrDag greenkeeperMinutterPrDag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != greenkeeperMinutterPrDag.GreenkeeperName)
            {
                return BadRequest();
            }

            db.Entry(greenkeeperMinutterPrDag).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreenkeeperMinutterPrDagExists(id))
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

        // POST: api/GreenkeeperMinutterPrDags
        [ResponseType(typeof(GreenkeeperMinutterPrDag))]
        public IHttpActionResult PostGreenkeeperMinutterPrDag(GreenkeeperMinutterPrDag greenkeeperMinutterPrDag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GreenkeeperMinutterPrDags.Add(greenkeeperMinutterPrDag);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GreenkeeperMinutterPrDagExists(greenkeeperMinutterPrDag.GreenkeeperName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = greenkeeperMinutterPrDag.GreenkeeperName }, greenkeeperMinutterPrDag);
        }

        // DELETE: api/GreenkeeperMinutterPrDags/5
        [ResponseType(typeof(GreenkeeperMinutterPrDag))]
        public IHttpActionResult DeleteGreenkeeperMinutterPrDag(string id)
        {
            GreenkeeperMinutterPrDag greenkeeperMinutterPrDag = db.GreenkeeperMinutterPrDags.Find(id);
            if (greenkeeperMinutterPrDag == null)
            {
                return NotFound();
            }

            db.GreenkeeperMinutterPrDags.Remove(greenkeeperMinutterPrDag);
            db.SaveChanges();

            return Ok(greenkeeperMinutterPrDag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GreenkeeperMinutterPrDagExists(string id)
        {
            return db.GreenkeeperMinutterPrDags.Count(e => e.GreenkeeperName == id) > 0;
        }
    }
}