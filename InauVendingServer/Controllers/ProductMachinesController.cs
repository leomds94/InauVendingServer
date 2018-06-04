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
    public class ProductMachinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductMachinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductMachines
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.ProductMachines.Include(p => p.Machine).Include(p => p.Product);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: ProductMachines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMachine = await _context.ProductMachines
                .Include(p => p.Machine)
                .Include(p => p.Product)
                .SingleOrDefaultAsync(m => m.ProductMachineId == id);
            if (productMachine == null)
            {
                return NotFound();
            }

            return View(productMachine);
        }

        // GET: ProductMachines/Create
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            return PartialView();
        }

        // POST: ProductMachines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, [Bind("ProductMachineId,ProductMachineQty,ProductId,MachineId,ProductMachinePrice, ProductMachineIndex")] ProductMachine productMachine)
        {
            if (ModelState.IsValid)
            {
                if(id.HasValue)
                    productMachine.MachineId = id.Value;
                _context.Add(productMachine);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Machines", new { id });
            }
            if (id == null)
            {
                ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineName", productMachine.MachineId);
            }
            else
            {
                ViewData["MachineId"] = id;
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", productMachine.ProductId);
            return PartialView(productMachine);
        }

        // GET: ProductMachines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMachine = await _context.ProductMachines.SingleOrDefaultAsync(m => m.ProductMachineId == id);
            if (productMachine == null)
            {
                return NotFound();
            }
            ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineName", productMachine.MachineId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", productMachine.ProductId);
            return View(productMachine);
        }

        // POST: ProductMachines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductMachineId,ProductMachineQty,ProductId,MachineId,ProductMachinePrice")] ProductMachine productMachine)
        {
            if (id != productMachine.ProductMachineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productMachine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductMachineExists(productMachine.ProductMachineId))
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
            ViewData["MachineId"] = new SelectList(_context.Machines, "MachineId", "MachineName", productMachine.MachineId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", productMachine.ProductId);
            return View(productMachine);
        }

        // GET: ProductMachines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMachine = await _context.ProductMachines
                .Include(p => p.Machine)
                .Include(p => p.Product)
                .SingleOrDefaultAsync(m => m.ProductMachineId == id);
            if (productMachine == null)
            {
                return NotFound();
            }

            return PartialView(productMachine);
        }

        // POST: ProductMachines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            int? mId = _context.ProductMachines.Find(id).MachineId;
            var productMachine = await _context.ProductMachines.SingleOrDefaultAsync(m => m.ProductMachineId == id);
            _context.ProductMachines.Remove(productMachine);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Details", "Machines", new { id = mId });
        }

        private bool ProductMachineExists(int id)
        {
            return _context.ProductMachines.Any(e => e.ProductMachineId == id);
        }
    }
}
