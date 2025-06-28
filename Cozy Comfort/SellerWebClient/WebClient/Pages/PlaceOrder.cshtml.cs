using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebClient.Model;

namespace WebClient.Pages
{
    public class PlaceOrderModel : PageModel
    {
        [BindProperty]
        public OrderRequest Order { get; set; }

        private readonly IHttpClientFactory _clientFactory;

        public PlaceOrderModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public void OnGet()
        {
            // Page Load
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var client = _clientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7232/api/Seller/placeorder", Order);

            if (response.IsSuccessStatusCode)
            {
                ViewData["Message"] = "Order placed successfully!";
            }
            else
            {
                var errorDetails = await response.Content.ReadAsStringAsync();
                ViewData["Message"] = $"Failed to place order. API said: {errorDetails}";
            }

            return Page();
        }
    }
}
