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
    public class SuppliesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuppliesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Supplies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Supplies.ToListAsync());
        }

        // GET: Supplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Supply = await _context.Supplies
                .Include(pm => pm.ProductMachine)
                .ThenInclude(ma => ma.Machine)
                .Include(pm => pm.ProductMachine)
                .ThenInclude(pr => pr.Product)
                .SingleOrDefaultAsync(m => m.SupplyId == id);
            if (Supply == null)
            {
                return NotFound();
            }

            return View(Supply);
        }

        // GET: Supplies/Create
        public IActionResult Create(int? id)
        {
            if (!id.HasValue)
            {
                ViewData["MachineName"] = _context.Machines.Find(MachinesController.macId).MachineName;
                ViewData["MachineId"] = MachinesController.macId;
                var ar = _context.ProductMachines
                    .Include(m => m.Machine)
                    .Where(su => su.MachineId == MachinesController.macId)
                    .Include(pm => pm.Product);
                ViewData["ProductMachineId"] = new SelectList(ar, "ProductMachineId", "Product.ProductName");
            }
            else
            {
                ViewData["MachineId"] = _context.ProductMachines.Find(id).MachineId;
                ViewData["MachineName"] = _context.Machines.Find(_context.ProductMachines.Find(id).MachineId).MachineName;
                ViewData["ProductName"] = _context.Products.Find(_context.ProductMachines.Find(id).ProductId).ProductName;
            }
            return PartialView();
        }

        // POST: Supplies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, [Bind("SupplyId,ProductMachineId,SupplyTime,SupplyQty")] Supply Supply)
        {
            if (ModelState.IsValid)
            {
                if (id.HasValue)
                {
                    Supply.ProductMachineId = id.Value;
                    _context.Add(Supply);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Machines", new { id });
                }
                else
                {
                    _context.Add(Supply);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Machines", new { id = MachinesController.macId });
                }
            }
            if (id == null)
            {
                ViewData["ProductMachineId"] = new SelectList(_context.ProductMachines, "ProductMachineId", "Product.ProductName", Supply.ProductMachineId);
            }
            else
            {
                ViewData["ProductMachineId"] = id;
            }
            return PartialView(Supply);
        }

        // GET: Supplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Supply = await _context.Supplies.SingleOrDefaultAsync(m => m.SupplyId == id);
            if (Supply == null)
            {
                return NotFound();
            }
            ViewData["ProductMachineId"] = new SelectList(_context.ProductMachines, "ProductMachineId", "ProductMachineQty", Supply.ProductMachineId);
            return View(Supply);
        }

        // POST: Supplies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplyId,ProductMachineId,SupplyTime,SupplyQty")] Supply Supply)
        {
            if (id != Supply.SupplyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Supply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplyExists(Supply.SupplyId))
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
            ViewData["ProductMachineId"] = new SelectList(_context.ProductMachines, "ProductMachineId", "ProductMachineQty", Supply.ProductMachineId);
            return View(Supply);
        }

        // GET: Supplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Supply = await _context.Supplies
                .Include(p => p.ProductMachine)
                .ThenInclude(pm => pm.Product)
                .SingleOrDefaultAsync(m => m.SupplyId == id);
            if (Supply == null)
            {
                return NotFound();
            }

            return PartialView(Supply);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Supply = await _context.Supplies.SingleOrDefaultAsync(m => m.SupplyId == id);
            _context.Supplies.Remove(Supply);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Machines", new { id = MachinesController.macId });
        }

        private bool SupplyExists(int id)
        {
            return _context.Supplies.Any(e => e.SupplyId == id);
        }
    }
}
