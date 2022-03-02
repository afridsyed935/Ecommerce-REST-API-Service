using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HOY_API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> Get()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> Get(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
                // return BadRequest("No product found with id: " + id);
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<List<Products>>> AddProduct(Products res)
        {
            _context.Products.Add(res);
            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Products>>> UpdateProduct(Products req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            var dbProduct = await _context.Products.FindAsync(req.id);
            if (dbProduct == null)
            {
                return BadRequest();
            }
            dbProduct.name = req.name;
            dbProduct.price = req.price;
            dbProduct.stock = req.stock;

            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Products>>> deleteProduct(int id)
        {
            var dbProdcut = await _context.Products.FindAsync(id);
            if (dbProdcut == null)
            {
                return NotFound();
            }
            _context.Products.Remove(dbProdcut);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }
    }
}
