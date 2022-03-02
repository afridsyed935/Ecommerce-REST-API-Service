using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HOY_API_2.Controllers
{
    [Route("api/order/details")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderDetailsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDetails>>> GetAllDetails()
        {
            return Ok(await _context.OrderDetails.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetails>> Get(int id)
        {
            var order = await _context.OrderDetails.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<List<OrderDetails>>> AddOrderDetails(OrderDetails res)
        {
            _context.OrderDetails.Add(res);
            await _context.SaveChangesAsync();
            return Ok(await _context.OrderDetails.ToListAsync());
        }

    }
}
