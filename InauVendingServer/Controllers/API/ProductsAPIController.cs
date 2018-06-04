using Microsoft.AspNetCore.Mvc;
using InauVendingServer.Data;

namespace InauVendingServer.Controllers
{

    [Route("api/[controller]")]
    public class ProductsAPIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_context.Products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(int id)
        {
            var item = _context.Products.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
