using apbd5.Database;
using apbd5.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace apbd5.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalController: ControllerBase
{
    
    [HttpGet("/animals")]
    public IActionResult getAnimals()
    {
        return Ok(AnimalDatabase.animals);
    }
    
    [HttpGet("/animal")]
    public IActionResult getAnimalById(int id)
    {
        var animals = AnimalDatabase.animals;
        return Ok(animals.Find(animal => animal.id == id));
    }
    
    [HttpPost("addAnimal")]
    public IActionResult addAnimal(int id, string category, string name, double weight, string furColor)
    {
        AnimalDatabase.animals.Add(new Animal(){id = id, category = category, name = name, weight = weight,furColor = furColor});
        return Ok(AnimalDatabase.animals);
    }
    
    [HttpPut("updateAnimal")]
    public IActionResult updateAnimal(int id, string category, string name, double weight, string furColor)
    {
        var animal = AnimalDatabase.animals.Find(animal => animal.id == id);
        animal.category = category;
        animal.name = name;
        animal.weight = weight;
        animal.furColor = furColor;
        return Ok(animal);
    }

    [HttpDelete("deleteAnimal")]
    public IActionResult deleteAnimal(int id)
    {
        var animals = AnimalDatabase.animals;
        var animal = animals.Find(animal => animal.id == id);
        animals.Remove(animal);
        return Ok(animals);
    }
}