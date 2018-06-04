using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using InauVendingServer.Data;
using InauVendingServer.Models;
using Microsoft.EntityFrameworkCore;

namespace InauVendingServer.Controllers.API
{
    [Route("api/[controller]")]
    public class MachinesAPIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MachinesAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Machine> GetAll()
        {
            return _context.Machines.Include(p => p.ProductMachines).ThenInclude(p => p.Product).ToList();
        }

        [HttpGet("{id}", Name = "GetMachine")]
        [Route("api/[controller]/{id}")]
        public IEnumerable<ProductMachine> GetById(int id)
        {
            var machine = _context.Machines
                .Include(s => s.ProductMachines)
                .ThenInclude(e => e.Product)
                .ToList();

            return machine[id].ProductMachines.ToList();
        }
    }
}