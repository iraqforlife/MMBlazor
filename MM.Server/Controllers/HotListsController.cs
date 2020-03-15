using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MM.Model;

namespace MM.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotListsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HotListsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HotLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotList>>> GetHotList()
        {
            return await _context.HotList.ToListAsync();
        }

        // GET: api/HotLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotList>> GetHotList(int id)
        {
            var hotList = await _context.HotList.FindAsync(id);

            if (hotList == null)
            {
                return NotFound();
            }

            return hotList;
        }

        // PUT: api/HotLists/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotList(int id, HotList hotList)
        {
            if (id != hotList.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (HotListExists(id))
                {
                    throw;
                }
                else
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/HotLists
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<HotList>> PostHotList(HotList hotList)
        {
            _context.HotList.Add(hotList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotList", new { id = hotList.Id }, hotList);
        }

        // DELETE: api/HotLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotList>> DeleteHotList(int id)
        {
            var hotList = await _context.HotList.FindAsync(id);
            if (hotList == null)
            {
                return NotFound();
            }

            _context.HotList.Remove(hotList);
            await _context.SaveChangesAsync();

            return hotList;
        }

        private bool HotListExists(int id)
        {
            return _context.HotList.Any(e => e.Id == id);
        }
    }
}
