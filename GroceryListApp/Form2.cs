using System;
using System.Collections.Generic;
using System.IO;
using System.Linq; // Needed for LINQ methods like .Max()
using System.Text.Json;
using System.Threading.Tasks; // Needed for async/await
using System.Windows.Forms; // Needed for Windows Forms controls and Application.StartupPath

namespace GroceryListApp
{
    public partial class Form2 : Form
    {
        // A temporary list to hold the groceries added in this session of Form2
        private List<Product> currentAddedGroceries = new List<Product>();
        private const int MAX_ITEMS_PER_BATCH = 5; // Maximum number of items to add at once
        private int tempItemIdCounter = 1; // Counter for assigning temporary IDs to newly added items

        public Form2()
        {
            InitializeComponent();
            UpdateItemCountDisplay(); // Update the label showing the item count
        }

        // Event handler for the button to add an item to the temporary list
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // Check if the maximum number of items for this batch has been reached
            if (currentAddedGroceries.Count < MAX_ITEMS_PER_BATCH)
            {
                string itemName = txtItemName.Text.Trim();
                // Validate that an item name has been entered
                if (string.IsNullOrEmpty(itemName))
                {
                    MessageBox.Show("Please enter an item name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate and parse the quantity
                if (int.TryParse(txtQuantity.Text.Trim(), out int quantity) && quantity > 0)
                {
                    double price = 0;
                    // Optional: Validate and parse the price if the textbox is not empty
                    if (!string.IsNullOrEmpty(txtPrice.Text) && !double.TryParse(txtPrice.Text.Trim(), out price))
                    {
                        MessageBox.Show("Please enter a valid price or leave it empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Create a new Product object with the entered details
                    Product newItem = new Product
                    {
                        // Assign a temporary ID. The final ID will be set before saving to the file.
                        Id = tempItemIdCounter++,
                        Name = itemName,
                        Quantity = quantity,
                        Price = price
                    };

                    // Add the new item to the temporary list
                    currentAddedGroceries.Add(newItem);

                    // Add the item details to the ListBox for display
                    listBoxGroceries.Items.Add($"{newItem.Name} ({newItem.Quantity}) - ${newItem.Price}");

                    // Clear the input fields and set focus back to the item name textbox
                    txtItemName.Clear();
                    txtQuantity.Clear();
                    txtPrice.Clear();
                    txtItemName.Focus();

                    // Update the item count label
                    UpdateItemCountDisplay();
                }
                else
                {
                    MessageBox.Show("Please enter a valid positive quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show($"You can add a maximum of {MAX_ITEMS_PER_BATCH} items in this batch.", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Asynchronously reads a list of Product objects from a JSON file
        // (Duplicated from Form1 for simplicity in a basic example, could be in a shared class)
        private async Task<List<Product>> ReadProductsFromJsonFileAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Product>(); // Return an empty list if the file does not exist
            }
            string jsonContent = await File.ReadAllTextAsync(filePath);
            if (string.IsNullOrWhiteSpace(jsonContent))
            {
                return new List<Product>();
            }
            return JsonSerializer.Deserialize<List<Product>>(jsonContent);
        }

        // Asynchronously writes a list of Product objects to a JSON file
        // (Duplicated from Form1 for simplicity, could be in a shared class)
        private async Task WriteProductsToJsonFileAsync(string filePath, List<Product> products)
        {
            // Configure serialization options for pretty printing (indented JSON)
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(products, options);
            // Write the JSON string to the specified file asynchronously
            await File.WriteAllTextAsync(filePath, json);
        }

        // Event handler for the button to create/append to the JSON file
        private async void btnCreateJson_Click(object sender, EventArgs e)
        {
            // Check if there are items to add
            if (currentAddedGroceries.Count > 0)
            {
                // Construct the full path to the main shopping list JSON file
                string jsonFilePath = Path.Combine(Application.StartupPath, "shoppinglist.json");

                try
                {
                    // 1. Read the existing items from the shopping list file
                    List<Product> existingItems = await ReadProductsFromJsonFileAsync(jsonFilePath);

                    // 2. Determine the next available unique ID
                    int startingIdForNewItems = 0;
                    if (existingItems.Any())
                    {
                        // Find the maximum existing Id and add 1
                        startingIdForNewItems = existingItems.Max(item => item.Id);
                    }
                    int currentNewId = startingIdForNewItems + 1;

                    // 3. Assign correct, unique IDs to the newly added groceries
                    // and add them to the existing list
                    foreach (var newItem in currentAddedGroceries)
                    {
                        newItem.Id = currentNewId++; // Assign a unique ID
                        existingItems.Add(newItem); // Add the item to the list of existing items
                    }

                    // 4. Write the combined list (existing + new items) back to the shopping list file
                    await WriteProductsToJsonFileAsync(jsonFilePath, existingItems);

                    // Show a success message
                    MessageBox.Show($"{currentAddedGroceries.Count} item(s) successfully appended to '{jsonFilePath}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the temporary list and the ListBox after the items have been saved
                    currentAddedGroceries.Clear();
                    listBoxGroceries.Items.Clear();
                    tempItemIdCounter = 1; // Reset the temporary ID counter
                    UpdateItemCountDisplay(); // Update the item count label
                }
                catch (Exception ex)
                {
                    // Show an error message if something goes wrong during file operations
                    MessageBox.Show($"Error appending to JSON file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Message to the user if they try to save without adding items
                MessageBox.Show("Add some items before creating/appending to the JSON file.", "No Items Added", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Updates the text of the label that shows the number of items added
        private void UpdateItemCountDisplay()
        {
            lblItemCount.Text = $"Items added: {currentAddedGroceries.Count}/{MAX_ITEMS_PER_BATCH}";
        }

        // InitializeComponent is called by the form's constructor and is located in Form2.Designer.cs
        // It sets up all the visual controls on the form.
        // private void InitializeComponent() { ... }
    }
}