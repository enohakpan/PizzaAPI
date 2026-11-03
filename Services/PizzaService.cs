using PizzaApi.Models;

namespace PizzaApi.Services;

public class PizzaService
{
    private readonly List<Pizza> _pizzas = new()
    {
        new Pizza { Id = 1, Name = "Cheese Pizza", Description = "Classic mozzarella and tomato sauce.", Price = 9.99m },
        new Pizza { Id = 2, Name = "Pepperoni Pizza", Description = "Pepperoni, mozzarella, and tomato sauce.", Price = 12.49m },
        new Pizza { Id = 3, Name = "Veggie Delight", Description = "Bell peppers, olives, mushrooms, and onions.", Price = 11.99m },
        new Pizza { Id = 4, Name = "BBQ Chicken", Description = "BBQ sauce, chicken, red onion, and cheese.", Price = 13.49m }
    };

    public List<Pizza> GetAll()
    {
        return _pizzas;
    }

    public Pizza? GetById(int id)
    {
        return _pizzas.FirstOrDefault(p => p.Id == id);
    }

    public Pizza Add(Pizza pizza)
    {
        pizza.Id = _pizzas.Count + 1;
        _pizzas.Add(pizza);
        return pizza;
    }

    public Pizza? Update(int id, Pizza updatedPizza)
    {
        Pizza? pizza = _pizzas.FirstOrDefault(p => p.Id == id);
        if (pizza is null)
        {
            return null;
        }

        pizza.Name = updatedPizza.Name;
        pizza.Description = updatedPizza.Description;
        pizza.Price = updatedPizza.Price;
        return pizza;
    }

    public bool Delete(int id)
    {
        Pizza? pizza = _pizzas.FirstOrDefault(p => p.Id == id);
        if (pizza is null)
        {
            return false;
        }

        _pizzas.Remove(pizza);
        return true;
    }
}
