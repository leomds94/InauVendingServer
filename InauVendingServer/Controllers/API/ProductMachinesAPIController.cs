using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InauVendingServer.Data;
using Microsoft.EntityFrameworkCore;
using InauVendingServer.Models;

namespace InauVendingServer.Controllers.API
{
    [Route("api/[controller]")]
    public class ProductMachinesAPIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductMachinesAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ProductMachine> GetAll()
        {
            return _context.ProductMachines.Include(p => p.Machine).Include(p => p.Product).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.ProductMachines.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}