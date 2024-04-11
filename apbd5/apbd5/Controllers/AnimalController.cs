using apbd5.Database;
using apbd5.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace apbd5.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalController: ControllerBase
{
    public AnimalController()
    {
        
    }
    
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
    public IActionResult addAnimal(Animal animal)
    {
        AnimalDatabase.animals.Add(animal);
        return Ok(AnimalDatabase.animals);
    }
    
    [HttpPut("updateAnimal")]
    public IActionResult updateAnimal(int id, Animal animal2)
    {
        var animal = AnimalDatabase.animals.Find(animal => animal.id == id);
        animal.category = animal2.category;
        animal.name = animal2.name;
        animal.weight = animal2.weight;
        animal.furColor = animal2.furColor;
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