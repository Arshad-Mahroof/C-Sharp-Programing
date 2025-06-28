namespace ManufacturerClient
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.txtStockQuantity = new System.Windows.Forms.TextBox();
            this.txtProductionCapacity = new System.Windows.Forms.TextBox();
            this.txtProduceId = new System.Windows.Forms.TextBox();
            this.txtProduceQty = new System.Windows.Forms.TextBox();
            this.btnLoadBlankets = new System.Windows.Forms.Button();
            this.btnAddBlanket = new System.Windows.Forms.Button();
            this.btnProduce = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDeleteId = new System.Windows.Forms.TextBox();
            this.btnDeleteBlanket = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(300, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(488, 380);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(176, 44);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 22);
            this.txtName.TabIndex = 1;
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(176, 82);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(100, 22);
            this.txtMaterial.TabIndex = 2;
            // 
            // txtStockQuantity
            // 
            this.txtStockQuantity.Location = new System.Drawing.Point(176, 122);
            this.txtStockQuantity.Name = "txtStockQuantity";
            this.txtStockQuantity.Size = new System.Drawing.Size(100, 22);
            this.txtStockQuantity.TabIndex = 3;
            // 
            // txtProductionCapacity
            // 
            this.txtProductionCapacity.Location = new System.Drawing.Point(176, 165);
            this.txtProductionCapacity.Name = "txtProductionCapacity";
            this.txtProductionCapacity.Size = new System.Drawing.Size(100, 22);
            this.txtProductionCapacity.TabIndex = 4;
            // 
            // txtProduceId
            // 
            this.txtProduceId.Location = new System.Drawing.Point(176, 237);
            this.txtProduceId.Name = "txtProduceId";
            this.txtProduceId.Size = new System.Drawing.Size(100, 22);
            this.txtProduceId.TabIndex = 5;
            // 
            // txtProduceQty
            // 
            this.txtProduceQty.Location = new System.Drawing.Point(176, 276);
            this.txtProduceQty.Name = "txtProduceQty";
            this.txtProduceQty.Size = new System.Drawing.Size(100, 22);
            this.txtProduceQty.TabIndex = 6;
            // 
            // btnLoadBlankets
            // 
            this.btnLoadBlankets.Location = new System.Drawing.Point(515, 29);
            this.btnLoadBlankets.Name = "btnLoadBlankets";
            this.btnLoadBlankets.Size = new System.Drawing.Size(75, 23);
            this.btnLoadBlankets.TabIndex = 7;
            this.btnLoadBlankets.Text = "Load Blankets";
            this.btnLoadBlankets.UseVisualStyleBackColor = true;
            this.btnLoadBlankets.Click += new System.EventHandler(this.btnLoadBlankets_Click);
            // 
            // btnAddBlanket
            // 
            this.btnAddBlanket.Location = new System.Drawing.Point(186, 202);
            this.btnAddBlanket.Name = "btnAddBlanket";
            this.btnAddBlanket.Size = new System.Drawing.Size(75, 23);
            this.btnAddBlanket.TabIndex = 8;
            this.btnAddBlanket.Text = "Add Blanket";
            this.btnAddBlanket.UseVisualStyleBackColor = true;
            this.btnAddBlanket.Click += new System.EventHandler(this.btnAddBlanket_Click);
            // 
            // btnProduce
            // 
            this.btnProduce.Location = new System.Drawing.Point(186, 309);
            this.btnProduce.Name = "btnProduce";
            this.btnProduce.Size = new System.Drawing.Size(75, 23);
            this.btnProduce.TabIndex = 9;
            this.btnProduce.Text = "Produce";
            this.btnProduce.UseVisualStyleBackColor = true;
            this.btnProduce.Click += new System.EventHandler(this.btnProduce_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Blanket Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Material";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Production Capacity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Stock Quantity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Blanket ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Quantity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Blanket ID";
            // 
            // txtDeleteId
            // 
            this.txtDeleteId.Location = new System.Drawing.Point(176, 350);
            this.txtDeleteId.Name = "txtDeleteId";
            this.txtDeleteId.Size = new System.Drawing.Size(100, 22);
            this.txtDeleteId.TabIndex = 17;
            // 
            // btnDeleteBlanket
            // 
            this.btnDeleteBlanket.Location = new System.Drawing.Point(186, 388);
            this.btnDeleteBlanket.Name = "btnDeleteBlanket";
            this.btnDeleteBlanket.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteBlanket.TabIndex = 18;
            this.btnDeleteBlanket.Text = "Delete Blanket";
            this.btnDeleteBlanket.UseVisualStyleBackColor = true;
            this.btnDeleteBlanket.Click += new System.EventHandler(this.btnDeleteBlanket_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeleteBlanket);
            this.Controls.Add(this.txtDeleteId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProduce);
            this.Controls.Add(this.btnAddBlanket);
            this.Controls.Add(this.btnLoadBlankets);
            this.Controls.Add(this.txtProduceQty);
            this.Controls.Add(this.txtProduceId);
            this.Controls.Add(this.txtProductionCapacity);
            this.Controls.Add(this.txtStockQuantity);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.TextBox txtStockQuantity;
        private System.Windows.Forms.TextBox txtProductionCapacity;
        private System.Windows.Forms.TextBox txtProduceId;
        private System.Windows.Forms.TextBox txtProduceQty;
        private System.Windows.Forms.Button btnLoadBlankets;
        private System.Windows.Forms.Button btnAddBlanket;
        private System.Windows.Forms.Button btnProduce;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDeleteId;
        private System.Windows.Forms.Button btnDeleteBlanket;
    }
}

