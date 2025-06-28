using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;

namespace SellerWeb.Pages
{
    public class RequestFromDistributorModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RequestFromDistributorModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public StockRequest Request { get; set; } = new();

        public string? Message { get; set; }
        public string? Error { get; set; }

        public void OnGet()
        {
            // Optionally preload data
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsJsonAsync(
                "https://localhost:7232/api/seller/requestfromdistributor",
                Request
            );

            if (response.IsSuccessStatusCode)
            {
                Message = "✅ Stock successfully requested from distributor.";
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                Error = $"❌ Failed to request stock. Server said: {error}";
            }

            return Page();
        }

        public class StockRequest
        {
            public string CustomerName { get; set; } = ""; // ✅ Add this field
            public string BlanketName { get; set; } = "";
            public string Material { get; set; } = "";
            public int Quantity { get; set; }
        }
    }
}
