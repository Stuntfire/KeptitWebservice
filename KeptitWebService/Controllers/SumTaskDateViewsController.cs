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
    public class SumTaskDateViewsController : ApiController
    {
        private KeptitContextSumAreaTask db = new KeptitContextSumAreaTask();

        // GET: api/SumTaskDateViews
        public IQueryable<SumTaskDateView> GetSumTaskDateViews()
        {
            return db.SumTaskDateViews;
        }

        // GET: api/SumTaskDateViews/5
        [ResponseType(typeof(SumTaskDateView))]
        public async Task<IHttpActionResult> GetSumTaskDateView(DateTime id)
        {
            SumTaskDateView sumTaskDateView = await db.SumTaskDateViews.FindAsync(id);
            if (sumTaskDateView == null)
            {
                return NotFound();
            }

            return Ok(sumTaskDateView);
        }

        // PUT: api/SumTaskDateViews/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSumTaskDateView(DateTime id, SumTaskDateView sumTaskDateView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sumTaskDateView.Date)
            {
                return BadRequest();
            }

            db.Entry(sumTaskDateView).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SumTaskDateViewExists(id))
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

        // POST: api/SumTaskDateViews
        [ResponseType(typeof(SumTaskDateView))]
        public async Task<IHttpActionResult> PostSumTaskDateView(SumTaskDateView sumTaskDateView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SumTaskDateViews.Add(sumTaskDateView);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SumTaskDateViewExists(sumTaskDateView.Date))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sumTaskDateView.Date }, sumTaskDateView);
        }

        // DELETE: api/SumTaskDateViews/5
        [ResponseType(typeof(SumTaskDateView))]
        public async Task<IHttpActionResult> DeleteSumTaskDateView(DateTime id)
        {
            SumTaskDateView sumTaskDateView = await db.SumTaskDateViews.FindAsync(id);
            if (sumTaskDateView == null)
            {
                return NotFound();
            }

            db.SumTaskDateViews.Remove(sumTaskDateView);
            await db.SaveChangesAsync();

            return Ok(sumTaskDateView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SumTaskDateViewExists(DateTime id)
        {
            return db.SumTaskDateViews.Count(e => e.Date == id) > 0;
        }
    }
}