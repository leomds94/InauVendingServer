using Microsoft.AspNetCore.Mvc;
using InauVendingServer.Models;
using InauVendingServer.Data;
using InauVendingServer.Models.Commands;
using System.Threading.Tasks;

namespace InauVendingServer.Controllers.API
{
    [Route("api/[controller]")]
    public class PendingAppController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PendingAppController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/PendingApp
        public async Task<IActionResult> PostAsync([FromBody]PendingCommand pendingCommand)
        {
            _context.Add(pendingCommand);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [Route("productstatus")]
        [HttpGet]
        public IActionResult ProductStatus()
        {
            if (Program.state_machine.HasValue)
            {
                if(Program.state_machine.Value)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(417);
                }
            }
            else
            {
                return StatusCode(417);
            }
        }

    }
}
