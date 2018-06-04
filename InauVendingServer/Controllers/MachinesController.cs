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
    public class MachinesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public static int macId;

        public MachinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Machines
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.Machines.Include(m => m.Owner);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: Machines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            macId = id.Value;
            var machine = await _context.Machines
                .Include(p => p.Maintenances)
                .ThenInclude(c => c.Maintenance)
                .Include(m => m.Owner)
                .Include(s => s.ProductMachines)
                .ThenInclude(e => e.Product)
                .Include(s => s.ProductMachines)
                .ThenInclude(su => su.Supplies)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.MachineId == id);

            if (machine == null)
            {
                return NotFound();
            }

            return View(machine);
        }

        // GET: Machines/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "OwnerName");
            return PartialView();
        }

        // POST: Machines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineId,MachineName,MachineAddress,MachineManufacturer,MachineModel,MachineType,MachineDimension,MachineVoltage,OwnerId")] Machine machine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machine);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "OwnerName", machine.OwnerId);
            return PartialView(machine);
        }

        // GET: Machines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machine = await _context.Machines.SingleOrDefaultAsync(m => m.MachineId == id);
            if (machine == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "OwnerName", machine.OwnerId);
            return PartialView(machine);
        }

        // POST: Machines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineId,MachineName,MachineAddress,MachineManufacturer,MachineModel,MachineType,MachineDimension,MachineVoltage,OwnerId")] Machine machine)
        {
            if (id != machine.MachineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineExists(machine.MachineId))
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
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "OwnerName", machine.OwnerId);
            return PartialView(machine);
        }

        // GET: Machines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machine = await _context.Machines
                .Include(m => m.Owner)
                .SingleOrDefaultAsync(m => m.MachineId == id);
            if (machine == null)
            {
                return NotFound();
            }

            return PartialView(machine);
        }

        // POST: Machines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var machine = await _context.Machines.SingleOrDefaultAsync(m => m.MachineId == id);
            _context.Machines.Remove(machine);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MachineExists(int id)
        {
            return _context.Machines.Any(e => e.MachineId == id);
        }
    }
}
