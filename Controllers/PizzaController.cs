using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Models;
using PizzaAPI.Services;

namespace PizzaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _pizzaService;

        public PizzaController(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => _pizzaService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Pizza> GetById(int id)
        {
            var pizza = _pizzaService.GetById(id);
            return pizza != null ? Ok(pizza) : NotFound();
        }

        [HttpPost]
        public IActionResult Add(Pizza pizza)
        {
            _pizzaService.Add(pizza);
            return CreatedAtAction(nameof(GetById), new
            {
                id = pizza.Id
            }, pizza);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            var existingPizza = _pizzaService.GetById(id);
            if(existingPizza == null)
                return NotFound();

            _pizzaService.Update(id, pizza);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = _pizzaService.GetById(id);
            if(pizza == null)
                return NotFound();

            _pizzaService.Delete(id);
            return NoContent();
        }
    }
}
