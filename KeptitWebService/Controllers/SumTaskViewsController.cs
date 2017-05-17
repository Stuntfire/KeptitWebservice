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
    public class SumTaskViewsController : ApiController
    {
        private KeptitContextSumAreaTask db = new KeptitContextSumAreaTask();

        // GET: api/SumTaskViews
        public IQueryable<SumTaskView> GetSumTaskViews()
        {
            return db.SumTaskViews;
        }

        // GET: api/SumTaskViews/5
        [ResponseType(typeof(SumTaskView))]
        public async Task<IHttpActionResult> GetSumTaskView(string id)
        {
            SumTaskView sumTaskView = await db.SumTaskViews.FindAsync(id);
            if (sumTaskView == null)
            {
                return NotFound();
            }

            return Ok(sumTaskView);
        }

        // PUT: api/SumTaskViews/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSumTaskView(string id, SumTaskView sumTaskView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sumTaskView.GreenTaskTitle)
            {
                return BadRequest();
            }

            db.Entry(sumTaskView).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SumTaskViewExists(id))
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

        // POST: api/SumTaskViews
        [ResponseType(typeof(SumTaskView))]
        public async Task<IHttpActionResult> PostSumTaskView(SumTaskView sumTaskView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SumTaskViews.Add(sumTaskView);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SumTaskViewExists(sumTaskView.GreenTaskTitle))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sumTaskView.GreenTaskTitle }, sumTaskView);
        }

        // DELETE: api/SumTaskViews/5
        [ResponseType(typeof(SumTaskView))]
        public async Task<IHttpActionResult> DeleteSumTaskView(string id)
        {
            SumTaskView sumTaskView = await db.SumTaskViews.FindAsync(id);
            if (sumTaskView == null)
            {
                return NotFound();
            }

            db.SumTaskViews.Remove(sumTaskView);
            await db.SaveChangesAsync();

            return Ok(sumTaskView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SumTaskViewExists(string id)
        {
            return db.SumTaskViews.Count(e => e.GreenTaskTitle == id) > 0;
        }
    }
}