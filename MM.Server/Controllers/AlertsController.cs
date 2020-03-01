using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MM.Model;
using MM.Server;

namespace MM.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlertsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlertsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Alerts
        [HttpGet]
        [Route("OpenAlerts")]
        public async Task<ActionResult<IEnumerable<Alert>>> OpenAlerts()
        {
            return await _context.Alerts.Where(a => a.Status != AlertStatus.Closed).ToListAsync();
        }
        // GET: Alerts
        [HttpGet]
        [Route("AlertsHistory")]
        public async Task<ActionResult<IEnumerable<Alert>>> AlertsHistory()
        {
            return await _context.Alerts.Where(a => a.Status == AlertStatus.Closed || a.Status == AlertStatus.Untriggered).ToListAsync();
        }


        // GET: Alerts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alert>> GetAlert(int id)
        {
            var alert = await _context.Alerts.FindAsync(id);

            if (alert == null)
            {
                return NotFound();
            }

            return alert;
        }

        // PUT: Alerts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlert(int id, Alert alert)
        {
            if (id != alert.Id)
            {
                return BadRequest();
            }

            _context.Entry(alert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: Alerts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Alert>> PostAlert(Alert alert)
        {
            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlert", new { id = alert.Id }, alert);
        }

        // DELETE: Alerts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Alert>> DeleteAlert(int id)
        {
            var alert = await _context.Alerts.FindAsync(id);
            if (alert == null)
            {
                return NotFound();
            }

            _context.Alerts.Remove(alert);
            await _context.SaveChangesAsync();

            return alert;
        }

        private bool AlertExists(int id)
        {
            return _context.Alerts.Any(e => e.Id == id);
        }
    }
}
