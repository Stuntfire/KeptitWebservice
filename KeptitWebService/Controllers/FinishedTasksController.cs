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
    public class FinishedTasksController : ApiController
    {
        private KeptitContext db = new KeptitContext();

        // GET: api/FinishedTasks
        public IQueryable<FinishedTask> GetFinishedTasks()
        {
            return db.FinishedTasks;
        }

        // GET: api/FinishedTasks/5
        [ResponseType(typeof(FinishedTask))]
        public IHttpActionResult GetFinishedTask(int id)
        {
            FinishedTask finishedTask = db.FinishedTasks.Find(id);
            if (finishedTask == null)
            {
                return NotFound();
            }

            return Ok(finishedTask);
        }

        // PUT: api/FinishedTasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFinishedTask(int id, FinishedTask finishedTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != finishedTask.FinishedTasksID)
            {
                return BadRequest();
            }

            db.Entry(finishedTask).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishedTaskExists(id))
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

        // POST: api/FinishedTasks
        [ResponseType(typeof(FinishedTask))]
        public IHttpActionResult PostFinishedTask(FinishedTask finishedTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FinishedTasks.Add(finishedTask);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = finishedTask.FinishedTasksID }, finishedTask);
        }

        // DELETE: api/FinishedTasks/5
        [ResponseType(typeof(FinishedTask))]
        public IHttpActionResult DeleteFinishedTask(int id)
        {
            FinishedTask finishedTask = db.FinishedTasks.Find(id);
            if (finishedTask == null)
            {
                return NotFound();
            }

            db.FinishedTasks.Remove(finishedTask);
            db.SaveChanges();

            return Ok(finishedTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FinishedTaskExists(int id)
        {
            return db.FinishedTasks.Count(e => e.FinishedTasksID == id) > 0;
        }
    }
}