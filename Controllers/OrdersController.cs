using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HOY_API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Orders>>> Get()
        {
            return Ok(await _context.Orders.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> Get(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<List<Orders>>> AddOrder(Orders res)
        {
            _context.Orders.Add(res);
            await _context.SaveChangesAsync();
            return Ok(await _context.Orders.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Orders>>> UpdateOrder(Orders req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            var dbOrder = await _context.Orders.FindAsync(req.id);
            if (dbOrder == null)
            {
                return BadRequest();
            }
            dbOrder.shippingAddress = req.shippingAddress;
            dbOrder.orderStatus = req.orderStatus;

            await _context.SaveChangesAsync();

            return Ok(await _context.Orders.ToListAsync());
        }
    }
}
