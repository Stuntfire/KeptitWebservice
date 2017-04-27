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
    public class SubAreasController : ApiController
    {
        private KeptitContext db = new KeptitContext();

        // GET: api/SubAreas
        public IQueryable<SubArea> GetSubAreas()
        {
            return db.SubAreas;
        }

        // GET: api/SubAreas/5
        [ResponseType(typeof(SubArea))]
        public IHttpActionResult GetSubArea(int id)
        {
            SubArea subArea = db.SubAreas.Find(id);
            if (subArea == null)
            {
                return NotFound();
            }

            return Ok(subArea);
        }

        // PUT: api/SubAreas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubArea(int id, SubArea subArea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subArea.SubAreaID)
            {
                return BadRequest();
            }

            db.Entry(subArea).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubAreaExists(id))
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

        // POST: api/SubAreas
        [ResponseType(typeof(SubArea))]
        public IHttpActionResult PostSubArea(SubArea subArea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubAreas.Add(subArea);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SubAreaExists(subArea.SubAreaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = subArea.SubAreaID }, subArea);
        }

        // DELETE: api/SubAreas/5
        [ResponseType(typeof(SubArea))]
        public IHttpActionResult DeleteSubArea(int id)
        {
            SubArea subArea = db.SubAreas.Find(id);
            if (subArea == null)
            {
                return NotFound();
            }

            db.SubAreas.Remove(subArea);
            db.SaveChanges();

            return Ok(subArea);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubAreaExists(int id)
        {
            return db.SubAreas.Count(e => e.SubAreaID == id) > 0;
        }
    }
}