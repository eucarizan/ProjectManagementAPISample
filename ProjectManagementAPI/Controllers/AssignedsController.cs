#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Models;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignedsController : ControllerBase
    {
        private readonly DataContext _context;

        public AssignedsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Assigneds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assigned>>> GetAssignedDb()
        {
            return await _context.AssignedDb.ToListAsync();
        }

        // GET: api/Assigneds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assigned>> GetAssigned(int id)
        {
            var assigned = await _context.AssignedDb.FindAsync(id);

            if (assigned == null)
            {
                return NotFound();
            }

            return assigned;
        }

        // PUT: api/Assigneds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssigned(int id, Assigned assigned)
        {
            if (id != assigned.Id)
            {
                return BadRequest();
            }

            _context.Entry(assigned).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignedExists(id))
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

        // POST: api/Assigneds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Assigned>> PostAssigned(Assigned assigned)
        {
            _context.AssignedDb.Add(assigned);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssigned", new { id = assigned.Id }, assigned);
        }

        // DELETE: api/Assigneds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssigned(int id)
        {
            var assigned = await _context.AssignedDb.FindAsync(id);
            if (assigned == null)
            {
                return NotFound();
            }

            _context.AssignedDb.Remove(assigned);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssignedExists(int id)
        {
            return _context.AssignedDb.Any(e => e.Id == id);
        }
    }
}
