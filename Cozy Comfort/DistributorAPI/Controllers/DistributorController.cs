using DistributorAPI.Data;
using DistributorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace DistributorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistributorController : ControllerBase
    {
        private readonly DistributorContext _context;
        private readonly HttpClient _httpClient;

        public DistributorController(DistributorContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient();
        }

        // GET: api/distributor/stock
        [HttpGet("stock")]
        public async Task<ActionResult<IEnumerable<DistributorStock>>> GetStock()
        {
            return await _context.DistributorStocks.ToListAsync();
        }

        // POST: api/distributor/addstock
        [HttpPost("addstock")]
        public async Task<IActionResult> AddStock([FromBody] DistributorStock stock)
        {
            _context.DistributorStocks.Add(stock);
            await _context.SaveChangesAsync();
            return Ok("Stock added.");
        }

        // PUT: Update distributor stock by ID
        [HttpPut("updatestock/{id}")]
        public async Task<IActionResult> UpdateStock(int id, [FromBody] DistributorStock updatedStock)
        {
            var existingStock = await _context.DistributorStocks.FindAsync(id);
            if (existingStock == null)
                return NotFound("Stock item not found.");

            existingStock.BlanketName = updatedStock.BlanketName;
            existingStock.Material = updatedStock.Material;
            existingStock.Quantity = updatedStock.Quantity;

            await _context.SaveChangesAsync();
            return Ok("Stock updated.");
        }

        // DELETE: Delete distributor stock by ID
        [HttpDelete("deletestock/{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            var stock = await _context.DistributorStocks.FindAsync(id);
            if (stock == null)
                return NotFound("Stock item not found.");

            _context.DistributorStocks.Remove(stock);
            await _context.SaveChangesAsync();
            return Ok("Stock deleted.");
        }


        // POST: api/distributor/requestfrommanufacturer
        [HttpPost("requestfrommanufacturer")]
        public async Task<IActionResult> RequestFromManufacturer([FromBody] StockRequest request)
        {
            // Example ManufacturerAPI endpoint
            var manufacturerApiUrl = "https://localhost:7263/api/manufacturer/blankets";

            // Get blankets from ManufacturerAPI
            var blankets = await _httpClient.GetFromJsonAsync<List<Blanket>>(manufacturerApiUrl);
            var match = blankets.FirstOrDefault(b => b.blanketName == request.BlanketName && b.Material == request.Material);

            if (match == null || match.StockQuantity < request.Quantity)
                return BadRequest("Not enough stock at manufacturer.");

            // Add to Distributor's local inventory
            var existingStock = await _context.DistributorStocks
                .FirstOrDefaultAsync(s => s.BlanketName == request.BlanketName && s.Material == request.Material);

            if (existingStock != null)
            {
                existingStock.Quantity += request.Quantity;
            }
            else
            {
                _context.DistributorStocks.Add(new DistributorStock
                {
                    BlanketName = request.BlanketName,
                    Material = request.Material,
                    Quantity = request.Quantity
                });
            }

            await _context.SaveChangesAsync();
            return Ok("Stock requested and updated.");
        }

        // POST: api/distributor/provideblanket
        [HttpPost("provideblanket")]
        public async Task<IActionResult> ProvideBlanket([FromBody] StockRequest request)
        {
            var stock = await _context.DistributorStocks
                .FirstOrDefaultAsync(s => s.BlanketName == request.BlanketName && s.Material == request.Material);

            if (stock == null || stock.Quantity < request.Quantity)
            {
                // Try requesting from Manufacturer
                var manufacturerApiUrl = "https://localhost:7263/api/manufacturer/blankets";
                var blankets = await _httpClient.GetFromJsonAsync<List<Blanket>>(manufacturerApiUrl);
                var match = blankets?.FirstOrDefault(b => b.blanketName == request.BlanketName && b.Material == request.Material);

                if (match == null || match.StockQuantity < request.Quantity)
                    return BadRequest("Insufficient stock in Manufacturer and Distributor.");

                if (stock == null)
                {
                    stock = new DistributorStock
                    {
                        BlanketName = request.BlanketName,
                        Material = request.Material,
                        Quantity = request.Quantity
                    };
                    _context.DistributorStocks.Add(stock);
                }
                else
                {
                    stock.Quantity += request.Quantity;
                }

                await _context.SaveChangesAsync();
            }

            stock.Quantity -= request.Quantity;
            await _context.SaveChangesAsync();

            return Ok("Stock provided to seller.");
        }

        [HttpPost("deductstock")]
        public async Task<IActionResult> DeductStock([FromBody] StockRequest request)
        {
            var stock = await _context.DistributorStocks
                .FirstOrDefaultAsync(s => s.BlanketName == request.BlanketName && s.Material == request.Material);

            if (stock == null || stock.Quantity < request.Quantity)
                return BadRequest("Not enough stock to deduct.");

            stock.Quantity -= request.Quantity;
            await _context.SaveChangesAsync();
            return Ok("Stock deducted.");
        }
    }
}
