namespace GroceryListApp
{
    partial class Form2
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
            lblItemName = new Label();
            txtItemName = new TextBox();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            btnAddItem = new Button();
            listBoxGroceries = new ListBox();
            btnCreateJson = new Button();
            lblItemCount = new Label();
            SuspendLayout();
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Location = new Point(63, 24);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(69, 15);
            lblItemName.TabIndex = 0;
            lblItemName.Text = "Item Name:";
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(63, 55);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(100, 23);
            txtItemName.TabIndex = 1;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(63, 109);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(56, 15);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(66, 138);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 23);
            txtQuantity.TabIndex = 3;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(60, 185);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(36, 15);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Price:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(70, 219);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 23);
            txtPrice.TabIndex = 5;
            // 
            // btnAddItem
            // 
            btnAddItem.Location = new Point(66, 274);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(75, 23);
            btnAddItem.TabIndex = 6;
            btnAddItem.Text = "Add Item";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // listBoxGroceries
            // 
            listBoxGroceries.FormattingEnabled = true;
            listBoxGroceries.ItemHeight = 15;
            listBoxGroceries.Location = new Point(368, 53);
            listBoxGroceries.Name = "listBoxGroceries";
            listBoxGroceries.Size = new Size(120, 94);
            listBoxGroceries.TabIndex = 7;
            // 
            // btnCreateJson
            // 
            btnCreateJson.Location = new Point(367, 172);
            btnCreateJson.Name = "btnCreateJson";
            btnCreateJson.Size = new Size(75, 23);
            btnCreateJson.TabIndex = 8;
            btnCreateJson.Text = "Create JSON File";
            btnCreateJson.UseVisualStyleBackColor = true;
            btnCreateJson.Click += btnCreateJson_Click;
            // 
            // lblItemCount
            // 
            lblItemCount.AutoSize = true;
            lblItemCount.Location = new Point(563, 55);
            lblItemCount.Name = "lblItemCount";
            lblItemCount.Size = new Size(95, 15);
            lblItemCount.TabIndex = 9;
            lblItemCount.Text = "Items added: 0/5";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblItemCount);
            Controls.Add(btnCreateJson);
            Controls.Add(listBoxGroceries);
            Controls.Add(btnAddItem);
            Controls.Add(txtPrice);
            Controls.Add(lblPrice);
            Controls.Add(txtQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(txtItemName);
            Controls.Add(lblItemName);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblItemName;
        private TextBox txtItemName;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Label lblPrice;
        private TextBox txtPrice;
        private Button btnAddItem;
        private ListBox listBoxGroceries;
        private Button btnCreateJson;
        private Label lblItemCount;
    }
}