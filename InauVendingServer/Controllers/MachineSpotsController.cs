using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InauVendingServer.Data;
using InauVendingServer.Models;
using Microsoft.AspNetCore.Authorization;

namespace InauVendingServer.Controllers
{
    [Authorize]
    public class MachineSpotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MachineSpotsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: MachineSpots
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.MachineSpots.Include(m => m.Machine);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: MachineSpots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineSpot = await _context.MachineSpots
                .Include(m => m.Machine)
                .SingleOrDefaultAsync(m => m.MachineSpotId == id);
            if (machineSpot == null)
            {
                return NotFound();
            }

            return View(machineSpot);
        }

        // GET: MachineSpots/Create
        public IActionResult Create()
        {
            ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineName");
            return View();
        }

        // POST: MachineSpots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineSpotId,MachineSpotStartTime,MachineSpotEndTime,MachineSpotName,MachineSpotAddress,MachineId")] MachineSpot machineSpot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machineSpot);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineName", machineSpot.MachineId);
            return View(machineSpot);
        }

        // GET: MachineSpots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineSpot = await _context.MachineSpots.SingleOrDefaultAsync(m => m.MachineSpotId == id);
            if (machineSpot == null)
            {
                return NotFound();
            }
            ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineName", machineSpot.MachineId);
            return View(machineSpot);
        }

        // POST: MachineSpots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineSpotId,MachineSpotStartTime,MachineSpotEndTime,MachineSpotName,MachineSpotAddress,MachineId")] MachineSpot machineSpot)
        {
            if (id != machineSpot.MachineSpotId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machineSpot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineSpotExists(machineSpot.MachineSpotId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineName", machineSpot.MachineId);
            return View(machineSpot);
        }

        // GET: MachineSpots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineSpot = await _context.MachineSpots
                .Include(m => m.Machine)
                .SingleOrDefaultAsync(m => m.MachineSpotId == id);
            if (machineSpot == null)
            {
                return NotFound();
            }

            return View(machineSpot);
        }

        // POST: MachineSpots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var machineSpot = await _context.MachineSpots.SingleOrDefaultAsync(m => m.MachineSpotId == id);
            _context.MachineSpots.Remove(machineSpot);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MachineSpotExists(int id)
        {
            return _context.MachineSpots.Any(e => e.MachineSpotId == id);
        }
    }
}
