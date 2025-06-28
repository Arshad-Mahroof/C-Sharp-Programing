namespace DistributorClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnViewStock = new System.Windows.Forms.Button();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBlanketName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeleteId = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnProvideBlanket = new System.Windows.Forms.Button();
            this.btnDeductStock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(367, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(421, 353);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(120, 133);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(220, 22);
            this.txtMaterial.TabIndex = 1;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(120, 182);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(220, 22);
            this.txtQuantity.TabIndex = 2;
            // 
            // btnViewStock
            // 
            this.btnViewStock.Location = new System.Drawing.Point(529, 34);
            this.btnViewStock.Name = "btnViewStock";
            this.btnViewStock.Size = new System.Drawing.Size(118, 30);
            this.btnViewStock.TabIndex = 3;
            this.btnViewStock.Text = "View Stock";
            this.btnViewStock.UseVisualStyleBackColor = true;
            this.btnViewStock.Click += new System.EventHandler(this.btnViewStock_Click);
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Location = new System.Drawing.Point(188, 237);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(152, 30);
            this.btnPlaceOrder.TabIndex = 4;
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Material";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Order Quantity";
            // 
            // txtBlanketName
            // 
            this.txtBlanketName.Location = new System.Drawing.Point(120, 87);
            this.txtBlanketName.Name = "txtBlanketName";
            this.txtBlanketName.Size = new System.Drawing.Size(220, 22);
            this.txtBlanketName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Blanket Name";
            // 
            // btnAddStock
            // 
            this.btnAddStock.Location = new System.Drawing.Point(12, 237);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(170, 30);
            this.btnAddStock.TabIndex = 9;
            this.btnAddStock.Text = "Add Stock";
            this.btnAddStock.UseVisualStyleBackColor = true;
            this.btnAddStock.Click += new System.EventHandler(this.btnAddStock_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Blanket ID";
            // 
            // txtDeleteId
            // 
            this.txtDeleteId.Location = new System.Drawing.Point(120, 355);
            this.txtDeleteId.Name = "txtDeleteId";
            this.txtDeleteId.Size = new System.Drawing.Size(220, 22);
            this.txtDeleteId.TabIndex = 10;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(99, 401);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(171, 30);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete Stock";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnProvideBlanket
            // 
            this.btnProvideBlanket.Location = new System.Drawing.Point(12, 291);
            this.btnProvideBlanket.Name = "btnProvideBlanket";
            this.btnProvideBlanket.Size = new System.Drawing.Size(170, 30);
            this.btnProvideBlanket.TabIndex = 13;
            this.btnProvideBlanket.Text = "Provide Blanket";
            this.btnProvideBlanket.UseVisualStyleBackColor = true;
            this.btnProvideBlanket.Click += new System.EventHandler(this.btnProvideBlanket_Click);
            // 
            // btnDeductStock
            // 
            this.btnDeductStock.Location = new System.Drawing.Point(188, 291);
            this.btnDeductStock.Name = "btnDeductStock";
            this.btnDeductStock.Size = new System.Drawing.Size(152, 30);
            this.btnDeductStock.TabIndex = 14;
            this.btnDeductStock.Text = "Deduct Stock";
            this.btnDeductStock.UseVisualStyleBackColor = true;
            this.btnDeductStock.Click += new System.EventHandler(this.btnDeductStock_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeductStock);
            this.Controls.Add(this.btnProvideBlanket);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDeleteId);
            this.Controls.Add(this.btnAddStock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBlanketName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.btnViewStock);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnViewStock;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBlanketName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDeleteId;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnProvideBlanket;
        private System.Windows.Forms.Button btnDeductStock;
    }
}

