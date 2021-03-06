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
    public class ProjectManagersController : ControllerBase
    {
        private readonly DataContext _context;

        public ProjectManagersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ProjectManagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectManager>>> GetProjectManagers()
        {
            return await _context.ProjectManagers.ToListAsync();
        }

        // GET: api/ProjectManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectManager>> GetProjectManager(int id)
        {
            var projectManager = await _context.ProjectManagers.FindAsync(id);

            if (projectManager == null)
            {
                return NotFound();
            }

            return projectManager;
        }

        // PUT: api/ProjectManagers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectManager(int id, ProjectManager projectManager)
        {
            if (id != projectManager.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectManagerExists(id))
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

        // POST: api/ProjectManagers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectManager>> PostProjectManager(ProjectManager projectManager)
        {
            _context.ProjectManagers.Add(projectManager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectManager", new { id = projectManager.Id }, projectManager);
        }

        // DELETE: api/ProjectManagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectManager(int id)
        {
            var projectManager = await _context.ProjectManagers.FindAsync(id);
            if (projectManager == null)
            {
                return NotFound();
            }

            _context.ProjectManagers.Remove(projectManager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectManagerExists(int id)
        {
            return _context.ProjectManagers.Any(e => e.Id == id);
        }
    }
}
