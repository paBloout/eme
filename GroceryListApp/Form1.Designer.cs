namespace GroceryListApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewShoppingList = new DataGridView();
            btnLoadShoppingList = new Button();
            btnOpenAddGroceries = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShoppingList).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewShoppingList
            // 
            dataGridViewShoppingList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewShoppingList.Location = new Point(160, 48);
            dataGridViewShoppingList.Name = "dataGridViewShoppingList";
            dataGridViewShoppingList.Size = new Size(310, 153);
            dataGridViewShoppingList.TabIndex = 0;
            // 
            // btnLoadShoppingList
            // 
            btnLoadShoppingList.Location = new Point(160, 232);
            btnLoadShoppingList.Name = "btnLoadShoppingList";
            btnLoadShoppingList.Size = new Size(75, 23);
            btnLoadShoppingList.TabIndex = 1;
            btnLoadShoppingList.Text = "Load Shopping List";
            btnLoadShoppingList.UseVisualStyleBackColor = true;
            btnLoadShoppingList.Click += btnLoadShoppingList_Click;
            // 
            // btnOpenAddGroceries
            // 
            btnOpenAddGroceries.Location = new Point(160, 287);
            btnOpenAddGroceries.Name = "btnOpenAddGroceries";
            btnOpenAddGroceries.Size = new Size(75, 23);
            btnOpenAddGroceries.TabIndex = 2;
            btnOpenAddGroceries.Text = "Add Groceries";
            btnOpenAddGroceries.UseVisualStyleBackColor = true;
            btnOpenAddGroceries.Click += btnOpenAddGroceries_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOpenAddGroceries);
            Controls.Add(btnLoadShoppingList);
            Controls.Add(dataGridViewShoppingList);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewShoppingList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewShoppingList;
        private Button btnLoadShoppingList;
        private Button btnOpenAddGroceries;
    }
}
