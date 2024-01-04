using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phase3EndProject.Data;
using Phase3EndProject.Models;

namespace Phase3EndProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptMastersController : ControllerBase
    {
        private readonly Phase3DbContext _context;

        public DeptMastersController(Phase3DbContext context)
        {
            _context = context;
        }

        // GET: api/DeptMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeptMasters>>> GetDeptMasters()
        {
          if (_context.DeptMasters == null)
          {
              return NotFound();
          }
            return await _context.DeptMasters.ToListAsync();
        }

        // GET: api/DeptMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeptMasters>> GetDeptMasters(int id)
        {
          if (_context.DeptMasters == null)
          {
              return NotFound();
          }
            var deptMasters = await _context.DeptMasters.FindAsync(id);

            if (deptMasters == null)
            {
                return NotFound();
            }

            return deptMasters;
        }

        // PUT: api/DeptMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeptMasters(int id, DeptMasters deptMasters)
        {
            if (id != deptMasters.DeptCode)
            {
                return BadRequest();
            }

            _context.Entry(deptMasters).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeptMastersExists(id))
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

        // POST: api/DeptMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeptMasters>> PostDeptMasters(DeptMasters deptMasters)
        {
          if (_context.DeptMasters == null)
          {
              return Problem("Entity set 'Phase3DbContext.DeptMasters'  is null.");
          }
            _context.DeptMasters.Add(deptMasters);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeptMasters", new { id = deptMasters.DeptCode }, deptMasters);
        }

        // DELETE: api/DeptMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeptMasters(int id)
        {
            if (_context.DeptMasters == null)
            {
                return NotFound();
            }
            var deptMasters = await _context.DeptMasters.FindAsync(id);
            if (deptMasters == null)
            {
                return NotFound();
            }

            _context.DeptMasters.Remove(deptMasters);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeptMastersExists(int id)
        {
            return (_context.DeptMasters?.Any(e => e.DeptCode == id)).GetValueOrDefault();
        }
    }
}
