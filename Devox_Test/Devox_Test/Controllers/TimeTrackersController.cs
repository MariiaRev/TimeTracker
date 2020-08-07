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
using Devox_Test.Models;

namespace Devox_Test.Controllers
{
    public class TimeTrackersController : ApiController
    {
        private Devox_TestContext db = new Devox_TestContext();

        // GET: api/TimeTrackers
        public IQueryable<TimeTracker> GetTimeTrackers()
        {
            return db.TimeTrackers.Include(x => x.EmployeeId).Include(x => x.ActivityTypeId)
                .Include(x => x.ProjectId).Include(x => x.RoleID);
        }

        // GET: api/TimeTrackers/5
        [ResponseType(typeof(TimeTracker))]
        public async Task<IHttpActionResult> GetTimeTracker(int id)
        {
            TimeTracker timeTracker = await db.TimeTrackers.FindAsync(id);
            if (timeTracker == null)
            {
                return NotFound();
            }

            return Ok(timeTracker);
        }

        // PUT: api/TimeTrackers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTimeTracker(int id, TimeTracker timeTracker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timeTracker.EmployeeId)
            {
                return BadRequest();
            }

            db.Entry(timeTracker).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeTrackerExists(id))
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

        // POST: api/TimeTrackers
        [ResponseType(typeof(TimeTracker))]
        public async Task<IHttpActionResult> PostTimeTracker(TimeTracker timeTracker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TimeTrackers.Add(timeTracker);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TimeTrackerExists(timeTracker.EmployeeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = timeTracker.EmployeeId }, timeTracker);
        }

        // DELETE: api/TimeTrackers/5
        [ResponseType(typeof(TimeTracker))]
        public async Task<IHttpActionResult> DeleteTimeTracker(int id)
        {
            TimeTracker timeTracker = await db.TimeTrackers.FindAsync(id);
            if (timeTracker == null)
            {
                return NotFound();
            }

            db.TimeTrackers.Remove(timeTracker);
            await db.SaveChangesAsync();

            return Ok(timeTracker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeTrackerExists(int id)
        {
            return db.TimeTrackers.Count(e => e.EmployeeId == id) > 0;
        }
    }
}