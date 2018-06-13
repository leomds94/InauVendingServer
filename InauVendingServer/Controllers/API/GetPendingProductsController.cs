using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using InauVendingServer.Data;
using InauVendingServer.Models;
using InauVendingServer.Models.Commands;
using System.Threading.Tasks;

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
                .Where(m => m.status == 0 && m.ProductMachine.MachineId == machine.machineSerial)
                .ToList();

            foreach (PendingCommand p in pendingCommands)
            {
                ReleaseProducts.Add(new EntityReleaseProduct
                {
                    machineSerial = p.ProductMachine.MachineId,
                    index = p.ProductMachine.ProductMachineIndex,
                    status = p.status
                });
            }

            return Json(new Response(ReleaseProducts, true));
        }

        [Route("productstatus")]
        [HttpPost]
        public async Task<IActionResult> ProductStatusAsync([FromBody]EntityReleaseProduct releaseProd)
        {
            var pendingCommands = _context.PendingCommands
                .Include(p => p.ProductMachine)
                .ThenInclude(m => m.Machine)
                .Where(m => m.ProductMachine.MachineId == releaseProd.machineSerial &&
                            m.ProductMachine.ProductMachineIndex == releaseProd.index &&
                            m.status == 0)
                .ToList();

            if (pendingCommands.Count == 0)
                return StatusCode(406);

            var pendingCommand = pendingCommands[0];

            pendingCommand.status = releaseProd.status;

            Program.state_machine = (releaseProd.status == 6) ? true : false;

            _context.Update(pendingCommand);
            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}
