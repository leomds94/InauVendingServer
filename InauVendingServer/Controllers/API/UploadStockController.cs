using System.Collections.Generic;
using System.Linq;
using InauVendingServer.Data;
using InauVendingServer.Models;
using InauVendingServer.Models.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InauVendingServer.Controllers.API
{
    [Route("api/[controller]")]
    public class UploadStockController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UploadStockController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Post([FromBody]EntityVendingMachine entityVending)
        {
            List<EntityProductStock> productStocks = new List<EntityProductStock>();

            var ProductMachines = _context.ProductMachines
                .Include(p => p.Product)
                .Include(m => m.Machine)
                .Where(m => m.MachineId == entityVending.machineSerial)
                .ToList();

            ProductMachines.ForEach(pm =>
            {
                productStocks.Add(new EntityProductStock
                {
                    productMachineIndex = pm.ProductMachineIndex,
                    productMachineQty = pm.ProductMachineQty

                });
            });

            return new ObjectResult(new Response(productStocks, true));
        }
    }
}