using PizzaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzaAPI.Services
{
    public class PizzaService
    {
        private static List<Pizza> pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Margherita", Description = "Classic cheese and tomato", Price = 8.99M, IsVegetarian = true },
            new Pizza { Id = 2, Name = "Pepperoni", Description = "Pepperoni and cheese", Price = 10.99M, IsVegetarian = false }
        };

        public List<Pizza> GetAll() => pizzas;

        public Pizza? GetById(int id) => pizzas.FirstOrDefault(p => p.Id == id);

        public void Add(Pizza pizza)
        {
            pizza.Id = pizzas.Count + 1;
            pizzas.Add(pizza);
        }

        public void Update(int id, Pizza pizza)
        {
            var existingPizza = pizzas.FirstOrDefault(p => p.Id == id);
            if(existingPizza != null)
            {
                existingPizza.Name = pizza.Name;
                existingPizza.Description = pizza.Description;
                existingPizza.Price = pizza.Price;
                existingPizza.IsVegetarian = pizza.IsVegetarian;
            }
        }

        public void Delete(int id) => pizzas.RemoveAll(p => p.Id == id);
    }
}
