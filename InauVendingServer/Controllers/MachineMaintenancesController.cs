using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InauVendingServer.Data;
using InauVendingServer.Models;

namespace InauVendingServer.Controllers
{
    public class MachineMaintenancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MachineMaintenancesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: MachineMaintenances
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.MachineMaintenances.Include(m => m.Machine).Include(m => m.Maintenance);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: MachineMaintenances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineMaintenance = await _context.MachineMaintenances
                .Include(m => m.Machine)
                .Include(m => m.Maintenance)
                .SingleOrDefaultAsync(m => m.MachineMaintenanceId == id);
            if (machineMaintenance == null)
            {
                return NotFound();
            }

            return View(machineMaintenance);
        }

        // GET: MachineMaintenances/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineName");
            }
            else
            {
                ViewData["MachineId"] = _context.Machines.Find(id).MachineId;
                ViewData["MachineName"] = _context.Machines.Find(id).MachineName;
            }
            ViewData["MaintenanceId"] = new SelectList(_context.Maintenances, "MaintenanceId", "MaintenanceType");
            return PartialView();
        }

        // POST: MachineMaintenances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, [Bind("MachineMaintenanceId,MachineId,MaintenanceId,MaintenanceTime,MaintenanceCost")] MachineMaintenance machineMaintenance)
        {
            if (ModelState.IsValid)
            {
                if (id.HasValue)
                    machineMaintenance.MachineId = id.Value;
                _context.Add(machineMaintenance);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Machines", new { id });
            }
            if (id == null)
            {
                ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineName", machineMaintenance.MachineId);
            }
            else
            {
                ViewData["MachineId"] = id;
            }
            ViewData["MaintenanceId"] = new SelectList(_context.Maintenances, "MaintenanceId", "MaintenanceType", machineMaintenance.MaintenanceId);
            return PartialView(machineMaintenance);
        }

        // GET: MachineMaintenances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineMaintenance = await _context.MachineMaintenances.SingleOrDefaultAsync(m => m.MachineMaintenanceId == id);
            if (machineMaintenance == null)
            {
                return NotFound();
            }
            ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineName", machineMaintenance.MachineId);
            ViewData["MaintenanceId"] = new SelectList(_context.Maintenances, "MaintenanceId", "MaintenanceType", machineMaintenance.MaintenanceId);
            return View(machineMaintenance);
        }

        // POST: MachineMaintenances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineMaintenanceId,MachineId,MaintenanceId,MaintenanceTime,MaintenanceCost")] MachineMaintenance machineMaintenance)
        {
            if (id != machineMaintenance.MachineMaintenanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machineMaintenance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineMaintenanceExists(machineMaintenance.MachineMaintenanceId))
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
            ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineName", machineMaintenance.MachineId);
            ViewData["MaintenanceId"] = new SelectList(_context.Maintenances, "MaintenanceId", "MaintenanceType", machineMaintenance.MaintenanceId);
            return View(machineMaintenance);
        }

        // GET: MachineMaintenances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineMaintenance = await _context.MachineMaintenances
                .Include(m => m.Machine)
                .Include(m => m.Maintenance)
                .SingleOrDefaultAsync(m => m.MachineMaintenanceId == id);
            if (machineMaintenance == null)
            {
                return NotFound();
            }

            return PartialView(machineMaintenance);
        }

        // POST: MachineMaintenances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            int? mId = _context.MachineMaintenances.Find(id).MachineId;
            var machineMaintenance = await _context.MachineMaintenances.SingleOrDefaultAsync(m => m.MachineMaintenanceId == id);
            _context.MachineMaintenances.Remove(machineMaintenance);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Machines", new { id = mId });
        }

        private bool MachineMaintenanceExists(int id)
        {
            return _context.MachineMaintenances.Any(e => e.MachineMaintenanceId == id);
        }
    }
}
