using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributorClient
{
    public partial class Form1 : Form
    {
        private readonly HttpClient client;
        public Form1()
        {
            InitializeComponent();
            client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7013/")
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnViewStock_Click(object sender, EventArgs e)
        {
            try
            {
                var stock = await client.GetFromJsonAsync<List<DistributorStock>>("api/Distributor/stock");
                dataGridView1.DataSource = stock;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock: {ex.Message}");
            }
        }

        private async void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new OrderRequest
                {
                    BlanketName = txtBlanketName.Text,
                    Material = txtMaterial.Text,
                    Quantity = int.Parse(txtQuantity.Text)
                };

                var response = await client.PostAsJsonAsync("api/Distributor/requestfrommanufacturer", request);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Order placed successfully!");
                    btnViewStock_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Failed to place order.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnAddStock_Click(object sender, EventArgs e)
        {
            try
            {
                var stock = new DistributorStock
                {
                    BlanketName = txtBlanketName.Text,
                    Material = txtMaterial.Text,
                    Quantity = int.Parse(txtQuantity.Text)
                };

                var response = await client.PostAsJsonAsync("api/Distributor/addstock", stock);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Stock added successfully!");
                    btnViewStock_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Failed to add stock.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtDeleteId.Text, out int id))
                {
                    var response = await client.DeleteAsync($"api/Distributor/deletestock/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Stock deleted successfully!");
                        btnViewStock_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete stock.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid Blanket ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnProvideBlanket_Click(object sender, EventArgs e)
        {
            var request = new StockRequest
            {
                BlanketName = txtBlanketName.Text,
                Material = txtMaterial.Text,
                Quantity = int.Parse(txtQuantity.Text)
            };

            var response = await client.PostAsJsonAsync("https://localhost:7013/api/distributor/provideblanket", request);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Blanket provided to seller.");
                btnViewStock_Click(sender, e);
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Failed: {error}");
            }
        }

        private async void btnDeductStock_Click(object sender, EventArgs e)
        {
            var request = new StockRequest
            {
                BlanketName = txtBlanketName.Text,
                Material = txtMaterial.Text,
                Quantity = int.Parse(txtQuantity.Text)
            };

            var response = await client.PostAsJsonAsync("https://localhost:7013/api/distributor/deductstock", request);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Stock deducted.");
                btnViewStock_Click(sender, e);
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Failed: {error}");
            }
        }
    }
}
