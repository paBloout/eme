﻿using System;

namespace GroceryListApp
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; } // Property for the quantity of the item
    }
}