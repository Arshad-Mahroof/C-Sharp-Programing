using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace ManufacturerClient
{
    public partial class Form1 : Form
    {
        private readonly HttpClient client;
        public Form1()
        {
            InitializeComponent();
            client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7263/")
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnLoadBlankets_Click(object sender, EventArgs e)
        {
            try
            {
                var blankets = await client.GetFromJsonAsync<List<Blanket>>("api/Manufacturer/blankets");
                dataGridView1.DataSource = blankets;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading blankets: {ex.Message}");
            }
        }

        private async void btnAddBlanket_Click(object sender, EventArgs e)
        {
            try
            {
                var newBlanket = new Blanket
                {
                    blanketName = txtName.Text,
                    Material = txtMaterial.Text,
                    StockQuantity = int.Parse(txtStockQuantity.Text),
                    ProductionCapacity = int.Parse(txtProductionCapacity.Text)
                };

                var response = await client.PostAsJsonAsync("api/Manufacturer/add", newBlanket);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Blanket added!");
                    btnLoadBlankets_Click(sender, e); // Refresh table
                }
                else
                {
                    MessageBox.Show("Failed to add blanket.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnProduce_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new ProductionRequest
                {
                    BlanketId = int.Parse(txtProduceId.Text),
                    Quantity = int.Parse(txtProduceQty.Text)
                };

                var response = await client.PostAsJsonAsync("api/Manufacturer/produce", request);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Production successful!");
                    btnLoadBlankets_Click(sender, e); // Refresh table
                }
                else
                {
                    MessageBox.Show("Production failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnDeleteBlanket_Click(object sender, EventArgs e)
        {
            try
            {
                int blanketId = int.Parse(txtDeleteId.Text);
                var response = await client.DeleteAsync($"api/Manufacturer/delete/{blanketId}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Blanket deleted successfully!");
                    btnLoadBlankets_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Failed to delete blanket.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
