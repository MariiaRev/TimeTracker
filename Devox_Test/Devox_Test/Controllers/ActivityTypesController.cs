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
    public class ActivityTypesController : ApiController
    {
        private Devox_TestContext db = new Devox_TestContext();

        // GET: api/ActivityTypes
        public IQueryable<ActivityType> GetActivityTypes()
        {
            return db.ActivityTypes;
        }

        // GET: api/ActivityTypes/5
        [ResponseType(typeof(ActivityType))]
        public async Task<IHttpActionResult> GetActivityType(int id)
        {
            ActivityType activityType = await db.ActivityTypes.FindAsync(id);
            if (activityType == null)
            {
                return NotFound();
            }

            return Ok(activityType);
        }

        // PUT: api/ActivityTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutActivityType(int id, ActivityType activityType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activityType.Id)
            {
                return BadRequest();
            }

            db.Entry(activityType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityTypeExists(id))
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

        // POST: api/ActivityTypes
        [ResponseType(typeof(ActivityType))]
        public async Task<IHttpActionResult> PostActivityType(ActivityType activityType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActivityTypes.Add(activityType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = activityType.Id }, activityType);
        }

        // DELETE: api/ActivityTypes/5
        [ResponseType(typeof(ActivityType))]
        public async Task<IHttpActionResult> DeleteActivityType(int id)
        {
            ActivityType activityType = await db.ActivityTypes.FindAsync(id);
            if (activityType == null)
            {
                return NotFound();
            }

            db.ActivityTypes.Remove(activityType);
            await db.SaveChangesAsync();

            return Ok(activityType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivityTypeExists(int id)
        {
            return db.ActivityTypes.Count(e => e.Id == id) > 0;
        }
    }
}