using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    PizzaService _service;
    
    public PizzaController( PizzaService service)
    {
        _service = service;
    }

    // GET all action
    [HttpGet]
    public IEnumerable<Pizza> GetAll() => _service.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = _service.GetById(id);

        if (pizza is null)
            return NotFound();

        return pizza;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Pizza newPizza)
    {
        var pizza = _service.Create(newPizza);
        return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}/addtopping")]
    public IActionResult AddTopping(int id, int toppingId)
    {
        var pizzaToUpdate = _service.GetById(id);

        //if (pizzaToUpdate is not null)
        //    return BadRequest();

        var existingPizza = _service.GetById(id);
        if (existingPizza is null)
            return NotFound();

        _service.AddTopping(id, toppingId);

        return NoContent();
    }

    [HttpPut("{id}/updatesauce")]
    public IActionResult UpdateSauce(int id, int sauceId)
    {
        var pizzaToUpdate = _service.GetById(id);

        //if (pizzaToUpdate is not null)
        //    return BadRequest();

        var existingPizza = _service.GetById(id);
        if (existingPizza is null)
            return NotFound();

        _service.UpdateSauce(id, sauceId);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = _service.GetById(id);

        if (pizza is null)
            return NotFound();

        _service.DeleteById(id);

        return Ok();
    }
}