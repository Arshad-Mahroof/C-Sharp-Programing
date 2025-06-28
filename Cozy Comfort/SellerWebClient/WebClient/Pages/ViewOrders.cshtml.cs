using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using WebClient.Model;

namespace WebClient.Pages
{
    public class ViewOrdersModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public ViewOrdersModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public List<Order> Orders { get; set; }

        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7232/api/Seller/orders");

            if (response.IsSuccessStatusCode)
            {
                Orders = await response.Content.ReadFromJsonAsync<List<Order>>();
            }
            else
            {
                Orders = new List<Order>();
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7232/"); // your SellerAPI base URL

            var response = await client.DeleteAsync($"api/Seller/deleteorder/{id}");

            TempData["Message"] = response.IsSuccessStatusCode
                ? "Order deleted successfully!"
                : "Failed to delete order.";

            return RedirectToPage();
        }

    }
}
