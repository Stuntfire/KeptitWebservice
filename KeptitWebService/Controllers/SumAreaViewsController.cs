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
    public class SumAreaViewsController : ApiController
    {
        private KeptitContextSumAreaTask db = new KeptitContextSumAreaTask();

        // GET: api/SumAreaViews
        public IQueryable<SumAreaView> GetSumAreaViews()
        {
            return db.SumAreaViews;
        }

        // GET: api/SumAreaViews/5
        [ResponseType(typeof(SumAreaView))]
        public async Task<IHttpActionResult> GetSumAreaView(DateTime id)
        {
            SumAreaView sumAreaView = await db.SumAreaViews.FindAsync(id);
            if (sumAreaView == null)
            {
                return NotFound();
            }

            return Ok(sumAreaView);
        }

        // PUT: api/SumAreaViews/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSumAreaView(DateTime id, SumAreaView sumAreaView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sumAreaView.Date)
            {
                return BadRequest();
            }

            db.Entry(sumAreaView).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SumAreaViewExists(id))
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

        // POST: api/SumAreaViews
        [ResponseType(typeof(SumAreaView))]
        public async Task<IHttpActionResult> PostSumAreaView(SumAreaView sumAreaView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SumAreaViews.Add(sumAreaView);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SumAreaViewExists(sumAreaView.Date))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sumAreaView.Date }, sumAreaView);
        }

        // DELETE: api/SumAreaViews/5
        [ResponseType(typeof(SumAreaView))]
        public async Task<IHttpActionResult> DeleteSumAreaView(DateTime id)
        {
            SumAreaView sumAreaView = await db.SumAreaViews.FindAsync(id);
            if (sumAreaView == null)
            {
                return NotFound();
            }

            db.SumAreaViews.Remove(sumAreaView);
            await db.SaveChangesAsync();

            return Ok(sumAreaView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SumAreaViewExists(DateTime id)
        {
            return db.SumAreaViews.Count(e => e.Date == id) > 0;
        }
    }
}