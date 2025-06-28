using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SellerAPI.Data;
using SellerAPI.Models;
using System.Net.Http.Json;

namespace SellerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;

        public SellerController(AppDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient();
        }

        // GET: api/seller/stock
        [HttpGet("stock")]
        public async Task<ActionResult<IEnumerable<SellerStock>>> GetStock()
        {
            return await _context.SellerStocks.ToListAsync();
        }

        // POST: api/seller/addstock
        [HttpPost("addstock")]
        public async Task<IActionResult> AddStock([FromBody] SellerStock stock)
        {
            _context.SellerStocks.Add(stock);
            await _context.SaveChangesAsync();
            return Ok("Stock added.");
        }

        // PUT: api/seller/updatestock/{id}
        [HttpPut("updatestock/{id}")]
        public async Task<IActionResult> UpdateStock(int id, [FromBody] SellerStock updatedStock)
        {
            var existingStock = await _context.SellerStocks.FindAsync(id);
            if (existingStock == null)
                return NotFound("Stock not found.");

            existingStock.BlanketName = updatedStock.BlanketName;
            existingStock.Material = updatedStock.Material;
            existingStock.Quantity = updatedStock.Quantity;

            await _context.SaveChangesAsync();
            return Ok("Stock updated successfully.");
        }

        // DELETE: api/seller/deletestock/{id}
        [HttpDelete("deletestock/{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            var stock = await _context.SellerStocks.FindAsync(id);
            if (stock == null)
                return NotFound("Stock not found.");

            _context.SellerStocks.Remove(stock);
            await _context.SaveChangesAsync();
            return Ok("Stock deleted successfully.");
        }

        // GET: api/seller/orders
        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _context.CustomerOrders.ToListAsync();
            return Ok(orders);
        }

        // POST: api/seller/placeorder
        [HttpPost("placeorder")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderRequest request)
        {
            var stock = await _context.SellerStocks
                .FirstOrDefaultAsync(s => s.BlanketName == request.BlanketName && s.Material == request.Material);

            if (stock == null || stock.Quantity < request.Quantity)
            {
                return BadRequest("Not enough stock available to place the order.");
            }

            // Deduct stock
            stock.Quantity -= request.Quantity;

            // Save the order
            var order = new CustomerOrder
            {
                CustomerName = request.CustomerName,
                BlanketName = request.BlanketName,
                Material = request.Material,
                Quantity = request.Quantity
            };

            _context.CustomerOrders.Add(order);
            await _context.SaveChangesAsync();

            return Ok("Order placed successfully.");
        }

        // PUT: api/seller/updateorder/{id}
        [HttpPut("updateorder/{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] CustomerOrder updatedOrder)
        {
            var existingOrder = await _context.CustomerOrders.FindAsync(id);
            if (existingOrder == null)
                return NotFound("Order not found.");

            existingOrder.CustomerName = updatedOrder.CustomerName;
            existingOrder.BlanketName = updatedOrder.BlanketName;
            existingOrder.Material = updatedOrder.Material;
            existingOrder.Quantity = updatedOrder.Quantity;
            existingOrder.OrderDate = updatedOrder.OrderDate;

            await _context.SaveChangesAsync();
            return Ok("Order updated successfully.");
        }

        // DELETE: api/seller/deleteorder/{id}
        [HttpDelete("deleteorder/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.CustomerOrders.FindAsync(id);
            if (order == null)
                return NotFound("Order not found.");

            _context.CustomerOrders.Remove(order);
            await _context.SaveChangesAsync();
            return Ok("Order deleted successfully.");
        }

        // POST: api/seller/requestfromdistributor
        [HttpPost("requestfromdistributor")]
        public async Task<IActionResult> RequestFromDistributor([FromBody] OrderRequest request)
        {
            var distributorApiUrl = "https://localhost:7013/api/distributor/stock"; // Distributor's local stock endpoint

            // Get current distributor stock
            var blankets = await _httpClient.GetFromJsonAsync<List<Blanket>>(distributorApiUrl);
            var match = blankets.FirstOrDefault(b =>
                b.BlanketName == request.BlanketName && b.Material == request.Material);

            if (match == null || match.Quantity < request.Quantity)
                return BadRequest("Not enough stock in distributor.");

            // Update seller local inventory
            var sellerStock = await _context.SellerStocks
                .FirstOrDefaultAsync(s => s.BlanketName == request.BlanketName && s.Material == request.Material);

            if (sellerStock != null)
            {
                sellerStock.Quantity += request.Quantity;
            }
            else
            {
                _context.SellerStocks.Add(new SellerStock
                {
                    BlanketName = request.BlanketName,
                    Material = request.Material,
                    Quantity = request.Quantity
                });
            }

            await _context.SaveChangesAsync();

            await _httpClient.PostAsJsonAsync("https://localhost:7013/api/distributor/deductstock", new
            {
                BlanketName = request.BlanketName,
                Material = request.Material,
                Quantity = request.Quantity
            });


            return Ok("Stock requested from distributor and updated locally.");
        }
    }
}
