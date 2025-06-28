using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using WebClient.Model;

namespace WebClient.Pages
{
    public class ItemModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public ItemModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7232/"); // Replace with your actual SellerAPI base URL
        }

        public List<Blanket> Blankets { get; set; } = new();

        public async Task OnGetAsync()
        {
            Blankets = await _httpClient.GetFromJsonAsync<List<Blanket>>("api/Seller/stock");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Seller/deletestock/{id}");

            if (response.IsSuccessStatusCode)
                TempData["Message"] = "Blanket deleted successfully!";
            else
                TempData["Message"] = "Failed to delete blanket.";

            return RedirectToPage();
        }
    }
}
