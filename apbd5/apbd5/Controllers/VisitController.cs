using apbd5.Database;
using apbd5.Models;
using Microsoft.AspNetCore.Mvc;

namespace apbd5.Controllers;

[ApiController]
[Route("[controller]")]
public class VisitController: ControllerBase
{
    [HttpGet("/visits")]
    public IActionResult getVisits(int animalId)
    {
        var visits = AnimalDatabase.visits;
        return Ok(visits.FindAll(visit => visit.animal.id == animalId));
    }
    
    [HttpPost("addVisit")]
    public IActionResult addAnimal(Animal animal, string date, string description, string price)
    {
        var visits = AnimalDatabase.visits;
        visits.Add(new Visit(){animal = animal, date = date, description = description, price = price});
        return Ok(visits);
    }
}