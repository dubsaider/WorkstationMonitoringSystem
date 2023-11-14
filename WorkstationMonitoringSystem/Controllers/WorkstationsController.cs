using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkstationMonitoringSystem.Data;
using WorkstationMonitoringSystem.Models;

namespace WorkstationMonitoringSystem.Controllers
{
    public class WorkstationsController : Controller
    {
        private readonly WorkstationMonitoringSystemContext _context;

        public WorkstationsController(WorkstationMonitoringSystemContext context)
        {
            _context = context;
        }

        // GET: Workstations
        public async Task<IActionResult> Index()
        {
              return _context.Workstation != null ? 
                          View(await _context.Workstation.ToListAsync()) :
                          Problem("Entity set 'WorkstationMonitoringSystemContext.Workstation'  is null.");
        }

        // GET: Workstations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Workstation == null)
            {
                return NotFound();
            }

            var workstation = await _context.Workstation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workstation == null)
            {
                return NotFound();
            }

            return View(workstation);
        }

        // GET: Workstations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workstations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CPU,GPU,RAM,Memory,UsedMemory,GeneralInfoJSON,GPUInfoJSON")] Workstation workstation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workstation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workstation);
        }

        // GET: Workstations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Workstation == null)
            {
                return NotFound();
            }

            var workstation = await _context.Workstation.FindAsync(id);
            if (workstation == null)
            {
                return NotFound();
            }
            return View(workstation);
        }

        // POST: Workstations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CPU,GPU,RAM,Memory,UsedMemory,GeneralInfoJSON,GPUInfoJSON")] Workstation workstation)
        {
            if (id != workstation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workstation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkstationExists(workstation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(workstation);
        }

        // GET: Workstations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Workstation == null)
            {
                return NotFound();
            }

            var workstation = await _context.Workstation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workstation == null)
            {
                return NotFound();
            }

            return View(workstation);
        }

        // POST: Workstations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Workstation == null)
            {
                return Problem("Entity set 'WorkstationMonitoringSystemContext.Workstation'  is null.");
            }
            var workstation = await _context.Workstation.FindAsync(id);
            if (workstation != null)
            {
                _context.Workstation.Remove(workstation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkstationExists(int id)
        {
          return (_context.Workstation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
