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
    public class GreenTasksController : ApiController
    {
        private KeptitContext db = new KeptitContext();

        // GET: api/GreenTasks
        public IQueryable<GreenTask> GetGreenTasks()
        {
            return db.GreenTasks;
        }

        // GET: api/GreenTasks/5
        [ResponseType(typeof(GreenTask))]
        public IHttpActionResult GetGreenTask(int id)
        {
            GreenTask greenTask = db.GreenTasks.Find(id);
            if (greenTask == null)
            {
                return NotFound();
            }

            return Ok(greenTask);
        }

        // PUT: api/GreenTasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGreenTask(int id, GreenTask greenTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != greenTask.GreenTaskID)
            {
                return BadRequest();
            }

            db.Entry(greenTask).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreenTaskExists(id))
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

        // POST: api/GreenTasks
        [ResponseType(typeof(GreenTask))]
        public IHttpActionResult PostGreenTask(GreenTask greenTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GreenTasks.Add(greenTask);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GreenTaskExists(greenTask.GreenTaskID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = greenTask.GreenTaskID }, greenTask);
        }

        // DELETE: api/GreenTasks/5
        [ResponseType(typeof(GreenTask))]
        public IHttpActionResult DeleteGreenTask(int id)
        {
            GreenTask greenTask = db.GreenTasks.Find(id);
            if (greenTask == null)
            {
                return NotFound();
            }

            db.GreenTasks.Remove(greenTask);
            db.SaveChanges();

            return Ok(greenTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GreenTaskExists(int id)
        {
            return db.GreenTasks.Count(e => e.GreenTaskID == id) > 0;
        }
    }
}