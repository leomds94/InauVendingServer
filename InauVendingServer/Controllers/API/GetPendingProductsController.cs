using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using InauVendingServer.Data;
using InauVendingServer.Models;
using InauVendingServer.Models.Commands;

namespace InauVendingServer.Controllers.API
{
    [Route("api/[controller]")]
    public class GetPendingProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GetPendingProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SendPendingProducts([FromBody]EntityVendingMachine machine)
        {
            List<EntityReleaseProduct> ReleaseProducts = new List<EntityReleaseProduct>();

            var pendingCommands = _context.PendingCommands
                .Include(p => p.ProductMachine)
                .ThenInclude(m => m.Machine)
                .Where(m => m.status == 5 && m.ProductMachine.MachineId == machine.machineSerial)
                .ToList();

            foreach (PendingCommand p in pendingCommands)
            {
                ReleaseProducts.Add(new EntityReleaseProduct
                {
                    index = p.ProductMachine.ProductMachineIndex,
                    status = 1
                });
            }

            return Json(new Response(ReleaseProducts, true));
        }
    }
}
