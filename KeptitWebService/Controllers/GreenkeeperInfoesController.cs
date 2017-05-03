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
    public class GreenkeeperInfoesController : ApiController
    {
        private KeptitContextView db = new KeptitContextView();

        // GET: api/GreenkeeperInfoes
        public IQueryable<GreenkeeperInfo> GetGreenkeeperInfoes()
        {
            return db.GreenkeeperInfoes;
        }

        // GET: api/GreenkeeperInfoes/5
        [ResponseType(typeof(GreenkeeperInfo))]
        public IHttpActionResult GetGreenkeeperInfo(int id)
        {
            GreenkeeperInfo greenkeeperInfo = db.GreenkeeperInfoes.Find(id);
            if (greenkeeperInfo == null)
            {
                return NotFound();
            }

            return Ok(greenkeeperInfo);
        }

        // PUT: api/GreenkeeperInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGreenkeeperInfo(int id, GreenkeeperInfo greenkeeperInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != greenkeeperInfo.GreenkeeperID)
            {
                return BadRequest();
            }

            db.Entry(greenkeeperInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreenkeeperInfoExists(id))
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

        // POST: api/GreenkeeperInfoes
        [ResponseType(typeof(GreenkeeperInfo))]
        public IHttpActionResult PostGreenkeeperInfo(GreenkeeperInfo greenkeeperInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GreenkeeperInfoes.Add(greenkeeperInfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GreenkeeperInfoExists(greenkeeperInfo.GreenkeeperID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = greenkeeperInfo.GreenkeeperID }, greenkeeperInfo);
        }

        // DELETE: api/GreenkeeperInfoes/5
        [ResponseType(typeof(GreenkeeperInfo))]
        public IHttpActionResult DeleteGreenkeeperInfo(int id)
        {
            GreenkeeperInfo greenkeeperInfo = db.GreenkeeperInfoes.Find(id);
            if (greenkeeperInfo == null)
            {
                return NotFound();
            }

            db.GreenkeeperInfoes.Remove(greenkeeperInfo);
            db.SaveChanges();

            return Ok(greenkeeperInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GreenkeeperInfoExists(int id)
        {
            return db.GreenkeeperInfoes.Count(e => e.GreenkeeperID == id) > 0;
        }
    }
}