﻿namespace PizzaAPI.Models
{
    public class Pizza
    {
        public int Id
        {
            get; set;
        }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price
        {
            get; set;
        }
        public bool IsVegetarian
        {
            get; set;
        }
    }
}
