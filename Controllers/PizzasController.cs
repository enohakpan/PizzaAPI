using Microsoft.AspNetCore.Mvc;
using PizzaApi.Models;
using PizzaApi.Services;

namespace PizzaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzasController : ControllerBase
{
    private readonly PizzaService _service;

    public PizzasController(PizzaService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Pizza>> Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> GetById(int id)
    {
        Pizza? pizza = _service.GetById(id);
        if (pizza == null)
        {
            return NotFound();
        }

        return Ok(pizza);
    }

    [HttpPost]
    public ActionResult<Pizza> Post(Pizza pizza)
    {
        Pizza newPizza = _service.Add(pizza);
        return CreatedAtAction(nameof(GetById), new { id = newPizza.Id }, newPizza);
    }

    [HttpPut("{id}")]
    public ActionResult<Pizza> Put(int id, Pizza pizza)
    {
        Pizza? updated = _service.Update(id, pizza);
        if (updated == null)
        {
            return NotFound();
        }

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool deleted = _service.Delete(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
