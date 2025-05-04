using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks; // Needed for async/await
using System.Windows.Forms; // Needed for Windows Forms controls and Application.StartupPath

namespace GroceryListApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Asynchronously reads a list of Product objects from a JSON file
        private async Task<List<Product>> ReadProductsFromJsonFileAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                // Return an empty list if the file does not exist
                return new List<Product>();
            }

            // Read the entire content of the file asynchronously
            string jsonContent = await File.ReadAllTextAsync(filePath);

            // Handle case where the file might be empty or contain only whitespace
            if (string.IsNullOrWhiteSpace(jsonContent))
            {
                return new List<Product>();
            }

            // Deserialize the JSON content into a list of Product objects
            return JsonSerializer.Deserialize<List<Product>>(jsonContent);
        }

        // Event handler for the button to load the shopping list
        private async void btnLoadShoppingList_Click(object sender, EventArgs e)
        {
            // Construct the full path to the shopping list JSON file.
            // Application.StartupPath gets the directory where the application executable is located.
            string jsonFilePath = Path.Combine(Application.StartupPath, "shoppinglist.json");

            try
            {
                // Read the shopping list data
                List<Product> shoppingList = await ReadProductsFromJsonFileAsync(jsonFilePath);

                // Bind the list of products to the DataGridView to display them
                dataGridViewShoppingList.DataSource = shoppingList;

                // Optional: Auto-resize columns to fit content
                dataGridViewShoppingList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                // Show an error message if something goes wrong
                MessageBox.Show($"Error loading shopping list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the button to open the form for adding groceries
        private void btnOpenAddGroceries_Click(object sender, EventArgs e)
        {
            // Create an instance of Form2
            Form2 addGroceriesForm = new Form2();

            // Show Form2. Use ShowDialog() to open modally (blocks interaction with Form1)
            // or Show() to open non-modally (allows interaction with both forms).
            addGroceriesForm.Show();
        }

        // InitializeComponent is called by the form's constructor and is located in Form1.Designer.cs
        // It sets up all the visual controls on the form.
        // private void InitializeComponent() { ... }
    }
}